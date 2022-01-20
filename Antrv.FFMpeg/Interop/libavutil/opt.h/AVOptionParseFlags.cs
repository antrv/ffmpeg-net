namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVOptionParseFlags
{
    None = 0,

    /// <summary>
    /// Accept to parse a value without a key; the key will then be returned as NULL.
    /// </summary>
    AV_OPT_FLAG_IMPLICIT_KEY = 1,
}
