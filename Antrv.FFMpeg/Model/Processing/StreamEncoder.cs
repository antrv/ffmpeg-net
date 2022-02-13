using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Codecs;
using Antrv.FFMpeg.Model.Guards;
using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

public sealed class StreamEncoder: IEncodedStream, IObserver<Frame>, IDisposable
{
    private readonly ObserverManager<Packet> _manager = new();
    private readonly PacketGuard _packet = new();
    private readonly CodecContextGuard _context;
    private readonly CodecParametersGuard _codecParameters;
    private readonly IDisposable _subscription;

    public StreamEncoder(IRawStream sourceStream, AVCodecID codecId)
{
        if (sourceStream.MediaType != LibAvCodec.avcodec_get_type(codecId))
            throw new ArgumentException("Codec media type is different", nameof(codecId));

        if (!Global.Codecs.TryGetCodec(codecId, out Codec? codec))
            throw new ArgumentException($"Codec {codecId} is not supported", nameof(codecId));

        Codec = codec!;
        Encoder = GetEncoder(codec!);
        SourceStream = sourceStream;

        _context = CreateEncoderContext(sourceStream, Encoder);
        _codecParameters = new CodecParametersGuard();
        LibAvCodec.avcodec_parameters_from_context(_codecParameters.Ptr, _context.Ptr)
            .ThrowOnError("Failed to copy codec parameters");

        CodecParameters = new CodecParameters(_codecParameters.Ptr);

        // subscribe
        _subscription = sourceStream.Subscribe(this);
    }

    public StreamEncoder(IRawStream sourceStream, Codec codec)
    {
        if (sourceStream.MediaType != codec.MediaType)
            throw new ArgumentException("Codec media type is different", nameof(codec));

        Codec = codec;
        Encoder = GetEncoder(codec);
        SourceStream = sourceStream;

        _context = CreateEncoderContext(sourceStream, Encoder);
        _codecParameters = new CodecParametersGuard();
        LibAvCodec.avcodec_parameters_from_context(_codecParameters.Ptr, _context.Ptr)
            .ThrowOnError("Failed to copy codec parameters");

        CodecParameters = new CodecParameters(_codecParameters.Ptr);

        // subscribe
        _subscription = sourceStream.Subscribe(this);
    }

    public StreamEncoder(IRawStream sourceStream, Encoder encoder)
    {
        if (sourceStream.MediaType != encoder.MediaType)
            throw new ArgumentException("Encoder media type is different", nameof(encoder));

        Codec = encoder.Codec;
        Encoder = encoder;
        SourceStream = sourceStream;

        _context = CreateEncoderContext(sourceStream, Encoder);
        _codecParameters = new CodecParametersGuard();
        LibAvCodec.avcodec_parameters_from_context(_codecParameters.Ptr, _context.Ptr)
            .ThrowOnError("Failed to copy codec parameters");
        
        CodecParameters = new CodecParameters(_codecParameters.Ptr);

        // subscribe
        _subscription = sourceStream.Subscribe(this);
    }

    public IRawStream SourceStream { get; }
    public Codec Codec { get; }
    public CodecParameters CodecParameters { get; }
    public Encoder Encoder { get; }
    public AVMediaType MediaType => SourceStream.MediaType;
    public AVRational TimeBase => SourceStream.TimeBase;
    public StreamParameters Parameters => SourceStream.Parameters;

    public IDisposable Subscribe(IObserver<Packet> observer) => _manager.Subscribe(observer);

    public void Dispose()
    {
        _subscription.Dispose();
        _manager.Clear();
        _packet.Dispose();
        _codecParameters.Dispose();
    }

    void IObserver<Frame>.OnCompleted() => _manager.Completed();
    void IObserver<Frame>.OnError(Exception error) => _manager.Error(error);
    void IObserver<Frame>.OnNext(Frame value)
    {
        try
        {
            ProcessFrame(value);
        }
        catch (Exception exception)
        {
            _manager.Error(exception);
        }
    }

