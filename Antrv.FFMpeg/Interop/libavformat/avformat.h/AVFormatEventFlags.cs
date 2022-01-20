namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVFormatEventFlags
{
    None = 0,

    /// <summary>
    /// - demuxing: the demuxer read new metadata from the file and updated
    ///   AVFormatContext.metadata accordingly
    /// - muxing: the user updated AVFormatContext.metadata and wishes the muxer to
    ///   write it into the file
    /// </summary>
    AVFMT_EVENT_FLAG_METADATA_UPDATED = 0x0001
}
