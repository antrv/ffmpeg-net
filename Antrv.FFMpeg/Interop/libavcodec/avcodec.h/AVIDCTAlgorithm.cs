namespace Antrv.FFMpeg.Interop;

public enum AVIDCTAlgorithm
{
    FF_IDCT_AUTO = 0,
    FF_IDCT_INT = 1,
    FF_IDCT_SIMPLE = 2,
    FF_IDCT_SIMPLEMMX = 3,
    FF_IDCT_ARM = 7,
    FF_IDCT_ALTIVEC = 8,
    FF_IDCT_SIMPLEARM = 10,
    FF_IDCT_XVID = 14,
    FF_IDCT_SIMPLEARMV5TE = 16,
    FF_IDCT_SIMPLEARMV6 = 17,
    FF_IDCT_FAAN = 20,
    FF_IDCT_SIMPLENEON = 22,

    /// <summary>
    /// Used by XvMC to extract IDCT coefficients with FF_IDCT_PERM_NONE
    /// </summary>
    FF_IDCT_NONE = 24,
    FF_IDCT_SIMPLEAUTO = 128,
}
