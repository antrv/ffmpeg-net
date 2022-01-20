namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVFormatContextFlags
{
    None = 0,

    /// <summary>
    /// Signal that no header is present (streams are added dynamically).
    /// </summary>
    AVFMTCTX_NOHEADER = 0x0001,

    /// <summary>
    /// Signal that the stream is definitely not seekable,
    /// and attempts to call the seek function will fail.
    /// For some network protocols (e.g. HLS),
    /// this can change dynamically at runtime.
    /// </summary>
    AVFMTCTX_UNSEEKABLE = 0x0002,
}
