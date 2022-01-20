namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Flag is used to indicate which frame should be discarded after decoding.
/// </summary>
[Flags]
public enum AVIndexEntryFlags
{
    None = 0,
    AVINDEX_KEYFRAME = 0x0001,

    /// <summary>
    /// Flag is used to indicate which frame should be discarded after decoding.
    /// </summary>
    AVINDEX_DISCARD_FRAME = 0x0002
}
