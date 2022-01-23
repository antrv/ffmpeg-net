using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class Chapter
{
    public long Id { get; init; }
    public long StartTime { get; init; }
    public TimeSpan StartTime2 { get; init; }
    public long EndTime { get; init; }
    public TimeSpan EndTime2 { get; init; }
    public AVRational TimeBase { get; init; }
    public ImmutableDictionary<string, string> Metadata { get; init; } = ImmutableDictionary<string, string>.Empty;
}
