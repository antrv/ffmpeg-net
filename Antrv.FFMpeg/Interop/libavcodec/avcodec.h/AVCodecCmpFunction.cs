namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVCodecCmpFunction
{
    FF_CMP_SAD = 0,
    FF_CMP_SSE = 1,
    FF_CMP_SATD = 2,
    FF_CMP_DCT = 3,
    FF_CMP_PSNR = 4,
    FF_CMP_BIT = 5,
    FF_CMP_RD = 6,
    FF_CMP_ZERO = 7,
    FF_CMP_VSAD = 8,
    FF_CMP_VSSE = 9,
    FF_CMP_NSSE = 10,
    FF_CMP_W53 = 11,
    FF_CMP_W97 = 12,
    FF_CMP_DCTMAX = 13,
    FF_CMP_DCT264 = 14,
    FF_CMP_MEDIAN_SAD = 15,
    FF_CMP_CHROMA = 256,
}
