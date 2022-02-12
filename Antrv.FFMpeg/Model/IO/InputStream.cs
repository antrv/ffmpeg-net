using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Codecs;
using Antrv.FFMpeg.Model.Processing;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputStream: IEncodedStream
{
    private readonly ObserverManager<Packet> _manager;
    private readonly CodecParameters _codecParameters;

    internal InputStream(InputSource source, Ptr<AVStream> ptr)
    {
        _manager = new(OnSubscribed, OnUnsubscribed);

        Ptr = ptr;
        Source = source;

        ref AVCodecParameters codecParams = ref ptr.Ref.CodecParameters.Ref;
        Parameters = StreamParametersFactory.CreateStreamParameters(codecParams);
        _codecParameters = new(ptr.Ref.CodecParameters);

        Index = ptr.Ref.Index;
        MediaType = codecParams.CodecType;
        Codec = Global.Codecs[codecParams.CodecId];
        Disposition = ptr.Ref.Disposition;
        TimeBase = ptr.Ref.TimeBase;

        StartTime = ptr.Ref.StartTime;
        Duration = ptr.Ref.Duration == long.MinValue ? null : ptr.Ref.Duration;

        Metadata = ptr.Ref.Metadata.ToImmutableDictionary();

        // Initially all data from the stream is discarded.
        // This flag is changed when observers are attached.
        ptr.Ref.Discard = AVDiscard.AVDISCARD_ALL;
    }

    public InputSource Source { get; }
    internal Ptr<AVStream> Ptr { get; }

    public int Index { get; }
    public AVMediaType MediaType { get; }
    public Codec Codec { get; }
    CodecParameters IEncodedStream.CodecParameters => _codecParameters;

    public AVDisposition Disposition { get; }
    public AVRational TimeBase { get; }
    public StreamParameters Parameters { get; }

    /// <summary>
    /// The time of the stream start in TimeBase units.
    /// </summary>
    public long StartTime { get; }

    /// <summary>
    /// The time of the stream start. May be inaccurate.
    /// </summary>
    public TimeSpan StartTime2 => TimeUtils.ToTimeSpan(StartTime, TimeBase);

    /// <summary>
    /// Duration of the stream in TimeBase units.
    /// </summary>
    public long? Duration { get; }

    /// <summary>
    /// Duration of the stream. May be inaccurate.
    /// </summary>
    public TimeSpan? Duration2 => Duration is null ? null : TimeUtils.ToTimeSpan(Duration.Value, TimeBase);

    public ImmutableDictionary<string, string> Metadata { get; }

    public IDisposable Subscribe(IObserver<Packet> observer) => _manager.Subscribe(observer);

    internal void Completed() => _manager.Completed();
    internal void Error(Exception exception) => _manager.Error(exception);
    internal void Next(Packet packet) => _manager.Next(packet);
    
    private void OnSubscribed(IObserver<Packet> observer)
    {
        // If the stream has subscribers, the packets from the stream must not be discarded.
        Ptr.Ref.Discard = AVDiscard.AVDISCARD_DEFAULT;
    }

    private void OnUnsubscribed(IObserver<Packet> observer)
    {
        // If the stream has no subscribers, the packets from the stream are not needed.
        if (_manager.HasNoSubscribers)
            Ptr.Ref.Discard = AVDiscard.AVDISCARD_ALL;
    }
}
