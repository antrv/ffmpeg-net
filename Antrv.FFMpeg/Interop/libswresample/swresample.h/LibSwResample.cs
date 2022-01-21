using System;

namespace Antrv.FFMpeg.Interop;

partial class LibSwResample
{
    /// <summary>
    /// Get the AVClass for SwrContext. It can be used in combination with
    /// AV_OPT_SEARCH_FAKE_OBJ for examining options.
    /// </summary>
    /// <returns>the AVClass of SwrContext</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVClass> swr_get_class();

    /// <summary>
    /// Allocate SwrContext.
    ///
    /// If you use this function you will need to set the parameters (manually or
    /// with swr_alloc_set_opts()) before calling swr_init().
    /// </summary>
    /// <returns>NULL on error, allocated context otherwise</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<SwrContext> swr_alloc();

    /// <summary>
    /// Initialize context after user parameters have been set.
    /// The context must be configured using the AVOption API.
    /// </summary>
    /// <param name="s">Swr context to initialize</param>
    /// <returns>AVERROR error code in case of failure.</returns>
    [DllImport(LibraryName)]
    public static extern int swr_init(Ptr<SwrContext> s);

    /// <summary>
    /// Check whether an swr context has been initialized or not.
    /// </summary>
    /// <param name="s">Swr context to check</param>
    /// <returns>positive if it has been initialized, 0 if not initialized</returns>
    [DllImport(LibraryName)]
    public static extern int swr_is_initialized(Ptr<SwrContext> s);

