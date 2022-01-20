namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    public const int AV_INPUT_BUFFER_PADDING_SIZE = 64;

    /// <summary>
    /// Allocate a CPB properties structure and initialize its fields to default values.
    /// </summary>
    /// <param name="size">if non-NULL, the size of the allocated struct will be written
    /// here. This is useful for embedding it in side data.</param>
    /// <returns>the newly allocated struct or NULL on failure</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVCPBProperties> av_cpb_properties_alloc(out nuint size);

    /// <summary>
    /// Encode extradata length to a buffer. Used by xiph codecs.
    /// </summary>
    /// <param name="s">buffer to write to; must be at least (v/255+1) bytes long</param>
    /// <param name="v">size of extradata in bytes</param>
    /// <returns>number of bytes written to the buffer.</returns>
    [DllImport(LibraryName)]
    public static extern uint av_xiphlacing(Ptr<byte> s, uint v);
}
