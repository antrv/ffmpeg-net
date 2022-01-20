namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVIOSeekableFlags
{
    None = 0,

    /// <summary>
    /// Seeking works like for a local file.
    /// </summary>
    AVIO_SEEKABLE_NORMAL = 1 << 0,

    /// <summary>
    /// Seeking by timestamp with avio_seek_time() is possible.
    /// </summary>
    AVIO_SEEKABLE_TIME = 1 << 1,
}