    /// <summary>
    /// Allocate SwrContext if needed and set/reset common parameters.
    ///
    /// This function does not require s to be allocated with swr_alloc(). On the
    /// other hand, swr_alloc() can use swr_alloc_set_opts() to set the parameters
    /// on the allocated context.
    /// </summary>
    /// <param name="s">existing Swr context if available, or NULL if not</param>
    /// <param name="outputChLayout">output channel layout (AV_CH_LAYOUT_*)</param>
    /// <param name="outputSampleFmt">output sample format (AV_SAMPLE_FMT_*).</param>
    /// <param name="outputSampleRate">output sample rate (frequency in Hz)</param>
    /// <param name="inputChLayout">input channel layout (AV_CH_LAYOUT_*)</param>
    /// <param name="inputSampleFmt">input sample format (AV_SAMPLE_FMT_*).</param>
    /// <param name="inputSampleRate">input sample rate (frequency in Hz)</param>
    /// <param name="logOffset">logging level offset</param>
    /// <param name="logCtx">parent logging context, can be NULL</param>
    /// <returns>NULL on error, allocated context otherwise</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<SwrContext> swr_alloc_set_opts(Ptr<SwrContext> s, AVChannelLayout outputChLayout,
        AVSampleFormat outputSampleFmt, int outputSampleRate, AVChannelLayout inputChLayout,
        AVSampleFormat inputSampleFmt, int inputSampleRate, int logOffset, IntPtr logCtx);

    /// <summary>
    /// Free the given SwrContext and set the pointer to NULL.
    /// </summary>
    /// <param name="s">a pointer to a pointer to Swr context</param>
    [DllImport(LibraryName)]
    public static extern void swr_free(ref Ptr<SwrContext> s);

    /// <summary>
    /// Closes the context so that swr_is_initialized() returns 0.
    ///
    /// The context can be brought back to life by running swr_init(),
    /// swr_init() can also be used without swr_close().
    /// This function is mainly provided for simplifying the usecase
    /// where one tries to support libavresample and libswresample.
    /// </summary>
    /// <param name="s">Swr context to be closed</param>
    [DllImport(LibraryName)]
    public static extern void swr_close(Ptr<SwrContext> s);

    /// <summary>
    /// Convert audio.
    /// in and in_count can be set to 0 to flush the last few samples out at the end.
    ///
    /// If more input is provided than output space, then the input will be buffered.
    /// You can avoid this buffering by using swr_get_out_samples() to retrieve an
    /// upper bound on the required number of output samples for the given number of
    /// input samples. Conversion will run directly without copying whenever possible.
    /// </summary>
    /// <param name="s">allocated Swr context, with parameters set</param>
    /// <param name="output">output buffers, only the first one need be set in case of packed audio</param>
    /// <param name="outCount">amount of space available for output in samples per channel</param>
    /// <param name="input">input buffers, only the first one need to be set in case of packed audio</param>
    /// <param name="inCount">number of input samples available in one channel</param>
    /// <returns>number of samples output per channel, negative value on error</returns>
    [DllImport(LibraryName)]
    public static extern int swr_convert(Ptr<SwrContext> s, Ptr<Ptr<byte>> output, int outCount,
        ConstPtr<ConstPtr<byte>> input, int inCount);

    /// <summary>
    /// Convert the next timestamp from input to output
    /// timestamps are in 1/(in_sample_rate * out_sample_rate) units.
    ///
    /// Note: There are 2 slightly differently behaving modes.
    /// - When automatic timestamp compensation is not used, (min_compensation >= FLT_MAX)
    ///   in this case timestamps will be passed through with delays compensated
    /// - When automatic timestamp compensation is used, (min_compensation &lt; FLT_MAX)
    ///   in this case the output timestamps will match output sample numbers.
    ///   See ffmpeg-resampler(1) for the two modes of compensation.
    /// </summary>
    /// <param name="s">initialized Swr context</param>
    /// <param name="pts">timestamp for the next input sample, INT64_MIN if unknown</param>
    /// <returns>the output timestamp for the next output sample</returns>
    [DllImport(LibraryName)]
    public static extern long swr_next_pts(Ptr<SwrContext> s, long pts);

    /// <summary>
    /// Activate resampling compensation ("soft" compensation). This function is
    /// internally called when needed in swr_next_pts().
    /// </summary>
    /// <param name="s">allocated Swr context. If it is not initialized,
    /// or SWR_FLAG_RESAMPLE is not set, swr_init() is
    /// called with the flag set.</param>
    /// <param name="sampleDelta">delta in PTS per sample</param>
    /// <param name="compensationDistance">compensation_distance number of samples to compensate for</param>
    /// <returns>
    /// &gt;= 0 on success, AVERROR error codes if:
    /// s is NULL,
    /// compensation_distance is less than 0,
    /// compensation_distance is 0 but sample_delta is not,
    /// compensation unsupported by resampler, or
    /// swr_init() fails when called.
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int swr_set_compensation(Ptr<SwrContext> s, int sampleDelta, int compensationDistance);

    /// <summary>
    /// Set a customized input channel mapping.
    /// </summary>
    /// <param name="s">allocated Swr context, not yet initialized</param>
    /// <param name="channelMap">customized input channel mapping (array of channel indexes, -1 for a muted channel)</param>
    /// <returns>&gt;= 0 on success, or AVERROR error code in case of failure.</returns>
    [DllImport(LibraryName)]
    public static extern int swr_set_channel_mapping(Ptr<SwrContext> s, ConstPtr<int> channelMap);

    /// <summary>
    /// Generate a channel mixing matrix.
    ///
    /// This function is the one used internally by libswresample for building the
    /// default mixing matrix. It is made public just as a utility function for
    /// building custom matrices.
    /// </summary>
    /// <param name="inLayout">input channel layout</param>
    /// <param name="outLayout">output channel layout</param>
    /// <param name="centerMixLevel">mix level for the center channel</param>
    /// <param name="surroundMixLevel">mix level for the surround channel(s)</param>
    /// <param name="lfeMixLevel">mix level for the low-frequency effects channel</param>
    /// <param name="rematrixMaxval">if 1.0, coefficients will be normalized to prevent overflow. if INT_MAX, coefficients will not be normalized.</param>
    /// <param name="rematrixVolume"></param>
    /// <param name="matrix">mixing coefficients; matrix[i + stride * o] is the weight of input channel i in output channel o.</param>
    /// <param name="stride">distance between adjacent input channels in the matrix array</param>
    /// <param name="matrixEncoding">matrixed stereo downmix mode (e.g. dplii)</param>
    /// <param name="logCtx">parent logging context, can be NULL</param>
    /// <returns>0 on success, negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int swr_build_matrix(AVChannelLayout inLayout, AVChannelLayout outLayout,
        double centerMixLevel, double surroundMixLevel, double lfeMixLevel, double rematrixMaxval,
        double rematrixVolume, Ptr<double> matrix, int stride, AVMatrixEncoding matrixEncoding, IntPtr logCtx);

    /// <summary>
    /// Set a customized remix matrix.
    /// </summary>
    /// <param name="s">allocated Swr context, not yet initialized</param>
    /// <param name="matrix">remix coefficients; matrix[i + stride * o] is
    /// the weight of input channel i in output channel o</param>
    /// <param name="stride">offset between lines of the matrix</param>
    /// <returns>&gt;= 0 on success, or AVERROR error code in case of failure.</returns>
    [DllImport(LibraryName)]
    public static extern int swr_set_matrix(Ptr<SwrContext> s, ConstPtr<double> matrix, int stride);

    /// <summary>
    /// Drops the specified number of output samples.
    ///
    /// This function, along with swr_inject_silence(), is called by swr_next_pts() if needed for "hard" compensation.
    /// </summary>
    /// <param name="s">allocated Swr context</param>
    /// <param name="count">number of samples to be dropped</param>
    /// <returns>&gt;= 0 on success, or a negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int swr_drop_output(Ptr<SwrContext> s, int count);

    /// <summary>
    /// Injects the specified number of silence samples.
    ///
    /// This function, along with swr_drop_output(), is called by swr_next_pts()
    /// if needed for "hard" compensation.
    /// </summary>
    /// <param name="s">allocated Swr context</param>
    /// <param name="count">number of samples to be dropped</param>
    /// <returns>&gt;= 0 on success, or a negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int swr_inject_silence(Ptr<SwrContext> s, int count);

    /// <summary>
    /// Gets the delay the next input sample will experience relative to the next output sample.
    ///
    /// Swresample can buffer data if more input has been provided than available
    /// output space, also converting between sample rates needs a delay.
    /// This function returns the sum of all such delays.
    /// The exact delay is not necessarily an integer value in either input or
    /// output sample rate. Especially when downsampling by a large value, the
    /// output sample rate may be a poor choice to represent the delay, similarly
    /// for upsampling and the input sample rate.
    /// </summary>
    /// <param name="s">swr context</param>
    /// <param name="timeBase">
    /// timebase in which the returned delay will be:
    /// - if it's set to 1 the returned delay is in seconds
    /// - if it's set to 1000 the returned delay is in milliseconds
    /// - if it's set to the input sample rate then the returned delay is in input samples
    /// - if it's set to the output sample rate then the returned delay is in output samples
    /// - if it's the least common multiple of in_sample_rate and
    ///   out_sample_rate then an exact rounding-free delay will be returned
    /// </param>
    /// <returns>the delay in 1 / c base units.</returns>
    [DllImport(LibraryName)]
    public static extern long swr_get_delay(Ptr<SwrContext> s, long timeBase);

    /// <summary>
    /// Find an upper bound on the number of samples that the next swr_convert
    /// call will output, if called with in_samples of input samples. This
    /// depends on the internal state, and anything changing the internal state
    /// (like further swr_convert() calls) will may change the number of samples
    /// swr_get_out_samples() returns for the same number of input samples.
    ///
    /// Note: any call to swr_inject_silence(), swr_convert(), swr_next_pts()
    /// or swr_set_compensation() invalidates this limit
    /// it is recommended to pass the correct available buffer size
    /// to all functions like swr_convert() even if swr_get_out_samples()
    /// indicates that less would be used.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="inSamples">number of input samples.</param>
    /// <returns>an upper bound on the number of samples that the next swr_convert
    /// will output or a negative value to indicate an error</returns>
    [DllImport(LibraryName)]
    public static extern int swr_get_out_samples(Ptr<SwrContext> s, int inSamples);

    /// <summary>
    /// Return the @ref LIBSWRESAMPLE_VERSION_INT constant.
    ///
    /// This is useful to check if the build-time libswresample has the same version
    /// as the run-time one.
    /// </summary>
    /// <returns>the unsigned int-typed version</returns>
    [DllImport(LibraryName)]
    public static extern uint swresample_version();

    /// <summary>
    /// Return the swr build-time configuration.
    /// </summary>
    /// <returns>the build-time ./configure flags</returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr swresample_configuration();

    /// <summary>
    /// Return the swr license.
    /// </summary>
    /// <returns>the license of libswresample, determined at build-time</returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr swresample_license();

    /// <summary>
    /// Convert the samples in the input AVFrame and write them to the output AVFrame.
    ///
    /// Input and output AVFrames must have channel_layout, sample_rate and format set.
    ///
    /// If the output AVFrame does not have the data pointers allocated the nb_samples
    /// field will be set using av_frame_get_buffer() is called to allocate the frame.
    ///
    /// The output AVFrame can be NULL or have fewer allocated samples than required.
    /// In this case, any remaining samples not written to the output will be added
    /// to an internal FIFO buffer, to be returned at the next call to this function
    /// or to swr_convert().
    ///
    /// If converting sample rate, there may be data remaining in the internal
    /// resampling delay buffer. swr_get_delay() tells the number of
    /// remaining samples. To get this data as output, call this function or
    /// swr_convert() with NULL input.
    ///
    /// If the SwrContext configuration does not match the output and
    /// input AVFrame settings the conversion does not take place and depending on
    /// which AVFrame is not matching AVERROR_OUTPUT_CHANGED, AVERROR_INPUT_CHANGED
    /// or the result of a bitwise-OR of them is returned.
    /// </summary>
    /// <param name="swr">audio resample context</param>
    /// <param name="output">output AVFrame</param>
    /// <param name="input">input AVFrame</param>
    /// <returns>0 on success, AVERROR on failure or nonmatching configuration.</returns>
    [DllImport(LibraryName)]
    public static extern int swr_convert_frame(Ptr<SwrContext> swr, Ptr<AVFrame> output, ConstPtr<AVFrame> input);

    /// <summary>
    /// Configure or reconfigure the SwrContext using the information provided by the AVFrames.
    ///
    /// The original resampling context is reset even on failure.
    /// The function calls swr_close() internally if the context is open.
    /// </summary>
    /// <param name="swr">audio resample context</param>
    /// <param name="output">output AVFrame</param>
    /// <param name="input">input AVFrame</param>
    /// <returns>0 on success, AVERROR on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int swr_config_frame(Ptr<SwrContext> swr, ConstPtr<AVFrame> output, ConstPtr<AVFrame> input);
}
