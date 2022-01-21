namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Resampling engine
/// </summary>
public enum SwrEngine
{
    /// <summary>
    /// SW Resampler
    /// </summary>
    SWR_ENGINE_SWR,

    /// <summary>
    /// SoX Resampler
    /// </summary>
    SWR_ENGINE_SOXR,
}
