namespace Antrv.FFMpeg.Interop;

public struct AVChapter
{
    /// <summary>
    /// Unique ID to identify the chapter.
    /// </summary>
    public long Id;

    /// <summary>
    /// Time base in which the start/end timestamps are specified.
    /// </summary>
    public AVRational TimeBase;

    /// <summary>
    /// Chapter start time in time_base units.
    /// </summary>
    public long Start;

    /// <summary>
    /// Chapter end time in time_base units.
    /// </summary>
    public long End;

    public Ptr<AVDictionary> Metadata;
}
