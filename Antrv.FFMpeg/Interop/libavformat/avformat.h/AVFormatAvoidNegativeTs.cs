namespace Antrv.FFMpeg.Interop;

public enum AVFormatAvoidNegativeTs
{
    /// <summary>
    /// Enabled when required by target format
    /// </summary>
    AVFMT_AVOID_NEG_TS_AUTO = -1,

    /// <summary>
    /// Shift timestamps so they are non negative
    /// </summary>
    AVFMT_AVOID_NEG_TS_MAKE_NON_NEGATIVE = 1,

    /// <summary>
    /// Shift timestamps so that they start at 0
    /// </summary>
    AVFMT_AVOID_NEG_TS_MAKE_ZERO = 2
}
