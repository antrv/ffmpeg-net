namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVStreamEventFlags
{
    None = 0,

    /// <summary>
    /// - demuxing: the demuxer read new metadata from the file and updated AVStream.metadata accordingly
    /// - muxing: the user updated AVStream.metadata and wishes the muxer to write it into the file
    /// </summary>
    AVSTREAM_EVENT_FLAG_METADATA_UPDATED = 1 << 0,

    /// <summary>
    /// - demuxing: new packets for this stream were read from the file. This
    ///   event is informational only and does not guarantee that new packets
    ///   for this stream will necessarily be returned from av_read_frame().
    /// </summary>
    AVSTREAM_EVENT_FLAG_NEW_PACKETS = 1 << 1,
}
