namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Free an AVAudioFifo.
    /// </summary>
    /// <param name="af">AVAudioFifo to free</param>
    [DllImport(LibraryName)]
    public static extern void av_audio_fifo_free(Ptr<AVAudioFifo> af);

    /// <summary>
    /// Allocate an AVAudioFifo.
    /// </summary>
    /// <param name="sampleFormat">sample format</param>
    /// <param name="channels">number of channels</param>
    /// <param name="samples">initial allocation size, in samples</param>
    /// <returns>newly allocated AVAudioFifo, or NULL on error</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVAudioFifo> av_audio_fifo_alloc(AVSampleFormat sampleFormat, int channels, int samples);

    /// <summary>
    /// Reallocate an AVAudioFifo.
    /// </summary>
    /// <param name="af">AVAudioFifo to reallocate</param>
    /// <param name="samples">new allocation size, in samples</param>
    /// <returns>0 if OK, or negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_audio_fifo_realloc(Ptr<AVAudioFifo> af, int samples);

    /// <summary>
    /// Write data to an AVAudioFifo.
    ///
    /// The AVAudioFifo will be reallocated automatically if the available space is less than <paramref name="samples"/>.
    /// The documentation for <see cref="AVSampleFormat"/> describes the data layout.
    /// </summary>
    /// <param name="af">AVAudioFifo to write to</param>
    /// <param name="data">audio data plane pointers</param>
    /// <param name="samples">number of samples to write</param>
    /// <returns>number of samples actually written, or negative AVERROR code on failure.
    /// If successful, the number of samples actually written will always be <paramref name="samples"/>.</returns>
    [DllImport(LibraryName)]
    public static extern int av_audio_fifo_write(Ptr<AVAudioFifo> af, Ptr<Ptr<byte>> data, int samples);

    /// <summary>
    /// Peek data from an AVAudioFifo.
    /// The documentation for <see cref="AVSampleFormat"/> describes the data layout.
    /// </summary>
    /// <param name="af">AVAudioFifo to read from</param>
    /// <param name="data">audio data plane pointers</param>
    /// <param name="samples">number of samples to peek</param>
    /// <returns>number of samples actually peek, or negative AVERROR code on failure. The number of samples actually peek will not
    /// be greater than <paramref name="samples"/>, and will only be less than <paramref name="samples"/>
    /// if av_audio_fifo_size is less than <paramref name="samples"/>.</returns>
    [DllImport(LibraryName)]
    public static extern int av_audio_fifo_peek(Ptr<AVAudioFifo> af, Ptr<Ptr<byte>> data, int samples);

    /// <summary>
    /// Peek data from an AVAudioFifo.
    /// The documentation for <see cref="AVSampleFormat"/> describes the data layout.
    /// </summary>
    /// <param name="af">AVAudioFifo to read from</param>
    /// <param name="data">audio data plane pointers</param>
    /// <param name="samples">number of samples to peek</param>
    /// <param name="offset">offset from current read position</param>
    /// <returns>number of samples actually peek, or negative AVERROR code on failure. The number of samples actually peek will not
    /// be greater than <paramref name="samples"/>, and will only be less than <paramref name="samples"/>
    /// if av_audio_fifo_size is less than <paramref name="samples"/>.</returns>
    [DllImport(LibraryName)]
    public static extern int av_audio_fifo_peek_at(Ptr<AVAudioFifo> af, Ptr<Ptr<byte>> data, int samples, int offset);

    /// <summary>
    /// Read data from an AVAudioFifo.
    /// The documentation for <see cref="AVSampleFormat"/> describes the data layout.
    /// </summary>
    /// <param name="af">AVAudioFifo to read from</param>
    /// <param name="data">audio data plane pointers</param>
    /// <param name="samples">number of samples to read</param>
    /// <returns>number of samples actually read, or negative AVERROR code on failure. The number of samples actually read will not
    /// be greater than <paramref name="samples"/>, and will only be less than
    /// <paramref name="samples"/> if av_audio_fifo_size is less than <paramref name="samples"/>.</returns>
    [DllImport(LibraryName)]
    public static extern int av_audio_fifo_read(Ptr<AVAudioFifo> af, Ptr<Ptr<byte>> data, int samples);

    /// <summary>
    /// Drain data from an AVAudioFifo.
    /// Removes the data without reading it.
    /// </summary>
    /// <param name="af">AVAudioFifo to drain</param>
    /// <param name="samples">number of samples to drain</param>
    /// <returns>0 if OK, or negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_audio_fifo_drain(Ptr<AVAudioFifo> af, int samples);

    /// <summary>
    /// Reset the AVAudioFifo buffer.
    /// This empties all data in the buffer.
    /// </summary>
    /// <param name="af">AVAudioFifo to reset</param>
    [DllImport(LibraryName)]
    public static extern void av_audio_fifo_reset(Ptr<AVAudioFifo> af);

    /// <summary>
    /// Get the current number of samples in the AVAudioFifo available for reading.
    /// </summary>
    /// <param name="af">the AVAudioFifo to query</param>
    /// <returns>number of samples available for reading</returns>
    [DllImport(LibraryName)]
    public static extern int av_audio_fifo_size(Ptr<AVAudioFifo> af);

    /// <summary>
    /// Get the current number of samples in the AVAudioFifo available for writing.
    /// </summary>
    /// <param name="af">the AVAudioFifo to query</param>
    /// <returns>number of samples available for writing</returns>
    [DllImport(LibraryName)]
    public static extern int av_audio_fifo_space(Ptr<AVAudioFifo> af);
}
