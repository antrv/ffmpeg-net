namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVCodecSliceFlags
{
    None = 0,

    /// <summary>
    /// draw_horiz_band() is called in coded order instead of display
    /// </summary>
    SLICE_FLAG_CODED_ORDER = 0x0001,

    /// <summary>
    /// allow draw_horiz_band() with field slices (MPEG-2 field pics)
    /// </summary>
    SLICE_FLAG_ALLOW_FIELD = 0x0002,

    /// <summary>
    /// allow draw_horiz_band() with 1 component at a time (SVQ1)
    /// </summary>
    SLICE_FLAG_ALLOW_PLANE = 0x0004,
}
