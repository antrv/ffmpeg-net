namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVBufferFlags
{
    None = 0,

    /// <summary>
    /// Always treat the buffer as read-only, even when it has only one reference.
    /// </summary>
    AV_BUFFER_FLAG_READONLY = 1 << 0,
}
