namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Options for behavior on timestamp wrap detection.
/// </summary>
public enum AVPTSWrap
{
    /// <summary>
    /// ignore the wrap
    /// </summary>
    AV_PTS_WRAP_IGNORE = 0,

    /// <summary>
    /// add the format specific offset on wrap detection
    /// </summary>
    AV_PTS_WRAP_ADD_OFFSET = 1,

    /// <summary>
    /// subtract the format specific offset on wrap detection
    /// </summary>
    AV_PTS_WRAP_SUB_OFFSET = -1,
}
