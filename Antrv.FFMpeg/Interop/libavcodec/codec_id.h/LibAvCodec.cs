namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// Get the type of the given codec.
    /// </summary>
    /// <param name="codecId"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVMediaType avcodec_get_type(AVCodecID codecId);

    /// <summary>
    /// Get the name of a codec.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>a static string identifying the codec; never NULL</returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr avcodec_get_name(AVCodecID id);

    /// <summary>
    /// Return codec bits per sample.
    /// </summary>
    /// <param name="codecId">the codec</param>
    /// <returns>Number of bits per sample or zero if unknown for the given codec.</returns>
    [DllImport(LibraryName)]
    public static extern int av_get_bits_per_sample(AVCodecID codecId);

    /// <summary>
    /// Return codec bits per sample.
    /// Only return non-zero if the bits per sample is exactly correct, not an approximation.
    /// </summary>
    /// <param name="codecId">the codec</param>
    /// <returns>Number of bits per sample or zero if unknown for the given codec.</returns>
    [DllImport(LibraryName)]
    public static extern int av_get_exact_bits_per_sample(AVCodecID codecId);

    /// <summary>
    /// Return a name for the specified profile, if available.
    ///
    /// unlike av_get_profile_name(), which searches a list of profiles
    /// supported by a specific decoder or encoder implementation, this
    /// function searches the list of profiles from the AVCodecDescriptor
    /// </summary>
    /// <param name="codecId">the ID of the codec to which the requested profile belongs</param>
    /// <param name="profile">the profile value for which a name is requested</param>
    /// <returns>A name for the profile if found, NULL otherwise.</returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr avcodec_profile_name(AVCodecID codecId, int profile);

    /// <summary>
    /// Return the PCM codec associated with a sample format.
    /// </summary>
    /// <param name="fmt"></param>
    /// <param name="be">endianness, 0 for little, 1 for big, -1 (or anything else) for native</param>
    /// <returns>AV_CODEC_ID_PCM_* or AV_CODEC_ID_NONE</returns>
    [DllImport(LibraryName)]
    public static extern AVCodecID av_get_pcm_codec(AVSampleFormat fmt, int be);
}
