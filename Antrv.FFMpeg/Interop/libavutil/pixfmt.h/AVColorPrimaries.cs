namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Chromaticity coordinates of the source primaries.
/// These values match the ones defined by ISO/IEC 23091-2_2019 subclause 8.1 and ITU-T H.273.
/// </summary>
public enum AVColorPrimaries
{
    AVCOL_PRI_RESERVED0 = 0,

    /// <summary>
    /// also ITU-R BT1361 / IEC 61966-2-4 / SMPTE RP 177 Annex B
    /// </summary>
    AVCOL_PRI_BT709 = 1,
    AVCOL_PRI_UNSPECIFIED = 2,
    AVCOL_PRI_RESERVED = 3,

    /// <summary>
    /// also FCC Title 47 Code of Federal Regulations 73.682 (a)(20)
    /// </summary>
    AVCOL_PRI_BT470M = 4,

    /// <summary>
    /// also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL & SECAM
    /// </summary>
    AVCOL_PRI_BT470BG = 5,

    /// <summary>
    /// also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC
    /// </summary>
    AVCOL_PRI_SMPTE170M = 6,

    /// <summary>
    /// identical to above, also called "SMPTE C" even though it uses D65
    /// </summary>
    AVCOL_PRI_SMPTE240M = 7,

    /// <summary>
    /// colour filters using Illuminant C
    /// </summary>
    AVCOL_PRI_FILM = 8,

    /// <summary>
    /// ITU-R BT2020
    /// </summary>
    AVCOL_PRI_BT2020 = 9,

    /// <summary>
    /// SMPTE ST 428-1 (CIE 1931 XYZ)
    /// </summary>
    AVCOL_PRI_SMPTE428 = 10,
    AVCOL_PRI_SMPTEST428_1 = AVCOL_PRI_SMPTE428,

    /// <summary>
    /// SMPTE ST 431-2 (2011) / DCI P3
    /// </summary>
    AVCOL_PRI_SMPTE431 = 11,

    /// <summary>
    /// SMPTE ST 432-1 (2010) / P3 D65 / Display P3
    /// </summary>
    AVCOL_PRI_SMPTE432 = 12,

    /// <summary>
    /// EBU Tech. 3213-E (nothing there) / one of JEDEC P22 group phosphors
    /// </summary>
    AVCOL_PRI_EBU3213 = 22,
    AVCOL_PRI_JEDEC_P22 = AVCOL_PRI_EBU3213,
}
