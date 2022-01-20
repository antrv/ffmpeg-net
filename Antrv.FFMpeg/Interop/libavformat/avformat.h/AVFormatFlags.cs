namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVFormatFlags
{
    /// <summary>
    /// Demuxer will use avio_open, no opened file should be provided by the caller.
    /// </summary>
    AVFMT_NOFILE = 0x0001,

    /// <summary>
    /// Needs '%d' in filename.
    /// </summary>
    AVFMT_NEEDNUMBER = 0x0002,

    /// <summary>
    /// The muxer/demuxer is experimental and should be used with caution.
    /// - demuxers: will not be selected automatically by probing, must be specified explicitly.
    /// </summary>
    AVFMT_EXPERIMENTAL = 0x0004,

    /// <summary>
    /// Show format stream IDs numbers.
    /// </summary>
    AVFMT_SHOW_IDS = 0x0008,

    /// <summary>
    /// Format wants global header.
    /// </summary>
    AVFMT_GLOBALHEADER = 0x0040,

    /// <summary>
    /// Format does not need / have any timestamps.
    /// </summary>
    AVFMT_NOTIMESTAMPS = 0x0080,

    /// <summary>
    /// Use generic index building code.
    /// </summary>
    AVFMT_GENERIC_INDEX = 0x0100,

    /// <summary>
    /// Format allows timestamp discontinuities. Note, muxers always require valid (monotone) timestamps.
    /// </summary>
    AVFMT_TS_DISCONT = 0x0200,

    /// <summary>
    /// Format allows variable fps.
    /// </summary>
    AVFMT_VARIABLE_FPS = 0x0400,

    /// <summary>
    /// Format does not need width/height.
    /// </summary>
    AVFMT_NODIMENSIONS = 0x0800,

    /// <summary>
    /// Format does not require any streams.
    /// </summary>
    AVFMT_NOSTREAMS = 0x1000,

    /// <summary>
    /// Format does not allow to fall back on binary search via read_timestamp.
    /// </summary>
    AVFMT_NOBINSEARCH = 0x2000,

    /// <summary>
    /// Format does not allow to fall back on generic search.
    /// </summary>
    AVFMT_NOGENSEARCH = 0x4000,

    /// <summary>
    /// Format does not allow seeking by bytes.
    /// </summary>
    AVFMT_NO_BYTE_SEEK = 0x8000,

    /// <summary>
    /// Format allows flushing. If not set, the muxer will not receive a NULL packet in the write_packet function.
    /// </summary>
    AVFMT_ALLOW_FLUSH = 0x10000,

    /// <summary>
    /// Format does not require strictly increasing timestamps, but they must still be monotonic.
    /// </summary>
    AVFMT_TS_NONSTRICT = 0x20000,

    /// <summary>
    /// Format allows muxing negative timestamps. If not set the timestamp will be shifted in av_write_frame
    /// and av_interleaved_write_frame so they start from 0.
    /// The user or muxer can override this through AVFormatContext.avoid_negative_ts.
    /// </summary>
    AVFMT_TS_NEGATIVE = 0x40000,

    /// <summary>
    /// Seeking is based on PTS.
    /// </summary>
    AVFMT_SEEK_TO_PTS = 0x4000000,
}
