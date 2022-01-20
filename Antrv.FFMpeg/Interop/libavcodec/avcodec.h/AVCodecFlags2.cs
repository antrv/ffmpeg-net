namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVCodecFlags2
{
    None = 0,

    /// <summary>
    /// Allow non spec compliant speedup tricks.
    /// </summary>
    AV_CODEC_FLAG2_FAST = 1 << 0,

    /// <summary>
    /// Skip bitstream encoding.
    /// </summary>
    AV_CODEC_FLAG2_NO_OUTPUT = 1 << 2,

    /// <summary>
    /// Place global headers at every keyframe instead of in extradata.
    /// </summary>
    AV_CODEC_FLAG2_LOCAL_HEADER = 1 << 3,

    /// <summary>
    /// timecode is in drop frame format. DEPRECATED!!!!
    /// </summary>
    [Obsolete] 
    AV_CODEC_FLAG2_DROP_FRAME_TIMECODE = 1 << 13,

    /// <summary>
    /// Input bitstream might be truncated at a packet boundaries instead of only at frame boundaries.
    /// </summary>
    AV_CODEC_FLAG2_CHUNKS = 1 << 15,

    /// <summary>
    /// Discard cropping information from SPS.
    /// </summary>
    AV_CODEC_FLAG2_IGNORE_CROP = 1 << 16,

    /// <summary>
    /// Show all frames before the first keyframe
    /// </summary>
    AV_CODEC_FLAG2_SHOW_ALL = 1 << 22,

    /// <summary>
    /// Export motion vectors through frame side data
    /// </summary>
    AV_CODEC_FLAG2_EXPORT_MVS = 1 << 28,

    /// <summary>
    /// Do not skip samples and export skip information as frame side data
    /// </summary>
    AV_CODEC_FLAG2_SKIP_MANUAL = 1 << 29,

    /// <summary>
    /// Do not reset ASS ReadOrder field on flush (subtitles decoding)
    /// </summary>
    AV_CODEC_FLAG2_RO_FLUSH_NOOP = 1 << 30,
}
