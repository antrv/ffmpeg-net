using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Guards;

namespace Antrv.FFMpeg.Model.Processing;

public sealed class Decoder: IObserver<Packet>, IDisposable
{
    private readonly DecodedStream _decodedStream;
    private readonly CodecContextGuard _context;
    private readonly FrameGuard _frame;
    private readonly IDisposable _subscription;

    public Decoder(IEncodedStream sourceStream)
    {
        SourceStream = sourceStream;
        _context = CreateDecoder(sourceStream);
        _frame = new();

        _decodedStream = DecodedStreamFactory.CreateDecodedStream(sourceStream);

        // subscribe
        _subscription = sourceStream.Subscribe(this);
    }

    public IEncodedStream SourceStream { get; }
    public IRawStream RawStream => _decodedStream;

    public void Dispose()
    {
        _subscription.Dispose();
        _frame.Dispose();
    }

    void IObserver<Packet>.OnCompleted() => _decodedStream.OnCompleted();
    void IObserver<Packet>.OnError(Exception error) => _decodedStream.OnError(error);
    void IObserver<Packet>.OnNext(Packet value)
    {
        try
        {
            ProcessPacket(value);
        }
        catch (Exception exception)
        {
            _decodedStream.OnError(exception);
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

            _decodedStream.OnNext(_frame.Ptr);
            _frame.UnRef();
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
