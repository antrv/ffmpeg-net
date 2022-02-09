using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model;

public sealed class Chapter
{
    public long Id { get; init; }

    /// <summary>
    /// Chapter start time in TimeBase units.
    /// </summary>
    public long StartTime { get; init; }

    /// <summary>
    /// Chapter start time. May be inaccurate.
    /// </summary>
    public TimeSpan StartTime2 => TimeUtils.ToTimeSpan(StartTime, TimeBase);

    /// <summary>
    /// Chapter end time in TimeBase units.
    /// </summary>
    public long EndTime { get; init; }

    /// <summary>
    /// Chapter end time. May be inaccurate.
    /// </summary>
    public TimeSpan EndTime2 => TimeUtils.ToTimeSpan(EndTime, TimeBase);

    public AVRational TimeBase { get; init; }

    public ImmutableDictionary<string, string> Metadata { get; init; } = ImmutableDictionary<string, string>.Empty;
}
