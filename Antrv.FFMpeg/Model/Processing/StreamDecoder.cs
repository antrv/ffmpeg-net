using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Codecs;
using Antrv.FFMpeg.Model.Guards;
using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

public sealed class StreamDecoder: IRawStream, IObserver<Packet>, IDisposable
{
    private readonly ObserverManager<Frame> _manager;
    private readonly CodecContextGuard _context;
    private readonly FrameGuard _frame;
    private readonly IDisposable _subscription;

    public StreamDecoder(IEncodedStream sourceStream, Decoder? decoder = null)
    {
        Decoder = GetDecoder(sourceStream, decoder);
        SourceStream = sourceStream;

        _context = CreateDecoderContext(sourceStream, Decoder);
        _manager = new();
        _frame = new();

        // subscribe
        _subscription = sourceStream.Subscribe(this);
    }

    public IEncodedStream SourceStream { get; }
    public Decoder Decoder { get; }
    public AVMediaType MediaType => SourceStream.MediaType;
    public AVRational TimeBase => SourceStream.TimeBase;
    public StreamParameters Parameters => SourceStream.Parameters;

    public IDisposable Subscribe(IObserver<Frame> observer) => _manager.Subscribe(observer);

    public void Dispose()
    {
        _manager.Clear();
        _subscription.Dispose();
        _frame.Dispose();
    }

    void IObserver<Packet>.OnCompleted() => _manager.Completed();
    void IObserver<Packet>.OnError(Exception error) => _manager.Error(error);
    void IObserver<Packet>.OnNext(Packet value)
    {
        try
        {
            ProcessPacket(value);
        }
        catch (Exception exception)
        {
            _manager.Error(exception);
        }
    }

    private void ProcessPacket(Packet packet)
    {
        LibAvCodec.avcodec_send_packet(_context.Ptr, packet.Ptr).ThrowOnError("Failed to decode packet");
        while (true)
        {
            int error = LibAvCodec.avcodec_receive_frame(_context.Ptr, _frame.Ptr);
            if (error < 0)
            {
                if ((AVError)error is AVError.AVERROR_EOF or AVError.AVERROR_EAGAIN)
                    break;

                error.ThrowOnError("Failed to decode packet");
            }

            try
            {
                _manager.Next(new Frame(this, _frame.Ptr));
            }
            finally
            {
                _frame.UnRef();
            }
        }
    }

    private static Decoder GetDecoder(IEncodedStream stream, Decoder? decoder)
    {
        AVCodecID codecId = stream.Codec.Id;
        if (decoder is null)
        {
            ConstPtr<AVCodec> decoderPtr = LibAvCodec.avcodec_find_decoder(codecId);
            if (!decoderPtr)
                throw new InvalidOperationException($"No decoder for codec {stream.Codec}");

            return stream.Codec.Decoders.First(x => x.CodecPtr == decoderPtr);
        }

        if (decoder.CodecId != codecId)
            throw new ArgumentException("Decoder codec and stream codec are not the same codec", nameof(decoder));

        return decoder;
    }

    private static CodecContextGuard CreateDecoderContext(IEncodedStream stream, Decoder decoder)
    {
        using CodecContextGuard contextGuard = new(decoder.CodecPtr);
        ref AVCodecContext context = ref contextGuard.Ptr.Ref;

        LibAvCodec.avcodec_parameters_to_context(contextGuard.Ptr, stream.CodecParameters.Ptr)
            .ThrowOnError("Failed to copy parameters to context");

        context.TimeBase = stream.TimeBase;

        using DictionaryGuard dictionaryWrapper = new();
        LibAvCodec.avcodec_open2(contextGuard.Ptr, decoder.CodecPtr, ref dictionaryWrapper.Ptr)
            .ThrowOnError("Failed to open decoder");

        return contextGuard.MovePtr();
    }
}
