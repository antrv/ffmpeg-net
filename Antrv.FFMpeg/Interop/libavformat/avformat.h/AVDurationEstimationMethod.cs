namespace Antrv.FFMpeg.Interop;

public enum AVDurationEstimationMethod
{
    /// <summary>
    /// Duration accurately estimated from PTSes
    /// </summary>
    AVFMT_DURATION_FROM_PTS,

    /// <summary>
    /// Duration estimated from a stream with a known duration
    /// </summary>
    AVFMT_DURATION_FROM_STREAM,

    /// <summary>
    /// Duration estimated from bitrate (less accurate)
    /// </summary>
    AVFMT_DURATION_FROM_BITRATE
}
