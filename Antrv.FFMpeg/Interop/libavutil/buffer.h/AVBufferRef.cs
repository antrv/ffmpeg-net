namespace Antrv.FFMpeg.Interop;

/// <summary>
/// A reference to a data buffer.
///
/// The size of this struct is not a part of the public ABI and it is not meant
/// to be allocated directly.
/// </summary>
public struct AVBufferRef
{
    public Ptr<AVBuffer> Buffer;

    /// <summary>
    /// The data buffer. It is considered writable if and only if
    /// this is the only reference to the buffer, in which case
    /// av_buffer_is_writable() returns 1.
    /// </summary>
    public Ptr<byte> Data;

    /// <summary>
    /// Size of data in bytes.
    /// </summary>
    public nuint Size;
}
