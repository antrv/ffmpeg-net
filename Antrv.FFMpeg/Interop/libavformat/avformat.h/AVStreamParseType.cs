namespace Antrv.FFMpeg.Interop;

public enum AVStreamParseType
{
    AVSTREAM_PARSE_NONE,

    /// <summary>
    /// full parsing and repack
    /// </summary>
    AVSTREAM_PARSE_FULL,

    /// <summary>
    /// Only parse headers, do not repack.
    /// </summary>
    AVSTREAM_PARSE_HEADERS,

    /// <summary>
    /// full parsing and interpolation of timestamps for frames not starting on a packet boundary
    /// </summary>
    AVSTREAM_PARSE_TIMESTAMPS,

    /// <summary>
    /// full parsing and repack of the first frame only, only implemented for H.264 currently
    /// </summary>
    AVSTREAM_PARSE_FULL_ONCE,

    /// <summary>
    /// full parsing and repack with timestamp and position generation by parser for raw
    /// this assumes that each packet in the file contains no demuxer level headers and
    /// just codec level data, otherwise position generation would fail
    /// </summary>
    AVSTREAM_PARSE_FULL_RAW,
}
