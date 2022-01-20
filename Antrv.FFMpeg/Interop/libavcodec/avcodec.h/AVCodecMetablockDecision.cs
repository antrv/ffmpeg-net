namespace Antrv.FFMpeg.Interop;

public enum AVCodecMetablockDecision
{
    /// <summary>
    /// uses mb_cmp
    /// </summary>
    FF_MB_DECISION_SIMPLE = 0,

    /// <summary>
    /// chooses the one which needs the fewest bits
    /// </summary>
    FF_MB_DECISION_BITS = 1,

    /// <summary>
    /// rate distortion
    /// </summary>
    FF_MB_DECISION_RD = 2,
}