    private void ProcessFrame(Frame frame)
    {
        LibAvCodec.avcodec_send_frame(_context.Ptr, frame.Ptr).ThrowOnError("Failed to encode frame");
        while (true)
        {
            int error = LibAvCodec.avcodec_receive_packet(_context.Ptr, _packet.Ptr);
            if (error < 0)
            {
                if ((AVError)error is AVError.AVERROR_EOF or AVError.AVERROR_EAGAIN)
                    break;

                error.ThrowOnError("Failed to encode frame");
            }

            try
            {
                _manager.Next(new Packet(this, _packet.Ptr));
            }
            finally
            {
                _packet.UnRef();
            }
        }
    }

    private static Encoder GetEncoder(Codec codec)
    {
        ConstPtr<AVCodec> encoderPtr = LibAvCodec.avcodec_find_encoder(codec.Id);
        if (!encoderPtr)
            throw new InvalidOperationException($"No encoder for codec {codec}");

        return codec!.Encoders.First(x => x.CodecPtr == encoderPtr);
    }

    private static CodecContextGuard CreateEncoderContext(IRawStream stream, Encoder encoder)
    {
        using CodecContextGuard contextGuard = new(encoder.CodecPtr);
        ref AVCodecContext context = ref contextGuard.Ptr.Ref;

        context.TimeBase = stream.TimeBase;
        FillParameters(stream, encoder, ref context);

        // TODO!!!
        context.Flags |= AVCodecFlags.AV_CODEC_FLAG_GLOBAL_HEADER;

        using DictionaryGuard dictionaryWrapper = new();
        LibAvCodec.avcodec_open2(contextGuard.Ptr, encoder.CodecPtr, ref dictionaryWrapper.Ptr)
            .ThrowOnError("Failed to open decoder");

        return contextGuard.MovePtr();
    }

    private static void FillParameters(IRawStream stream, Encoder encoder, ref AVCodecContext context)
    {
        switch (stream.MediaType)
        {
            case AVMediaType.Video:
                FillVideoParameters(stream, (VideoEncoder)encoder, ref context);
                break;

            case AVMediaType.Audio:
                FillAudioParameters(stream, (AudioEncoder)encoder, ref context);
                break;

            default:
                throw new NotImplementedException();
        }
    }

    private static void FillVideoParameters(IRawStream stream, VideoEncoder encoder, ref AVCodecContext context)
    {
        VideoParameters parameters = (VideoParameters)stream.Parameters;

        context.Width = parameters.Width;
        context.Height = parameters.Height;
        context.FrameRate = parameters.FrameRate;
        context.SampleAspectRatio = parameters.SampleAspectRatio;

        AVPixelFormat pixelFormat = parameters.PixelFormat;
        if (encoder.PixelFormats.Count > 0)
        {
            if (!encoder.PixelFormats.Contains(pixelFormat))
                throw new InvalidOperationException($"Encoder doesn't support pixel format {pixelFormat}");

            context.PixelFormat = pixelFormat;
        }
        else
            context.PixelFormat = parameters.PixelFormat;

        // TODO pass encoding parameters like bitrate, quality, etc
        //LibAvUtil.av_opt_set_int((IntPtr)contextRef.PrivateData, "crf", 25, 0);
        //LibAvUtil.av_opt_set((IntPtr)contextRef.PrivateData, "preset", "slow", 0);
    }

    private static void FillAudioParameters(IRawStream stream, AudioEncoder encoder, ref AVCodecContext context)
    {
        AudioParameters parameters = (AudioParameters)stream.Parameters;

        // context.Bitrate = _bitrate; // TODO pass encoding parameters like bitrate, quality, etc

        context.SampleRate = parameters.SampleRate;
        context.ChannelLayout = parameters.ChannelLayout;
        context.Channels = LibAvUtil.av_get_channel_layout_nb_channels(parameters.ChannelLayout);

        AVSampleFormat sampleFormat = parameters.SampleFormat;
        if (encoder.SampleFormats.Count > 0 && !encoder.SampleFormats.Contains(sampleFormat))
            throw new InvalidOperationException($"Encoder doesn't support sample format {sampleFormat}");

        context.SampleFormat = sampleFormat;
    }
}
