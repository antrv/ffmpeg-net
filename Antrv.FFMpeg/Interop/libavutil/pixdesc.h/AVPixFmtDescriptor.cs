using Antrv.FFMpeg.Types;

namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Descriptor that unambiguously describes how the bits of a pixel are
/// stored in the up to 4 data planes of an image. It also stores the
/// subsampling factors and number of components.
///
/// This is separate of the colorspace (RGB, YCbCr, YPbPr, JPEG-style YUV
/// and all the YUV variants) AVPixFmtDescriptor just stores how values
/// are stored not what these values represent.
/// </summary>
public struct AVPixFmtDescriptor
{
    public Utf8StringPtr Name;

    /// <summary>
    /// The number of components each pixel has, (1-4)
    /// </summary>
    public byte ComponentCount;

    /// <summary>
    /// Amount to shift the luma width right to find the chroma width.
    /// For YV12 this is 1 for example.
    /// chroma_width = AV_CEIL_RSHIFT(luma_width, log2_chroma_w)
    /// The note above is needed to ensure rounding up.
    /// This value only refers to the chroma components.
    /// </summary>
    public byte Log2ChromaW;

    /// <summary>
    /// Amount to shift the luma height right to find the chroma height.
    /// For YV12 this is 1 for example.
    /// chroma_height= AV_CEIL_RSHIFT(luma_height, log2_chroma_h)
    /// The note above is needed to ensure rounding up.
    /// This value only refers to the chroma components.
    /// </summary>
    public byte Log2ChromaH;

    /// <summary>
    /// Combination of AV_PIX_FMT_FLAG_... flags.
    /// </summary>
    public AVPixelFormatFlags Flags;

    /// <summary>
    /// Parameters that describe how pixels are packed.
    /// If the format has 1 or 2 components, then luma is 0.
    /// If the format has 3 or 4 components:
    ///   if the RGB flag is set then 0 is red, 1 is green and 2 is blue;
    ///   otherwise 0 is luma, 1 is chroma-U and 2 is chroma-V.
    /// 
    /// If present, the Alpha channel is always the last component.
    /// </summary>
    public Array4<AVComponentDescriptor> Components;

    /// <summary>
    /// Alternative comma-separated names.
    /// </summary>
    public Utf8StringPtr Alias;
}
