using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public abstract class InputStream
{
    private protected InputStream(Ptr<AVStream> ptr)
    {
        ref AVCodecParameters codecParams = ref ptr.Ref.CodecParameters.Ref;

        Index = ptr.Ref.Index;
        MediaType = codecParams.CodecType;
        CodecId = codecParams.CodecId;
        Disposition = ptr.Ref.Disposition;
        TimeBase = ptr.Ref.TimeBase;

        StartTime = ptr.Ref.StartTime;
        StartTime2 = TimeSpan.FromTicks(TimeSpan.TicksPerSecond * TimeBase.Numerator /
            TimeBase.Denominator * StartTime);

        Duration = ptr.Ref.Duration;
        Duration2 = TimeSpan.FromTicks(TimeSpan.TicksPerSecond * TimeBase.Numerator /
            TimeBase.Denominator * Duration);

        Metadata = ptr.Ref.Metadata.ToImmutableDictionary();
    }

    public int Index { get; }
    public AVMediaType MediaType { get; }
    public AVCodecID CodecId { get; }
    public AVDisposition Disposition { get; }
    public AVRational TimeBase { get; }

    /// <summary>
    /// The time of the stream start in TimeBase units.
    /// </summary>
    public long StartTime { get; }

    /// <summary>
    /// The time of the stream start. May be inaccurate.
    /// </summary>
    public TimeSpan StartTime2 { get; }

    /// <summary>
    /// Duration of the stream in TimeBase units.
    /// </summary>
    public long Duration { get; }

    /// <summary>
    /// Duration of the stream. May be inaccurate.
    /// </summary>
    public TimeSpan Duration2 { get; }

    public ImmutableDictionary<string, string> Metadata { get; }

    internal static InputStream Create(Ptr<AVStream> ptr)
    {
        AVMediaType mediaType = ptr.Ref.CodecParameters.Ref.CodecType;
        InputStream stream = mediaType switch
        {
            AVMediaType.AVMEDIA_TYPE_VIDEO => new InputVideoStream(ptr),
            AVMediaType.AVMEDIA_TYPE_AUDIO => new InputAudioStream(ptr),
            AVMediaType.AVMEDIA_TYPE_SUBTITLE => new InputSubtitleStream(ptr),
            AVMediaType.AVMEDIA_TYPE_DATA => new InputDataStream(ptr),
            AVMediaType.AVMEDIA_TYPE_ATTACHMENT => new InputAttachmentStream(ptr),
            _ => new InputUnknownStream(ptr)
        };

        return stream;
    }
}

public abstract class InputStream<TParameters>: InputStream
{
    internal InputStream(Ptr<AVStream> ptr, TParameters parameters)
        : base(ptr)
    {
        Parameters = parameters;
    }

    public TParameters Parameters { get; }
}
