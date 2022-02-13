using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Guards;
using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

public sealed class StreamDecoder: IRawStream, IObserver<Packet>, IDisposable
{
    private readonly ObserverManager<Frame> _manager;
    private readonly CodecContextGuard _context;
    private readonly FrameGuard _frame;
    private readonly IDisposable _subscription;

    public StreamDecoder(IEncodedStream inputStream)
    {
        _manager = new();

        InputStream = inputStream;
        _context = CreateDecoder(inputStream);
        _frame = new();

        // subscribe
        _subscription = inputStream.Subscribe(this);
    }

    public IEncodedStream InputStream { get; }
    public AVMediaType MediaType => InputStream.MediaType;
    public AVRational TimeBase => InputStream.TimeBase;
    public StreamParameters Parameters => InputStream.Parameters;

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

    private static CodecContextGuard CreateDecoder(IEncodedStream stream)
    {
        ConstPtr<AVCodec> decoder = LibAvCodec.avcodec_find_decoder(stream.Codec.Id);
        if (!decoder)
            throw new InvalidOperationException($"No decoder for codec {stream.Codec}");

        // TODO: ability to choose decoder (i.e. hardware decoder)
        using CodecContextGuard contextGuard = new(decoder);
        ref AVCodecContext context = ref contextGuard.Ptr.Ref;

        LibAvCodec.avcodec_parameters_to_context(contextGuard.Ptr, stream.CodecParameters.Ptr)
            .ThrowOnError("Failed to copy parameters to context");

        context.TimeBase = stream.TimeBase;

        using DictionaryGuard dictionaryWrapper = new();
        LibAvCodec.avcodec_open2(contextGuard.Ptr, decoder, ref dictionaryWrapper.Ptr)
            .ThrowOnError("Failed to open decoder");

        return contextGuard.MovePtr();
    }
}
