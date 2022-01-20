namespace Antrv.FFMpeg.Interop;

public struct RcOverride
{
    public int StartFrame;
    public int EndFrame;

    /// <summary>
    /// If this is 0 then quality_factor will be used instead.
    /// </summary>
    public int QScale;

    public float QualityFactor;
}
