namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVOptionSerializeFlags
{
    None = 0,

    /// <summary>
    /// Serialize options that are not set to default values only.
    /// </summary>
    AV_OPT_SERIALIZE_SKIP_DEFAULTS = 0x00000001,

    /// <summary>
    /// Serialize options that exactly match opt_flags only.
    /// </summary>
    AV_OPT_SERIALIZE_OPT_FLAGS_EXACT = 0x00000002,
}
