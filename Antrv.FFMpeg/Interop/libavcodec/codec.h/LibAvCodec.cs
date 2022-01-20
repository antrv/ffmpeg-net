namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// Iterate over all registered codecs.
    /// </summary>
    /// <param name="opaque">a pointer where libavcodec will store the iteration state. Must point to NULL to start the iteration.</param>
    /// <returns>the next registered codec or NULL when the iteration is finished</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodec> av_codec_iterate(ref IntPtr opaque);

    /// <summary>
    /// Find a registered decoder with a matching codec ID.
    /// </summary>
    /// <param name="id">AVCodecID of the requested decoder</param>
    /// <returns>A decoder if one was found, NULL otherwise.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodec> avcodec_find_decoder(AVCodecID id);

    /// <summary>
    /// Find a registered decoder with the specified name.
    /// </summary>
    /// <param name="name">name of the requested decoder</param>
    /// <returns>A decoder if one was found, NULL otherwise.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodec> avcodec_find_decoder_by_name(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Find a registered encoder with a matching codec ID.
    /// </summary>
    /// <param name="id">AVCodecID of the requested encoder</param>
    /// <returns>An encoder if one was found, NULL otherwise.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodec> avcodec_find_encoder(AVCodecID id);

    /// <summary>
    /// Find a registered encoder with the specified name.
    /// </summary>
    /// <param name="name">name of the requested encoder</param>
    /// <returns>An encoder if one was found, NULL otherwise.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodec> avcodec_find_encoder_by_name(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// </summary>
    /// <param name="codec"></param>
    /// <returns>a non-zero number if codec is an encoder, zero otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_codec_is_encoder(ConstPtr<AVCodec> codec);

    /// <summary>
    /// </summary>
    /// <param name="codec"></param>
    /// <returns>a non-zero number if codec is a decoder, zero otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_codec_is_decoder(ConstPtr<AVCodec> codec);

    /// <summary>
    /// Return a name for the specified profile, if available.
    /// </summary>
    /// <param name="codec">the codec that is searched for the given profile</param>
    /// <param name="profile">the profile value for which a name is requested</param>
    /// <returns>A name for the profile if found, NULL otherwise.</returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_get_profile_name(ConstPtr<AVCodec> codec, int profile);

    /// <summary>
    /// Retrieve supported hardware configurations for a codec.
    ///
    /// Values of index from zero to some maximum return the indexed configuration
    /// descriptor; all other values return NULL.  If the codec does not support
    /// any hardware configurations then it will always return NULL.
    /// </summary>
    /// <param name="codec"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodecHwConfig> avcodec_get_hw_config(ConstPtr<AVCodec> codec, int index);
}
