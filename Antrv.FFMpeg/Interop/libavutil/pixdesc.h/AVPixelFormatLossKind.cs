namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Kind of losses will occur when converting from one specific
/// pixel format to another.
/// </summary>
[Flags]
public enum AVPixelFormatLossKind
{
    None = 0,

    /// <summary>
    /// loss due to resolution change
    /// </summary>
    FF_LOSS_RESOLUTION = 0x0001,

    /// <summary>
    /// loss due to color depth change
    /// </summary>
    FF_LOSS_DEPTH = 0x0002,

    /// <summary>
    /// loss due to color space conversion
    /// </summary>
    FF_LOSS_COLORSPACE = 0x0004,

    /// <summary>
    /// loss of alpha bits
    /// </summary>
    FF_LOSS_ALPHA = 0x0008,

    /// <summary>
    /// loss due to color quantization
    /// </summary>
    FF_LOSS_COLORQUANT = 0x0010,

    /// <summary>
    /// loss of chroma (e.g. RGB to gray conversion)
    /// </summary>
    FF_LOSS_CHROMA = 0x0020,
}
