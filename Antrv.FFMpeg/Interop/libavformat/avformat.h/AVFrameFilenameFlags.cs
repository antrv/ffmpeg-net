namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVFrameFilenameFlags
{
    None = 0,

    /// <summary>
    /// Allow multiple %d
    /// </summary>
    AV_FRAME_FILENAME_FLAGS_MULTIPLE = 1
}
