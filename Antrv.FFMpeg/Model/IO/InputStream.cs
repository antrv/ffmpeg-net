using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Codecs;
using Antrv.FFMpeg.Model.Streams;

namespace Antrv.FFMpeg.Model.IO;

public abstract class InputStream: IEncodedStream
{
    private protected InputStream(Ptr<AVStream> ptr)
    {
        ref AVCodecParameters codecParams = ref ptr.Ref.CodecParameters.Ref;

        Index = ptr.Ref.Index;
        MediaType = codecParams.CodecType;
        Codec = Global.Codecs[codecParams.CodecId];
        Disposition = ptr.Ref.Disposition;
        TimeBase = ptr.Ref.TimeBase;

        StartTime = ptr.Ref.StartTime;
        Duration = ptr.Ref.Duration == long.MinValue ? null : ptr.Ref.Duration;

        Metadata = ptr.Ref.Metadata.ToImmutableDictionary();
    }

    public int Index { get; }
    public AVMediaType MediaType { get; }
    public Codec Codec { get; }
    public AVDisposition Disposition { get; }
    public AVRational TimeBase { get; }
    public abstract StreamParameters Parameters { get; }

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

    internal static InputStream Create(Ptr<AVStream> ptr)
    {
        AVMediaType mediaType = ptr.Ref.CodecParameters.Ref.CodecType;
        InputStream stream = mediaType switch
        {
            AVMediaType.Video => new InputVideoStream(ptr),
            AVMediaType.Audio => new InputAudioStream(ptr),
            AVMediaType.Subtitle => new InputSubtitleStream(ptr),
            AVMediaType.Data => new InputDataStream(ptr),
            AVMediaType.Attachment => new InputAttachmentStream(ptr),
            _ => new InputUnknownStream(ptr)
        };

        return stream;
    }
}

public abstract class InputStream<TParameters>: InputStream
    where TParameters: StreamParameters
{
    private protected InputStream(Ptr<AVStream> ptr, TParameters parameters)
        : base(ptr)
    {
        Parameters = parameters;
    }

    public override TParameters Parameters { get; }
}
