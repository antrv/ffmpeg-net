namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVGetEncodeBufferFlags
{
    None = 0,

    /// <summary>
    /// The encoder will keep a reference to the packet and may reuse it later.
    /// </summary>
    AV_GET_ENCODE_BUFFER_FLAG_REF = 1 << 0,
}
