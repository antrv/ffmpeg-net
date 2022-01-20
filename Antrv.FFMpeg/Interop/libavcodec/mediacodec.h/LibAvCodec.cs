namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// Allocate and initialize a MediaCodec context.
    ///
    /// When decoding with MediaCodec is finished, the caller must free the
    /// MediaCodec context with av_mediacodec_default_free.
    /// </summary>
    /// <returns>a pointer to a newly allocated AVMediaCodecContext on success, NULL otherwise</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVMediaCodecContext> av_mediacodec_alloc_context();

    /// <summary>
    /// Convenience function that sets up the MediaCodec context.
    /// </summary>
    /// <param name="codecCtx">codec context</param>
    /// <param name="ctx">MediaCodec context to initialize</param>
    /// <param name="surface">reference to an android/view/Surface</param>
    /// <returns>0 on success, negative otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_mediacodec_default_init(Ptr<AVCodecContext> codecCtx, Ptr<AVMediaCodecContext> ctx,
        IntPtr surface);

    /// <summary>
    /// This function must be called to free the MediaCodec context initialized with
    /// av_mediacodec_default_init().
    /// </summary>
    /// <param name="ctx">codec context</param>
    [DllImport(LibraryName)]
    public static extern void av_mediacodec_default_free(Ptr<AVCodecContext> ctx);

    /// <summary>
    /// Release a MediaCodec buffer and render it to the surface that is associated
    /// with the decoder. This function should only be called once on a given
    /// buffer, once released the underlying buffer returns to the codec, thus
    /// subsequent calls to this function will have no effect.
    /// </summary>
    /// <param name="buffer">the buffer to render</param>
    /// <param name="render">1 to release and render the buffer to the surface or 0 to discard the buffer</param>
    /// <returns>0 on success, negative otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_mediacodec_release_buffer(Ptr<AVMediaCodecBuffer> buffer, int render);

    /// <summary>
    /// Release a MediaCodec buffer and render it at the given time to the surface
    /// that is associated with the decoder. The timestamp must be within one second
    /// of the current java/lang/System#nanoTime() (which is implemented using
    /// CLOCK_MONOTONIC on Android). See the Android MediaCodec documentation
    /// of android/media/MediaCodec#releaseOutputBuffer(int,long) for more details.
    /// </summary>
    /// <param name="buffer">the buffer to render</param>
    /// <param name="time">timestamp in nanoseconds of when to render the buffer</param>
    /// <returns>0 on success, negative otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_mediacodec_render_buffer_at_time(Ptr<AVMediaCodecBuffer> buffer, long time);
}
