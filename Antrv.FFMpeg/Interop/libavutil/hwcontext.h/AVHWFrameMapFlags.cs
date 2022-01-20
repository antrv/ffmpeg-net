namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Flags to apply to frame mappings.
/// </summary>
public enum AVHWFrameMapFlags
{
    None = 0,

    /// <summary>
    /// The mapping must be readable.
    /// </summary>
    AV_HWFRAME_MAP_READ = 1 << 0,

    /// <summary>
    /// The mapping must be writeable.
    /// </summary>
    AV_HWFRAME_MAP_WRITE = 1 << 1,

    /// <summary>
    /// The mapped frame will be overwritten completely in subsequent
    /// operations, so the current frame data need not be loaded.  Any values
    /// which are not overwritten are unspecified.
    /// </summary>
    AV_HWFRAME_MAP_OVERWRITE = 1 << 2,

    /// <summary>
    /// The mapping must be direct.  That is, there must not be any copying in
    /// the map or unmap steps.  Note that performance of direct mappings may
    /// be much lower than normal memory.
    /// </summary>
    AV_HWFRAME_MAP_DIRECT = 1 << 3,
}
