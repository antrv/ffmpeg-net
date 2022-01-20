namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVHWAccelFlags
{
    None = 0,

    /// <summary>
    /// Hardware acceleration should be used for decoding even if the codec level
    /// used is unknown or higher than the maximum supported level reported by the hardware driver.
    ///
    /// It's generally a good idea to pass this flag unless you have a specific
    /// reason not to, as hardware tends to under-report supported levels.
    /// </summary>
    AV_HWACCEL_FLAG_IGNORE_LEVEL = 1 << 0,

    /// <summary>
    /// Hardware acceleration can output YUV pixel formats with a different
    /// chroma sampling than 4:2:0 and/or other than 8 bits per component.
    /// </summary>
    AV_HWACCEL_FLAG_ALLOW_HIGH_DEPTH = 1 << 1,

    /// <summary>
    /// Hardware acceleration should still be attempted for decoding when the
    /// codec profile does not match the reported capabilities of the hardware.
    ///
    /// For example, this can be used to try to decode baseline profile H.264
    /// streams in hardware - it will often succeed, because many streams marked
    /// as baseline profile actually conform to constrained baseline profile.
    /// Warning: If the stream is actually not supported then the behaviour is
    /// undefined, and may include returning entirely incorrect output
    /// while indicating success.
    /// </summary>
    AV_HWACCEL_FLAG_ALLOW_PROFILE_MISMATCH = 1 << 2,
}
