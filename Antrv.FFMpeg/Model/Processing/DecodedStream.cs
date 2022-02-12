using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

internal abstract class DecodedStream: IRawStream
{
    private readonly ObserverManager<DecodedPacket> _manager;

    private protected DecodedStream(IEncodedStream stream)
    {
        _manager = new();
        Stream = stream;
    }

    public IEncodedStream Stream { get; }
    public StreamParameters Parameters => Stream.Parameters;
    public AVMediaType MediaType => Stream.MediaType;
    public AVRational TimeBase => Stream.TimeBase;
    public IDisposable Subscribe(IObserver<DecodedPacket> observer) => _manager.Subscribe(observer);
    internal virtual void OnCompleted() => _manager.Completed();
    internal virtual void OnError(Exception error) => _manager.Error(error);
    internal virtual void OnNext(Ptr<AVFrame> value) => _manager.Next(new(this, value));
}

internal abstract class DecodedStream<TParameters, TFrame>: DecodedStream
    where TParameters: StreamParameters
    where TFrame: struct, IFrame
{
    private readonly ObserverManager<TFrame> _manager;

    private protected DecodedStream(IEncodedStream stream)
        : base(stream)
    {
        _manager = new();
        Parameters = (TParameters)stream.Parameters;
    }

    public new TParameters Parameters { get; }
    public IDisposable Subscribe(IObserver<TFrame> observer) => _manager.Subscribe(observer);

    internal override void OnCompleted()
    {
        base.OnCompleted();
        _manager.Completed();
    }

    internal override void OnError(Exception error)
    {
        base.OnError(error);
        _manager.Error(error);
    }

    internal override void OnNext(Ptr<AVFrame> value)
    {
        base.OnNext(value);
        _manager.Next(CreateFrame(value));
    }

    private protected abstract TFrame CreateFrame(Ptr<AVFrame> ptr);
}