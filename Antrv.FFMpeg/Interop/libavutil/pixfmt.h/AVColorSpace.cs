namespace Antrv.FFMpeg.Interop;

/// <summary>
/// YUV colorspace type.
/// These values match the ones defined by ISO/IEC 23091-2_2019 subclause 8.3.
/// </summary>
public enum AVColorSpace
{
    /// <summary>
    /// order of coefficients is actually GBR, also IEC 61966-2-1 (sRGB), YZX and ST 428-1
    /// </summary>
    AVCOL_SPC_RGB = 0,

    /// <summary>
    /// also ITU-R BT1361 / IEC 61966-2-4 xvYCC709 / derived in SMPTE RP 177 Annex B
    /// </summary>
    AVCOL_SPC_BT709 = 1,
    AVCOL_SPC_UNSPECIFIED = 2,

    /// <summary>
    /// reserved for future use by ITU-T and ISO/IEC just like 15-255 are
    /// </summary>
    AVCOL_SPC_RESERVED = 3,

    /// <summary>
    /// FCC Title 47 Code of Federal Regulations 73.682 (a)(20)
    /// </summary>
    AVCOL_SPC_FCC = 4,

    /// <summary>
    /// also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL & SECAM / IEC 61966-2-4 xvYCC601
    /// </summary>
    AVCOL_SPC_BT470BG = 5,

    /// <summary>
    /// also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC / functionally identical to above
    /// </summary>
    AVCOL_SPC_SMPTE170M = 6,

    /// <summary>
    /// derived from 170M primaries and D65 white point, 170M is derived from BT470 System M's primaries
    /// </summary>
    AVCOL_SPC_SMPTE240M = 7,

    /// <summary>
    /// used by Dirac / VC-2 and H.264 FRext, see ITU-T SG16
    /// </summary>
    AVCOL_SPC_YCGCO = 8,
    AVCOL_SPC_YCOCG = AVCOL_SPC_YCGCO,

    /// <summary>
    /// ITU-R BT2020 non-constant luminance system
    /// </summary>
    AVCOL_SPC_BT2020_NCL = 9,

    /// <summary>
    /// ITU-R BT2020 constant luminance system
    /// </summary>
    AVCOL_SPC_BT2020_CL = 10,

    /// <summary>
    /// SMPTE 2085, Y'D'zD'x
    /// </summary>
    AVCOL_SPC_SMPTE2085 = 11,

    /// <summary>
    /// Chromaticity-derived non-constant luminance system
    /// </summary>
    AVCOL_SPC_CHROMA_DERIVED_NCL = 12,

    /// <summary>
    /// Chromaticity-derived constant luminance system
    /// </summary>
    AVCOL_SPC_CHROMA_DERIVED_CL = 13,

    /// <summary>
    /// ITU-R BT.2100-0, ICtCp
    /// </summary>
    AVCOL_SPC_ICTCP = 14,
}
