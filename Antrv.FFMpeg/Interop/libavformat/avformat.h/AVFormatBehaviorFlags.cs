namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Flags modifying the (de)muxer behaviour.
/// </summary>
[Flags]
public enum AVFormatBehaviorFlags
{
    None = 0,

    /// <summary>
    /// Generate missing pts even if it requires parsing future frames.
    /// </summary>
    AVFMT_FLAG_GENPTS = 0x0001,

    /// <summary>
    /// Ignore index.
    /// </summary>
    AVFMT_FLAG_IGNIDX = 0x0002,

    /// <summary>
    /// Do not block when reading packets from input.
    /// </summary>
    AVFMT_FLAG_NONBLOCK = 0x0004,

    /// <summary>
    /// Ignore DTS on frames that contain both DTS & PTS.
    /// </summary>
    AVFMT_FLAG_IGNDTS = 0x0008,

    /// <summary>
    /// Do not infer any values from other values, just return what is stored in the container.
    /// </summary>
    AVFMT_FLAG_NOFILLIN = 0x0010,

    /// <summary>
    /// Do not use AVParsers, you also must set AVFMT_FLAG_NOFILLIN as the fillin code works on frames and no parsing -> no frames.
    /// Also seeking to frames can not work if parsing to find frame boundaries has been disabled.
    /// </summary>
    AVFMT_FLAG_NOPARSE = 0x0020,

    /// <summary>
    /// Do not buffer frames when possible.
    /// </summary>
    AVFMT_FLAG_NOBUFFER = 0x0040,

    /// <summary>
    /// The caller has supplied a custom AVIOContext, don't avio_close() it.
    /// </summary>
    AVFMT_FLAG_CUSTOM_IO = 0x0080,

    /// <summary>
    /// Discard frames marked corrupted.
    /// </summary>
    AVFMT_FLAG_DISCARD_CORRUPT = 0x0100,

    /// <summary>
    /// Flush the AVIOContext every packet.
    /// When muxing, try to avoid writing any random/volatile data to the output.
    /// This includes any random IDs, real-time timestamps/dates, muxer version, etc.
    /// </summary>
    AVFMT_FLAG_FLUSH_PACKETS = 0x0200,

    /// <summary>
    /// This flag is mainly intended for testing.
    /// </summary>
    AVFMT_FLAG_BITEXACT = 0x0400,

    /// <summary>
    /// Try to interleave outputted packets by dts (using this flag can slow demuxing down).
    /// </summary>
    AVFMT_FLAG_SORT_DTS = 0x10000,

    /// <summary>
    /// Enable use of private options by delaying codec open (deprecated, does nothing)
    /// </summary>
    [Obsolete("Deprecated, does nothing.")]
    AVFMT_FLAG_PRIV_OPT = 0x20000,

    /// <summary>
    /// Enable fast, but inaccurate seeks for some formats.
    /// </summary>
    AVFMT_FLAG_FAST_SEEK = 0x80000,

    /// <summary>
    /// Stop muxing when the shortest stream stops.
    /// </summary>
    AVFMT_FLAG_SHORTEST = 0x100000,

    /// <summary>
    /// Add bitstream filters as requested by the muxer.
    /// </summary>
    AVFMT_FLAG_AUTO_BSF = 0x200000,
}
