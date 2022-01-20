namespace Antrv.FFMpeg.Interop;

public enum AVStandardCompliance
{
    /// <summary>
    /// Strictly conform to an older more strict version of the spec or reference software.
    /// </summary>
    VeryStrict = 2,

    /// <summary>
    /// Strictly conform to all the things in the spec no matter what consequences.
    /// </summary>
    Strict = 1,
    Normal = 0,

    /// <summary>
    /// Allow unofficial extensions
    /// </summary>
    Unofficial = -1,

    /// <summary>
    /// Allow non-standardized experimental things.
    /// </summary>
    Experimental = -2,
}
