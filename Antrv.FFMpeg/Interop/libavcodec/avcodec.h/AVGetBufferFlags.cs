namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVGetBufferFlags
{
    None = 0,

    /// <summary>
    /// The decoder will keep a reference to the frame and may reuse it later.
    /// </summary>
    AV_GET_BUFFER_FLAG_REF = 1 << 0,
}
