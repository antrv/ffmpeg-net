namespace Antrv.FFMpeg.Interop;

/// <summary>
/// These flags can be passed in AVCodecContext.flags before initialization.
/// Note: Not everything is supported yet.
/// </summary>
[Flags]
public enum AVCodecFlags: uint
{
    None = 0,

    /// <summary>
    /// Allow decoders to produce frames with data planes that are not aligned
    /// to CPU requirements (e.g. due to cropping).
    /// </summary>
    AV_CODEC_FLAG_UNALIGNED = 1 << 0,

    /// <summary>
    /// Use fixed qscale.
    /// </summary>
    AV_CODEC_FLAG_QSCALE = 1 << 1,

    /// <summary>
    /// 4 MV per MB allowed / advanced prediction for H.263.
    /// </summary>
    AV_CODEC_FLAG_4MV = 1 << 2,

    /// <summary>
    /// Output even those frames that might be corrupted.
    /// </summary>
    AV_CODEC_FLAG_OUTPUT_CORRUPT = 1 << 3,

    /// <summary>
    /// Use qpel MC.
    /// </summary>
    AV_CODEC_FLAG_QPEL = 1 << 4,

    /// <summary>
    /// Don't output frames whose parameters differ from first
    /// decoded frame in stream.
    /// </summary>
    AV_CODEC_FLAG_DROPCHANGED = 1 << 5,

    /// <summary>
    /// Use internal 2pass ratecontrol in first pass mode.
    /// </summary>
    AV_CODEC_FLAG_PASS1 = 1 << 9,

    /// <summary>
    /// Use internal 2pass ratecontrol in second pass mode.
    /// </summary>
    AV_CODEC_FLAG_PASS2 = 1 << 10,

    /// <summary>
    /// loop filter.
    /// </summary>
    AV_CODEC_FLAG_LOOP_FILTER = 1 << 11,

    /// <summary>
    /// Only decode/encode grayscale.
    /// </summary>
    AV_CODEC_FLAG_GRAY = 1 << 13,

    /// <summary>
    /// error[?] variables will be set during encoding.
    /// </summary>
    AV_CODEC_FLAG_PSNR = 1 << 15,

    /// <summary>
    /// Input bitstream might be truncated at a random location
    /// instead of only at frame boundaries.
    /// </summary>
    [Obsolete("use codec parsers for packetizing input")]
    AV_CODEC_FLAG_TRUNCATED = 1 << 16,

    /// <summary>
    /// Use interlaced DCT.
    /// </summary>
    AV_CODEC_FLAG_INTERLACED_DCT = 1 << 18,

    /// <summary>
    /// Force low delay.
    /// </summary>
    AV_CODEC_FLAG_LOW_DELAY = 1 << 19,

    /// <summary>
    /// Place global headers in extradata instead of every keyframe.
    /// </summary>
    AV_CODEC_FLAG_GLOBAL_HEADER = 1 << 22,

    /// <summary>
    /// Use only bitexact stuff (except (I)DCT).
    /// </summary>
    AV_CODEC_FLAG_BITEXACT = 1 << 23,

    /// <summary>
    /// Fx : Flag for H.263+ extra options
    /// H.263 advanced intra coding / MPEG-4 AC prediction
    /// </summary>
    AV_CODEC_FLAG_AC_PRED = 1 << 24,

    /// <summary>
    /// interlaced motion estimation
    /// </summary>
    AV_CODEC_FLAG_INTERLACED_ME = 1 << 29,
    AV_CODEC_FLAG_CLOSED_GOP = 1u << 31,
}
