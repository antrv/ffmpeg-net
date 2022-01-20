namespace Antrv.FFMpeg.Interop;

/// <summary>
/// This structure supplies correlation between a packet timestamp and a wall clock
/// production time. The definition follows the Producer Reference Time ('prft')
/// as defined in ISO/IEC 14496-12
/// </summary>
public struct AVProducerReferenceTime
{
    /// <summary>
    /// A UTC timestamp, in microseconds, since Unix epoch (e.g, av_gettime()).
    /// </summary>
    public long WallClock;
    public int Flags;
}
