namespace Antrv.FFMpeg.Interop;

[Flags]
public enum SwScaleFlags
{
    None = 0,
    SWS_FAST_BILINEAR = 1,
    SWS_BILINEAR = 2,
    SWS_BICUBIC = 4,
    SWS_X = 8,
    SWS_POINT = 0x10,
    SWS_AREA = 0x20,
    SWS_BICUBLIN = 0x40,
    SWS_GAUSS = 0x80,
    SWS_SINC = 0x100,
    SWS_LANCZOS = 0x200,
    SWS_SPLINE = 0x400,

    // TODO: unclear whether the following options must be here
    SWS_PRINT_INFO = 0x1000,

    // the following 3 flags are not completely implemented
    /// <summary>
    /// internal chrominance subsampling info
    /// </summary>
    SWS_FULL_CHR_H_INT = 0x2000,

    /// <summary>
    /// input subsampling info
    /// </summary>
    SWS_FULL_CHR_H_INP = 0x4000,
    SWS_DIRECT_BGR = 0x8000,
    SWS_ACCURATE_RND = 0x40000,
    SWS_BITEXACT = 0x80000,
    SWS_ERROR_DIFFUSION = 0x800000,
}
