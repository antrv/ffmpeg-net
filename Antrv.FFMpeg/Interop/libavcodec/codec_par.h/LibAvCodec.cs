namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// Allocate a new AVCodecParameters and set its fields to default values
    /// (unknown/invalid/0). The returned struct must be freed with avcodec_parameters_free().
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVCodecParameters> avcodec_parameters_alloc();

    /// <summary>
    /// Free an AVCodecParameters instance and everything associated with it and
    /// write NULL to the supplied pointer.
    /// </summary>
    /// <param name="par"></param>
    [DllImport(LibraryName)]
    public static extern void avcodec_parameters_free(ref Ptr<AVCodecParameters> par);

    /// <summary>
    /// Copy the contents of src to dst. Any allocated fields in dst are freed and
    /// replaced with newly allocated duplicates of the corresponding fields in src.
    /// </summary>
    /// <param name="dst"></param>
    /// <param name="src"></param>
    /// <returns>&gt;= 0 on success, a negative AVERROR code on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_parameters_copy(Ptr<AVCodecParameters> dst, ConstPtr<AVCodecParameters> src);

    /// <summary>
    /// This function is the same as av_get_audio_frame_duration(), except it works
    /// with AVCodecParameters instead of an AVCodecContext.
    /// </summary>
    /// <param name="par"></param>
    /// <param name="frameBytes"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_get_audio_frame_duration2(Ptr<AVCodecParameters> par, int frameBytes);
}
