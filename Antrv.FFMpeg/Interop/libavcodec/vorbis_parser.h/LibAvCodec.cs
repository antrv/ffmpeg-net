namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// Allocate and initialize the Vorbis parser using headers in the extradata.
    /// </summary>
    /// <param name="extraData"></param>
    /// <param name="extraDataSize"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVVorbisParseContext> av_vorbis_parse_init(ConstPtr<byte> extraData, int extraDataSize);

    /// <summary>
    /// Free the parser and everything associated with it.
    /// </summary>
    /// <param name="s"></param>
    [DllImport(LibraryName)]
    public static extern void av_vorbis_parse_free(ref Ptr<AVVorbisParseContext> s);

    /// <summary>
    /// Get the duration for a Vorbis packet.
    /// If @p flags is @c NULL, special frames are considered invalid.
    /// </summary>
    /// <param name="s">Vorbis parser context</param>
    /// <param name="buf">buffer containing a Vorbis frame</param>
    /// <param name="bufSize">size of the buffer</param>
    /// <param name="flags">flags for special frames</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_vorbis_parse_frame_flags(Ptr<AVVorbisParseContext> s, ConstPtr<byte> buf, int bufSize,
        ref VorbisFlags flags);

    /// <summary>
    /// Get the duration for a Vorbis packet.
    /// </summary>
    /// <param name="s">Vorbis parser context</param>
    /// <param name="buf">buffer containing a Vorbis frame</param>
    /// <param name="bufSize">size of the buffer</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_vorbis_parse_frame(Ptr<AVVorbisParseContext> s, ConstPtr<byte> buf, int bufSize);

    [DllImport(LibraryName)]
    public static extern void av_vorbis_parse_reset(Ptr<AVVorbisParseContext> s);
}
