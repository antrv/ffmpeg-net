namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVPixelFormatFlags: ulong
{
    None = 0,

    /// <summary>
    /// Pixel format is big-endian.
    /// </summary>
    AV_PIX_FMT_FLAG_BE = 1 << 0,

    /// <summary>
    /// Pixel format has a palette in data[1], values are indexes in this palette.
    /// </summary>
    AV_PIX_FMT_FLAG_PAL = 1 << 1,

    /// <summary>
    /// All values of a component are bit-wise packed end to end.
    /// </summary>
    AV_PIX_FMT_FLAG_BITSTREAM = 1 << 2,

    /// <summary>
    /// Pixel format is an HW accelerated format.
    /// </summary>
    AV_PIX_FMT_FLAG_HWACCEL = 1 << 3,

    /// <summary>
    /// At least one pixel component is not in the first data plane.
    /// </summary>
    AV_PIX_FMT_FLAG_PLANAR = 1 << 4,

    /// <summary>
    /// The pixel format contains RGB-like data (as opposed to YUV/grayscale).
    /// </summary>
    AV_PIX_FMT_FLAG_RGB = 1 << 5,

    /// <summary>
    /// The pixel format has an alpha channel. This is set on all formats that
    /// support alpha in some way, including AV_PIX_FMT_PAL8. The alpha is always
    /// straight, never pre-multiplied.
    ///
    /// If a codec or a filter does not support alpha, it should set all alpha to
    /// opaque, or use the equivalent pixel formats without alpha component, e.g.
    /// AV_PIX_FMT_RGB0 (or AV_PIX_FMT_RGB24 etc.) instead of AV_PIX_FMT_RGBA.
    /// </summary>
    AV_PIX_FMT_FLAG_ALPHA = 1 << 7,

    /// <summary>
    /// The pixel format is following a Bayer pattern
    /// </summary>
    AV_PIX_FMT_FLAG_BAYER = 1 << 8,

    /// <summary>
    /// The pixel format contains IEEE-754 floating point values.
    /// Precision (double, single, or half) should be determined by the pixel size (64, 32, or 16 bits).
    /// </summary>
    AV_PIX_FMT_FLAG_FLOAT = 1 << 9,
}
