namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Return the name of <paramref name="sampleFormat"/>, or NULL if <paramref name="sampleFormat"/> is not recognized.
    /// </summary>
    /// <param name="sampleFormat"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_get_sample_fmt_name(AVSampleFormat sampleFormat);

    /// <summary>
    /// Return a sample format corresponding to name, or <see cref="AVSampleFormat.AV_SAMPLE_FMT_NONE"/> on error.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVSampleFormat av_get_sample_fmt([MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    /// <summary>
    /// Return the planar<->packed alternative form of the given sample format, or AV_SAMPLE_FMT_NONE on error.
    /// If the passed sample_fmt is already in the
    /// requested planar/packed format, the format returned is the same as the input.
    /// </summary>
    /// <param name="sampleFormat"></param>
    /// <param name="planar"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVSampleFormat av_get_alt_sample_fmt(AVSampleFormat sampleFormat, int planar);

    /// <summary>
    /// Get the packed alternative form of the given sample format.
    ///
    /// If the passed sample_fmt is already in packed format, the format returned is the same as the input.
    /// </summary>
    /// <param name="sampleFormat"></param>
    /// <returns>the packed alternative form of the given sample format or AV_SAMPLE_FMT_NONE on error.</returns>
    [DllImport(LibraryName)]
    public static extern AVSampleFormat av_get_packed_sample_fmt(AVSampleFormat sampleFormat);

    /// <summary>
    /// Get the planar alternative form of the given sample format.
    ///
    /// If the passed sample_fmt is already in planar format, the format returned is
    /// the same as the input.
    /// </summary>
    /// <param name="sampleFormat"></param>
    /// <returns>the planar alternative form of the given sample format or AV_SAMPLE_FMT_NONE on error.</returns>
    [DllImport(LibraryName)]
    public static extern AVSampleFormat av_get_planar_sample_fmt(AVSampleFormat sampleFormat);

    /// <summary>
    /// Generate a string corresponding to the sample format with
    /// sample_fmt, or a header if sample_fmt is negative.
    /// </summary>
    /// <param name="buf">the buffer where to write the string</param>
    /// <param name="bufSize">the size of buf</param>
    /// <param name="sampleFormat">the number of the sample format to print the corresponding info string,
    /// or a negative value to print the corresponding header.</param>
    /// <returns>the pointer to the filled buffer or NULL if sample_fmt is unknown or in case of other errors</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<byte> av_get_sample_fmt_string(Ptr<byte> buf, int bufSize, AVSampleFormat sampleFormat);

    /// <summary>
    /// Return number of bytes per sample.
    /// </summary>
    /// <param name="sampleFormat">the sample format</param>
    /// <returns>number of bytes per sample or zero if unknown for the given sample format</returns>
    [DllImport(LibraryName)]
    public static extern int av_get_bytes_per_sample(AVSampleFormat sampleFormat);

    /// <summary>
    /// Check if the sample format is planar.
    /// </summary>
    /// <param name="sampleFormat">the sample format to inspect</param>
    /// <returns>1 if the sample format is planar, 0 if it is interleaved</returns>
    [DllImport(LibraryName)]
    public static extern int av_sample_fmt_is_planar(AVSampleFormat sampleFormat);

    /// <summary>
    /// Get the required buffer size for the given audio parameters.
    /// </summary>
    /// <param name="lineSize">calculated linesize, may be NULL</param>
    /// <param name="channels">the number of channels</param>
    /// <param name="samples">the number of samples in a single channel</param>
    /// <param name="sampleFormat">the sample format</param>
    /// <param name="align">buffer size alignment (0 = default, 1 = no alignment)</param>
    /// <returns>required buffer size, or negative error code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_samples_get_buffer_size(out int lineSize, int channels, int samples,
        AVSampleFormat sampleFormat, int align);

    /// <summary>
    /// Fill plane data pointers and linesize for samples with sample format sample_fmt.
    ///
    /// The audio_data array is filled with the pointers to the samples data planes:
    /// for planar, set the start point of each channel's data within the buffer,
    /// for packed, set the start point of the entire buffer only.
    ///
    /// The value pointed to by linesize is set to the aligned size of each
    /// channel's data buffer for planar layout, or to the aligned size of the
    /// buffer for all channels for packed layout.
    ///
    /// The buffer in buf must be big enough to contain all the samples
    /// (use av_samples_get_buffer_size() to compute its minimum size),
    /// otherwise the audio_data pointers will point to invalid data.
    ///
    /// @see enum AVSampleFormat
    /// The documentation for AVSampleFormat describes the data layout.
    /// </summary>
    /// <param name="audioData">array to be filled with the pointer for each channel</param>
    /// <param name="lineSize">calculated linesize, may be NULL</param>
    /// <param name="buf">the pointer to a buffer containing the samples</param>
    /// <param name="channels">the number of channels</param>
    /// <param name="samples">the number of samples in a single channel</param>
    /// <param name="sampleFormat">the sample format</param>
    /// <param name="align">buffer size alignment (0 = default, 1 = no alignment)</param>
    /// <returns>minimum size in bytes required for the buffer on success, or a negative error code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_samples_fill_arrays(Ptr<Ptr<byte>> audioData, out int lineSize, Ptr<byte> buf,
        int channels, int samples, AVSampleFormat sampleFormat, int align);

    /// <summary>
    /// Allocate a samples buffer for nb_samples samples, and fill data pointers and
    /// linesize accordingly.
    /// The allocated samples buffer can be freed by using av_freep(&amp;audio_data[0])
    /// Allocated data will be initialized to silence.
    ///
    /// @see enum AVSampleFormat
    /// The documentation for AVSampleFormat describes the data layout.
    /// </summary>
    /// <param name="audioData">array to be filled with the pointer for each channel</param>
    /// <param name="lineSize">aligned size for audio buffer(s), may be NULL</param>
    /// <param name="channels">number of audio channels</param>
    /// <param name="samples">number of samples per channel</param>
    /// <param name="sampleFormat"></param>
    /// <param name="align">buffer size alignment (0 = default, 1 = no alignment)</param>
    /// <returns>&gt;=0 on success or a negative error code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_samples_alloc(Ptr<Ptr<byte>> audioData, out int lineSize, int channels, int samples,
        AVSampleFormat sampleFormat, int align);

    /// <summary>
    /// Allocate a data pointers array, samples buffer for nb_samples
    /// samples, and fill data pointers and linesize accordingly.
    ///
    /// This is the same as av_samples_alloc(), but also allocates the data
    /// pointers array.
    /// </summary>
    /// <param name="audioData"></param>
    /// <param name="lineSize"></param>
    /// <param name="channels"></param>
    /// <param name="samples"></param>
    /// <param name="sampleFormat"></param>
    /// <param name="align"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_samples_alloc_array_and_samples(out Ptr<Ptr<byte>> audioData, out int lineSize,
        int channels, int samples, AVSampleFormat sampleFormat, int align);

    /// <summary>
    /// Copy samples from src to dst.
    /// </summary>
    /// <param name="dst">destination array of pointers to data planes</param>
    /// <param name="src">source array of pointers to data planes</param>
    /// <param name="dstOffset">offset in samples at which the data will be written to dst</param>
    /// <param name="srcOffset">offset in samples at which the data will be read from src</param>
    /// <param name="samples">number of samples to be copied</param>
    /// <param name="channels">number of audio channels</param>
    /// <param name="sampleFormat">audio sample format</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_samples_copy(Ptr<Ptr<byte>> dst, Ptr<Ptr<byte>> src, int dstOffset, int srcOffset,
        int samples, int channels, AVSampleFormat sampleFormat);

    /// <summary>
    /// Fill an audio buffer with silence.
    /// </summary>
    /// <param name="audioData">array of pointers to data planes</param>
    /// <param name="offset">offset in samples at which to start filling</param>
    /// <param name="samples">number of samples to fill</param>
    /// <param name="channels">number of audio channels</param>
    /// <param name="sampleFormat">audio sample format</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_samples_set_silence(Ptr<Ptr<byte>> audioData, int offset, int samples, int channels,
        AVSampleFormat sampleFormat);
}
