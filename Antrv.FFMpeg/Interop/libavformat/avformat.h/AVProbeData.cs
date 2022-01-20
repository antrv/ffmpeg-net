namespace Antrv.FFMpeg.Interop;

/// <summary>
/// This structure contains the data a format has to probe a file.
/// </summary>
public struct AVProbeData
{
    public Utf8StringPtr FileName;

    /// <summary>
    /// Buffer must have AVPROBE_PADDING_SIZE of extra allocated bytes filled with zero.
    /// </summary>
    public Ptr<byte> Buffer;

    /// <summary>
    /// Size of buf except extra allocated bytes
    /// </summary>
    public int BufferSize;

    /// <summary>
    /// mime_type, when known.
    /// </summary>
    public Utf8StringPtr MimeType;
}
