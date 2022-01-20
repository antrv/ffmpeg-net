namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Flags describing additional frame properties.
/// </summary>
[Flags]
public enum AVFrameFlags
{
    None = 0,
    /// <summary>
    /// The frame data may be corrupted, e.g. due to decoding errors.
    /// </summary>
    AV_FRAME_FLAG_CORRUPT = 1 << 0,

    /// <summary>
    /// A flag to mark the frames which need to be decoded, but shouldn't be output.
    /// </summary>
    AV_FRAME_FLAG_DISCARD = 1 << 2,
}
