namespace Antrv.FFMpeg.Interop;

partial class LibAvFormat
{
    /// <summary>
    /// Allocate and read the payload of a packet and initialize its fields with default values.
    /// </summary>
    /// <param name="s">associated IO context</param>
    /// <param name="pkt">packet</param>
    /// <param name="size">desired payload size</param>
    /// <returns>>0 (read size) if OK, AVERROR_xxx otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_get_packet(Ptr<AVIOContext> s, Ptr<AVPacket> pkt, int size);

    /// <summary>
    /// Read data and append it to the current content of the AVPacket.
    /// If pkt->size is 0 this is identical to av_get_packet.
    /// Note that this uses av_grow_packet and thus involves a realloc
    /// which is inefficient. Thus this function should only be used
    /// when there is no reasonable way to know (an upper bound of)
    /// the final size.
    /// </summary>
    /// <param name="s">associated IO context</param>
    /// <param name="pkt">packet</param>
    /// <param name="size">amount of data to read</param>
    /// <returns>>0 (read size) if OK, AVERROR_xxx otherwise, previous data
    /// will not be lost even if an error occurs.</returns>
    [DllImport(LibraryName)]
    public static extern int av_append_packet(Ptr<AVIOContext> s, Ptr<AVPacket> pkt, int size);

    /// <summary>
    /// score for file extension
    /// </summary>
    public const int AVPROBE_SCORE_EXTENSION = 50;

    /// <summary>
    /// score for file mime type
    /// </summary>
    public const int AVPROBE_SCORE_MIME = 75;

    /// <summary>
    /// maximum score
    /// </summary>
    public const int AVPROBE_SCORE_MAX = 100;

    public const int AVPROBE_SCORE_RETRY = AVPROBE_SCORE_MAX / 4;

    public const int AVPROBE_SCORE_STREAM_RETRY = AVPROBE_SCORE_MAX / 4 - 1;

    /// <summary>
    /// extra allocated bytes at the end of the probe buffer
    /// </summary>
    public const int AVPROBE_PADDING_SIZE = 32;

    /// <summary>
    /// The AV_DISPOSITION_* flag corresponding to disp or a negative error
    /// code if disp does not correspond to a known stream disposition.
    /// </summary>
    /// <param name="disp"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVDisposition av_disposition_from_string([MarshalAs(UnmanagedType.LPUTF8Str)] string disp);

    /// <summary>
    /// </summary>
    /// <param name="disposition">a combination of AV_DISPOSITION_* values</param>
    /// <returns>The string description corresponding to the lowest set bit in
    /// disposition. NULL when the lowest set bit does not correspond
    /// to a known disposition or when disposition is 0.</returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr av_disposition_to_string(AVDisposition disposition);

    [DllImport(LibraryName)]
    public static extern Ptr<AVCodecParserContext> av_stream_get_parser(Ptr<AVStream> s);

    /// <summary>
    /// Returns the pts of the last muxed packet + its duration.
    /// the retuned value is undefined when used with a demuxer.
    /// </summary>
    /// <param name="st"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern long av_stream_get_end_pts(Ptr<AVStream> st);

    /// <summary>
    /// This function will cause global side data to be injected in the next packet
    /// of each stream as well as after any subsequent seek.
    /// </summary>
    /// <param name="s"></param>
    [DllImport(LibraryName)]
    public static extern void av_format_inject_global_side_data(Ptr<AVFormatContext> s);

    /// <summary>
    /// Returns the method used to set ctx->duration.
    /// </summary>
    /// <param name="ctx"></param>
    /// <returns>AVFMT_DURATION_FROM_PTS, AVFMT_DURATION_FROM_STREAM, or AVFMT_DURATION_FROM_BITRATE.</returns>
    [DllImport(LibraryName)]
    public static extern AVDurationEstimationMethod av_fmt_ctx_get_duration_estimation_method(
        ConstPtr<AVFormatContext> ctx);

    /// <summary>
    /// Return the libavformat version.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint avformat_version();

    /// <summary>
    /// Return the libavformat build-time configuration.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr avformat_configuration();

    /// <summary>
    /// Return the libavformat license.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr avformat_license();

    /// <summary>
    /// Do global initialization of network libraries. This is optional,
    /// and not recommended anymore.
    ///
    /// This functions only exists to work around thread-safety issues
    /// with older GnuTLS or OpenSSL libraries. If libavformat is linked
    /// to newer versions of those libraries, or if you do not use them,
    /// calling this function is unnecessary. Otherwise, you need to call
    /// this function before any other threads using them are started.
    ///
    /// This function will be deprecated once support for older GnuTLS and
    /// OpenSSL libraries is removed, and this function has no purpose anymore.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int avformat_network_init();

    /// <summary>
    /// Undo the initialization done by avformat_network_init. Call it only
    /// once for each time you called avformat_network_init.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int avformat_network_deinit();

    /// <summary>
    /// Iterate over all registered muxers.
    /// </summary>
    /// <param name="opaque">a pointer where libavformat will store the iteration state. Must
    /// point to NULL to start the iteration.</param>
    /// <returns>the next registered muxer or NULL when the iteration is finished</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVOutputFormat> av_muxer_iterate(ref IntPtr opaque);

    /// <summary>
    /// Iterate over all registered demuxers.
    /// </summary>
    /// <param name="opaque">A pointer where libavformat will store the iteration state.
    /// Must point to NULL to start the iteration.</param>
    /// <returns>The next registered demuxer or NULL when the iteration is finished.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVInputFormat> av_demuxer_iterate(ref IntPtr opaque);

    /// <summary>
    /// Allocate an AVFormatContext. avformat_free_context() can be used to free the context and
    /// everything allocated by the framework within it.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVFormatContext> avformat_alloc_context();

    /// <summary>
    /// Free an AVFormatContext and all its streams.
    /// </summary>
    /// <param name="s">Context to free.</param>
    [DllImport(LibraryName)]
    public static extern void avformat_free_context(Ptr<AVFormatContext> s);

    /// <summary>
    /// Get the AVClass for AVFormatContext. It can be used in combination with
    /// AV_OPT_SEARCH_FAKE_OBJ for examining options.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVClass> avformat_get_class();

    /// <summary>
    /// Get the AVClass for AVStream. It can be used in combination with
    /// AV_OPT_SEARCH_FAKE_OBJ for examining options.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVClass> av_stream_get_class();

    /// <summary>
    /// Add a new stream to a media file.
    ///
    /// When demuxing, it is called by the demuxer in read_header(). If the flag
    /// AVFMTCTX_NOHEADER is set in s.ctx_flags, then it may also be called in read_packet().
    ///
    /// When muxing, should be called by the user before avformat_write_header().
    ///
    /// User is required to call avformat_free_context() to clean up the allocation
    /// by avformat_new_stream().
    /// </summary>
    /// <param name="s">Media file handle.</param>
    /// <param name="c">unused, does nothing</param>
    /// <returns>newly created stream or NULL on error.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVStream> avformat_new_stream(Ptr<AVFormatContext> s, ConstPtr<AVCodec> c);

    /// <summary>
    /// Wrap an existing array as stream side data.
    /// </summary>
    /// <param name="st">Stream.</param>
    /// <param name="type">Side information type.</param>
    /// <param name="data">The side data array. It must be allocated with the av_malloc()
    /// family of functions. The ownership of the data is transferred to stream.</param>
    /// <param name="size">Side information size.</param>
    /// <returns>Zero on success, a negative AVERROR code on failure. On failure,
    /// the stream is unchanged and the data remains owned by the caller.</returns>
    [DllImport(LibraryName)]
    public static extern int av_stream_add_side_data(Ptr<AVStream> st, AVPacketSideDataType type, Ptr<byte> data,
        nuint size);

    /// <summary>
    /// Allocate new information from stream.
    /// </summary>
    /// <param name="stream">Stream.</param>
    /// <param name="type">Desired side information type.</param>
    /// <param name="size">Side information size.</param>
    /// <returns>Pointer to fresh allocated data or NULL otherwise.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<byte> av_stream_new_side_data(Ptr<AVStream> stream, AVPacketSideDataType type, nuint size);

    /// <summary>
    /// Get side information from stream.
    /// </summary>
    /// <param name="stream">Stream.</param>
    /// <param name="type">Desired side information type.</param>
    /// <param name="size">If supplied, *size will be set to the size of the side data
    /// or to zero if the desired side data is not present.</param>
    /// <returns>Pointer to data if present or NULL otherwise.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<byte> av_stream_get_side_data(Ptr<AVStream> stream, AVPacketSideDataType type,
        out nuint size);

    [DllImport(LibraryName)]
    public static extern Ptr<AVProgram> av_new_program(Ptr<AVFormatContext> s, int id);

    /// <summary>
    /// Allocate an AVFormatContext for an output format.
    /// avformat_free_context() can be used to free the context and
    /// everything allocated by the framework within it.
    /// </summary>
    /// <param name="ctx">is set to the created format context, or to NULL in case of failure.</param>
    /// <param name="oformat">Format to use for allocating the context, if NULL then
    /// format_name and filename are used instead.</param>
    /// <param name="formatName">The name of output format to use for allocating the context,
    /// if NULL then filename is used instead.</param>
    /// <param name="filename">The name of the filename to use for allocating the context, may be NULL.</param>
    /// <returns> >= 0 in case of success, a negative AVERROR code in case of failure.</returns>
    [DllImport(LibraryName)]
    public static extern int avformat_alloc_output_context2(out Ptr<AVFormatContext> ctx,
        ConstPtr<AVOutputFormat> oformat, [MarshalAs(UnmanagedType.LPUTF8Str)] string? formatName,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? filename);

    /// <summary>
    /// Find AVInputFormat based on the short name of the input format.
    /// </summary>
    /// <param name="shortName"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVInputFormat> av_find_input_format(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string shortName);

    /// <summary>
    /// Guess the file format.
    /// </summary>
    /// <param name="pd">Data to be probed.</param>
    /// <param name="isOpened">Whether the file is already opened; determines
    /// whether demuxers with or without AVFMT_NOFILE are probed.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVInputFormat> av_probe_input_format(ConstPtr<AVProbeData> pd, int isOpened);

    /// <summary>
    /// Guess the file format.
    /// </summary>
    /// <param name="pd">Data to be probed.</param>
    /// <param name="isOpened">Whether the file is already opened; determines
    /// whether demuxers with or without AVFMT_NOFILE are probed.</param>
    /// <param name="scoreMax">A probe score larger that this is required to accept a detection,
    /// the variable is set to the actual detection score afterwards.
    /// If the score is &lt;= AVPROBE_SCORE_MAX / 4 it is recommended to retry with a larger probe buffer.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVInputFormat> av_probe_input_format2(ConstPtr<AVProbeData> pd, int isOpened,
        ref int scoreMax);

    /// <summary>
    /// Guess the file format.
    /// </summary>
    /// <param name="pd">Data to be probed.</param>
    /// <param name="isOpened">Whether the file is already opened; determines
    /// whether demuxers with or without AVFMT_NOFILE are probed.</param>
    /// <param name="scoreRet">The score of the best detection.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVInputFormat> av_probe_input_format3(ConstPtr<AVProbeData> pd, int isOpened,
        out int scoreRet);

    /// <summary>
    /// Probe a bytestream to determine the input format. Each time a probe returns
    /// with a score that is too low, the probe buffer size is increased and another
    /// attempt is made. When the maximum probe size is reached, the input format
    /// with the highest score is returned.
    /// </summary>
    /// <param name="pb">The bytestream to probe.</param>
    /// <param name="fmt">The input format is put here.</param>
    /// <param name="url">The url of the stream.</param>
    /// <param name="logCtx">The log context.</param>
    /// <param name="offset">The offset within the bytestream to probe from.</param>
    /// <param name="maxProbeSize">The maximum probe buffer size (zero for default).</param>
    /// <returns>The score in case of success, a negative value corresponding
    /// to the maximal score is AVPROBE_SCORE_MAX, AVERROR code otherwise.</returns>
    [DllImport(LibraryName)]
    public static extern int av_probe_input_buffer2(Ptr<AVIOContext> pb, out ConstPtr<AVInputFormat> fmt,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string url, IntPtr logCtx, uint offset, uint maxProbeSize);

    /// <summary>
    /// Like av_probe_input_buffer2() but returns 0 on success.
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="fmt"></param>
    /// <param name="url"></param>
    /// <param name="logCtx"></param>
    /// <param name="offset"></param>
    /// <param name="maxProbeSize"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_probe_input_buffer(Ptr<AVIOContext> pb, out ConstPtr<AVInputFormat> fmt,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string url, IntPtr logCtx, uint offset, uint maxProbeSize);

    /// <summary>
    /// Open an input stream and read the header. The codecs are not opened.
    /// The stream must be closed with avformat_close_input().
    /// </summary>
    /// <param name="ps">Pointer to user-supplied AVFormatContext (allocated by avformat_alloc_context).
    /// May be a pointer to NULL, in which case an AVFormatContext is allocated by
    /// this function and written into ps. Note that a user-supplied AVFormatContext
    /// will be freed on failure.</param>
    /// <param name="url">URL of the stream to open.</param>
    /// <param name="fmt">If non-NULL, this parameter forces a specific input format.
    /// Otherwise the format is autodetected.</param>
    /// <param name="options">A dictionary filled with AVFormatContext and demuxer-private options.
    /// On return this parameter will be destroyed and replaced with
    /// a dict containing options that were not found. May be NULL.</param>
    /// <returns>0 on success, a negative AVERROR on failure.</returns>
    /// <remarks>If you want to use custom IO, preallocate the format context and set its pb field.</remarks>
    [DllImport(LibraryName)]
    public static extern int avformat_open_input(ref Ptr<AVFormatContext> ps,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string url, ConstPtr<AVInputFormat> fmt, ref Ptr<AVDictionary> options);

    /// <summary>
    /// Read packets of a media file to get stream information.
    ///
    /// This is useful for file formats with no headers such as MPEG.
    ///
    /// This function also computes the real framerate in case of MPEG-2 repeat frame mode.
    ///
    /// The logical file position is not changed by this function;
    /// examined packets may be buffered for later processing.
    /// </summary>
    /// <param name="ic">Media file handle.</param>
    /// <param name="options">If non-NULL, an ic.nb_streams long array of pointers to dictionaries,
    /// where i-th member contains options for codec corresponding to i-th stream.
    /// On return each dictionary will be filled with options that were not found.</param>
    /// <returns> >=0 if OK, AVERROR_xxx on error.</returns>
    /// <remarks>This function isn't guaranteed to open all the codecs,
    /// so options being non-empty at return is a perfectly normal behavior.</remarks>
    [DllImport(LibraryName)]
    public static extern int avformat_find_stream_info(Ptr<AVFormatContext> ic, ref Ptr<AVDictionary> options);

    /// <summary>
    /// Find the programs which belong to a given stream.
    /// </summary>
    /// <param name="ic">Media file handle.</param>
    /// <param name="last">The last found program, the search will start after this program,
    /// or from the beginning if it is NULL.</param>
    /// <param name="s">Stream index.</param>
    /// <returns>The next program which belongs to s, NULL if no program is found
    /// or the last program is not among the programs of ic.</returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVProgram> av_find_program_from_stream(Ptr<AVFormatContext> ic,
        Ptr<AVProgram> last, int s);

    [DllImport(LibraryName)]
    public static extern void av_program_add_stream_index(Ptr<AVFormatContext> ac, int progId, uint idx);

    /// <summary>
    /// Find the "best" stream in the file.
    /// The best stream is determined according to various heuristics as the most
    /// likely to be what the user expects.
    /// If the decoder parameter is non-NULL, av_find_best_stream will find the
    /// default decoder for the stream's codec; streams for which no decoder can
    /// be found are ignored.
    /// </summary>
    /// <param name="ic">Media file handle.</param>
    /// <param name="type">Stream type: video, audio, subtitles, etc.</param>
    /// <param name="wantedStreamNb">User-requested stream number, or -1 for automatic selection.</param>
    /// <param name="relatedStream">Try to find a stream related (eg. in the same program) to this one,
    /// or -1 if none.</param>
    /// <param name="decoder">if non-NULL, returns the decoder for the selected stream.</param>
    /// <param name="flags">Flags; none are currently defined.</param>
    /// <returns>The non-negative stream number in case of success,
    /// AVERROR_STREAM_NOT_FOUND if no stream with the requested type could be found,
    /// AVERROR_DECODER_NOT_FOUND if streams were found but no decoder.
    /// </returns>
    /// <remarks>If av_find_best_stream returns successfully and decoder_ret is not
    /// NULL, then decoder is guaranteed to be set to a valid AVCodec.</remarks>
    [DllImport(LibraryName)]
    public static extern int av_find_best_stream(Ptr<AVFormatContext> ic, AVMediaType type, int wantedStreamNb,
        int relatedStream, out ConstPtr<AVCodec> decoder, int flags);

    /// <summary>
    /// Return the next frame of a stream.
    /// This function returns what is stored in the file, and does not validate
    /// that what is there are valid frames for the decoder. It will split what is
    /// stored in the file into frames and return one for each call. It will not
    /// omit invalid data between valid frames so as to give the decoder the maximum
    /// information possible for decoding.
    ///
    /// On success, the returned packet is reference-counted (pkt->buf is set) and
    /// valid indefinitely. The packet must be freed with av_packet_unref() when
    /// it is no longer needed. For video, the packet contains exactly one frame.
    /// For audio, it contains an integer number of frames if each frame has
    /// a known fixed size (e.g. PCM or ADPCM data). If the audio frames have
    /// a variable size (e.g. MPEG audio), then it contains one frame.
    ///
    /// pkt->pts, pkt->dts and pkt->duration are always set to correct
    /// values in AVStream.time_base units (and guessed if the format cannot
    /// provide them). pkt->pts can be AV_NOPTS_VALUE if the video format
    /// has B-frames, so it is better to rely on pkt->dts if you do not
    /// decompress the payload.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="pkt"></param>
    /// <returns>0 if OK, &lt; 0 on error or end of file. On error, pkt will be blank
    /// (as if it came from av_packet_alloc()).</returns>
    /// <remarks>pkt will be initialized, so it may be uninitialized, but it must not
    /// contain data that needs to be freed.</remarks>
    [DllImport(LibraryName)]
    public static extern int av_read_frame(Ptr<AVFormatContext> s, Ptr<AVPacket> pkt);

    /// <summary>
    /// Seek to the keyframe at timestamp.
    /// </summary>
    /// <param name="s">media file handle</param>
    /// <param name="streamIndex">If stream_index is (-1), a default
    /// stream is selected, and timestamp is automatically converted
    /// from AV_TIME_BASE units to the stream specific time_base.</param>
    /// <param name="timestamp">Timestamp in AVStream.time_base units or,
    /// if no stream is specified, in AV_TIME_BASE units.</param>
    /// <param name="flags">flags which select direction and seeking mode</param>
    /// <returns> >= 0 on success</returns>
    [DllImport(LibraryName)]
    public static extern int av_seek_frame(Ptr<AVFormatContext> s, int streamIndex, long timestamp,
        AVIOSeekFlags flags);

    /// <summary>
    /// Seek to timestamp ts.
    ///
    /// Seeking will be done so that the point from which all active streams
    /// can be presented successfully will be closest to ts and within min/max_ts.
    /// Active streams are all streams that have AVStream.discard &lt; AVDISCARD_ALL.
    ///
    /// If flags contain AVSEEK_FLAG_BYTE, then all timestamps are in bytes and
    /// are the file position (this may not be supported by all demuxers).
    /// If flags contain AVSEEK_FLAG_FRAME, then all timestamps are in frames
    /// in the stream with stream_index (this may not be supported by all demuxers).
    /// Otherwise all timestamps are in units of the stream selected by stream_index
    /// or if stream_index is -1, in AV_TIME_BASE units.
    /// If flags contain AVSEEK_FLAG_ANY, then non-keyframes are treated as
    /// keyframes (this may not be supported by all demuxers).
    /// If flags contain AVSEEK_FLAG_BACKWARD, it is ignored.
    /// </summary>
    /// <param name="s">media file handle</param>
    /// <param name="streamIndex">index of the stream which is used as time base reference</param>
    /// <param name="minTimestamp">smallest acceptable timestamp</param>
    /// <param name="timestamp">target timestamp</param>
    /// <param name="maxTimestamp">largest acceptable timestamp</param>
    /// <param name="flags">flags</param>
    /// <returns> >=0 on success, error code otherwise</returns>
    /// <remarks>This is part of the new seek API which is still under construction.</remarks>
    [DllImport(LibraryName)]
    public static extern int avformat_seek_file(Ptr<AVFormatContext> s, int streamIndex, long minTimestamp,
        long timestamp, long maxTimestamp, AVIOSeekFlags flags);

    /// <summary>
    /// Discard all internally buffered data. This can be useful when dealing with
    /// discontinuities in the byte stream. Generally works only with formats that
    /// can resync. This includes headerless formats like MPEG-TS/TS but should also
    /// work with NUT, Ogg and in a limited way AVI for example.
    ///
    /// The set of streams, the detected duration, stream parameters and codecs do
    /// not change when calling this function. If you want a complete reset, it's
    /// better to open a new AVFormatContext.
    ///
    /// This does not flush the AVIOContext (s->pb). If necessary, call
    /// avio_flush(s->pb) before calling this function.
    /// </summary>
    /// <param name="s">media file handle</param>
    /// <returns> >=0 on success, error code otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int avformat_flush(Ptr<AVFormatContext> s);

    /// <summary>
    /// Start playing a network-based stream (e.g. RTSP stream) at the current position.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_read_play(Ptr<AVFormatContext> s);

    /// <summary>
    /// Pause a network-based stream (e.g. RTSP stream).
    /// Use av_read_play() to resume it.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_read_pause(Ptr<AVFormatContext> s);

    /// <summary>
    /// Close an opened input AVFormatContext. Free it and all its contents and set *s to NULL.
    /// </summary>
    /// <param name="s"></param>
    [DllImport(LibraryName)]
    public static extern void avformat_close_input(ref Ptr<AVFormatContext> s);

    /// <summary>
    /// Allocate the stream private data and write the stream header to
    /// an output media file.
    /// </summary>
    /// <param name="s">Media file handle, must be allocated with avformat_alloc_context().
    /// Its oformat field must be set to the desired output format;
    /// Its pb field must be set to an already opened AVIOContext.</param>
    /// <param name="options">An AVDictionary filled with AVFormatContext and muxer-private options.
    /// On return this parameter will be destroyed and replaced with a dict containing
    /// options that were not found. May be NULL.</param>
    /// <returns>AVSTREAM_INIT_IN_WRITE_HEADER (0) on success if the codec had not already been fully initialized in avformat_init,
    /// AVSTREAM_INIT_IN_INIT_OUTPUT (1) on success if the codec had already been fully initialized in avformat_init,
    /// negative AVERROR on failure.
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int avformat_write_header(Ptr<AVFormatContext> s, ref Ptr<AVDictionary> options); 

    /// <summary>
    /// Allocate the stream private data and initialize the codec, but do not write the header.
    /// May optionally be used before avformat_write_header to initialize stream parameters
    /// before actually writing the header.
    /// If using this function, do not pass the same options to avformat_write_header.
    /// </summary>
    /// <param name="s">Media file handle, must be allocated with avformat_alloc_context().
    /// Its oformat field must be set to the desired output format;
    /// Its pb field must be set to an already opened AVIOContext.</param>
    /// <param name="options">An AVDictionary filled with AVFormatContext and muxer-private options.
    /// On return this parameter will be destroyed and replaced with a dict containing
    /// options that were not found. May be NULL.</param>
    /// <returns>AVSTREAM_INIT_IN_WRITE_HEADER (0) on success if the codec requires avformat_write_header to fully initialize,
    /// AVSTREAM_INIT_IN_INIT_OUTPUT (1) on success if the codec has been fully initialized,
    /// negative AVERROR on failure.
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int avformat_init_output(Ptr<AVFormatContext> s, ref Ptr<AVDictionary> options);

    /// <summary>
    /// Write a packet to an output media file.
    ///
    /// This function passes the packet directly to the muxer, without any buffering
    /// or reordering. The caller is responsible for correctly interleaving the
    /// packets if the format requires it. Callers that want libavformat to handle
    /// the interleaving should call av_interleaved_write_frame() instead of this
    /// function.
    /// </summary>
    /// <param name="s">media file handle</param>
    /// <param name="pkt">The packet containing the data to be written. Note that unlike
    /// av_interleaved_write_frame(), this function does not take
    /// ownership of the packet passed to it (though some muxers may make
    /// an internal reference to the input packet).
    ///
    /// This parameter can be NULL (at any time, not just at the end), in
    /// order to immediately flush data buffered within the muxer, for
    /// muxers that buffer up data internally before writing it to the
    /// output.
    ///
    /// Packet's @ref AVPacket.stream_index "stream_index" field must be
    /// set to the index of the corresponding stream in @ref
    /// AVFormatContext.streams "s->streams".
    ///
    /// The timestamps (@ref AVPacket.pts "pts", @ref AVPacket.dts "dts")
    /// must be set to correct values in the stream's timebase (unless the
    /// output format is flagged with the AVFMT_NOTIMESTAMPS flag, then
    /// they can be set to AV_NOPTS_VALUE).
    /// The dts for subsequent packets passed to this function must be strictly
    /// increasing when compared in their respective timebases (unless the
    /// output format is flagged with the AVFMT_TS_NONSTRICT, then they
    /// merely have to be nondecreasing).  @ref AVPacket.duration
    /// "duration") should also be set if known.
    /// </param>
    /// <returns>&lt; 0 on error, = 0 if OK, 1 if flushed and there is no more data to flush</returns>
    [DllImport(LibraryName)]
    public static extern int av_write_frame(Ptr<AVFormatContext> s, Ptr<AVPacket> pkt);

    /// <summary>
    /// Write a packet to an output media file ensuring correct interleaving.
    ///
    /// This function will buffer the packets internally as needed to make sure the
    /// packets in the output file are properly interleaved, usually ordered by
    /// increasing dts. Callers doing their own interleaving should call
    /// av_write_frame() instead of this function.
    ///
    /// Using this function instead of av_write_frame() can give muxers advance
    /// knowledge of future packets, improving e.g. the behaviour of the mp4
    /// muxer for VFR content in fragmenting mode.
    /// </summary>
    /// <param name="s">media file handle</param>
    /// <param name="pkt">
    /// The packet containing the data to be written.
    ///
    /// If the packet is reference-counted, this function will take
    /// ownership of this reference and unreference it later when it sees
    /// fit. If the packet is not reference-counted, libavformat will
    /// make a copy.
    /// The returned packet will be blank (as if returned from
    /// av_packet_alloc()), even on error.
    ///
    /// This parameter can be NULL (at any time, not just at the end), to
    /// flush the interleaving queues.
    ///
    /// Packet's @ref AVPacket.stream_index "stream_index" field must be
    /// set to the index of the corresponding stream in @ref
    /// AVFormatContext.streams "s->streams".
    ///
    /// The timestamps (@ref AVPacket.pts "pts", @ref AVPacket.dts "dts")
    /// must be set to correct values in the stream's timebase (unless the
    /// output format is flagged with the AVFMT_NOTIMESTAMPS flag, then
    /// they can be set to AV_NOPTS_VALUE).
    ///
    /// The dts for subsequent packets in one stream must be strictly
    /// increasing (unless the output format is flagged with the
    /// AVFMT_TS_NONSTRICT, then they merely have to be nondecreasing).
    /// @ref AVPacket.duration "duration" should also be set if known.
    /// </param>
    /// <returns>
    /// 0 on success, a negative AVERROR on error.
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int av_interleaved_write_frame(Ptr<AVFormatContext> s, Ptr<AVPacket> pkt);

    /// <summary>
    /// Write an uncoded frame to an output media file.
    /// The frame must be correctly interleaved according to the container
    /// specification; if not, av_interleaved_write_uncoded_frame() must be used.
    /// See av_interleaved_write_uncoded_frame() for details.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="streamIndex"></param>
    /// <param name="frame"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_write_uncoded_frame(Ptr<AVFormatContext> s, int streamIndex, Ptr<AVFrame> frame);

    /// <summary>
    /// Write an uncoded frame to an output media file.
    /// If the muxer supports it, this function makes it possible to write an AVFrame
    /// structure directly, without encoding it into a packet.
    /// It is mostly useful for devices and similar special muxers that use raw
    /// video or PCM data and will not serialize it into a byte stream.
    /// To test whether it is possible to use it with a given muxer and stream,
    /// use av_write_uncoded_frame_query().
    /// The caller gives up ownership of the frame and must not access it
    /// afterwards.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="streamIndex"></param>
    /// <param name="frame"></param>
    /// <returns>>=0 for success, a negative code on error</returns>
    [DllImport(LibraryName)]
    public static extern int av_interleaved_write_uncoded_frame(Ptr<AVFormatContext> s, int streamIndex,
        Ptr<AVFrame> frame);

    /// <summary>
    /// Test whether a muxer supports uncoded frame.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="streamIndex"></param>
    /// <returns>
    /// >=0 if an uncoded frame can be written to that muxer and stream, &lt; 0 if not
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int av_write_uncoded_frame_query(Ptr<AVFormatContext> s, int streamIndex);

    /// <summary>
    /// Write the stream trailer to an output media file and free the
    /// file private data.
    /// May only be called after a successful call to avformat_write_header.
    /// </summary>
    /// <param name="s">media file handle</param>
    /// <returns>0 if OK, AVERROR_xxx on error</returns>
    [DllImport(LibraryName)]
    public static extern int av_write_trailer(Ptr<AVFormatContext> s);

    /// <summary>
    /// Return the output format in the list of registered output formats
    /// which best matches the provided parameters, or return NULL if
    /// there is no match.
    /// </summary>
    /// <param name="shortName">if non-NULL checks if short_name matches with the names of the registered formats</param>
    /// <param name="filename">if non-NULL checks if filename terminates with the extensions of the registered formats</param>
    /// <param name="mimeType">if non-NULL checks if mime_type matches with the MIME type of the registered formats</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVOutputFormat> av_guess_format(
        [MarshalAs(UnmanagedType.LPUTF8Str)] string shortName,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string filename,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string mimeType);

    /// <summary>
    /// Guess the codec ID based upon muxer and filename.
    /// </summary>
    /// <param name="fmt"></param>
    /// <param name="shortName"></param>
    /// <param name="filename"></param>
    /// <param name="mimeType"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVCodecID av_guess_codec(ConstPtr<AVOutputFormat> fmt,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string shortName, [MarshalAs(UnmanagedType.LPUTF8Str)] string filename,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string mimeType, AVMediaType type);

    /// <summary>
    /// Get timing information for the data currently output.
    /// The exact meaning of "currently output" depends on the format.
    /// It is mostly relevant for devices that have an internal buffer and/or
    /// work in real time.
    /// </summary>
    /// <param name="s">media file handle</param>
    /// <param name="stream">stream in the media file</param>
    /// <param name="dts">DTS of the last packet output for the stream, in stream time_base units</param>
    /// <param name="wall">absolute time when that packet whas output, in microsecond</param>
    /// <returns>0 if OK, AVERROR(ENOSYS) if the format does not support it</returns>
    /// <remarks>some formats or devices may not allow to measure dts and wall atomically.</remarks>
    [DllImport(LibraryName)]
    public static extern int av_get_output_timestamp(Ptr<AVFormatContext> s, int stream, out long dts,
        out long wall);

    /// <summary>
    /// Send a nice hexadecimal dump of a buffer to the specified file stream.
    /// </summary>
    /// <param name="f">The file stream pointer where the dump should be sent to.</param>
    /// <param name="buf">buffer</param>
    /// <param name="size">buffer size</param>
    [DllImport(LibraryName)]
    public static extern void av_hex_dump(Ptr<FILE> f, ConstPtr<byte> buf, int size);

    /// <summary>
    /// Send a nice hexadecimal dump of a buffer to the log.
    /// </summary>
    /// <param name="cl">A pointer to an arbitrary struct of which the first field is a pointer to an AVClass struct.</param>
    /// <param name="level">The importance level of the message, lower values signifying higher importance.</param>
    /// <param name="buf">buffer</param>
    /// <param name="size">buffer size</param>
    [DllImport(LibraryName)]
    public static extern void av_hex_dump_log(IntPtr cl, int level, ConstPtr<byte> buf, int size);

    /// <summary>
    /// Send a nice dump of a packet to the specified file stream.
    /// </summary>
    /// <param name="f">The file stream pointer where the dump should be sent to.</param>
    /// <param name="pkt">packet to dump</param>
    /// <param name="dumpPayload">True if the payload must be displayed, too.</param>
    /// <param name="st">AVStream that the packet belongs to</param>
    [DllImport(LibraryName)]
    public static extern void av_pkt_dump2(Ptr<FILE> f, ConstPtr<AVPacket> pkt, int dumpPayload,
        ConstPtr<AVStream> st);

    /// <summary>
    /// Send a nice dump of a packet to the log.
    /// </summary>
    /// <param name="cl">A pointer to an arbitrary struct of which the first field is a pointer to an AVClass struct.</param>
    /// <param name="level">The importance level of the message, lower values signifying higher importance.</param>
    /// <param name="pkt">packet to dump</param>
    /// <param name="dumpPayload">True if the payload must be displayed, too.</param>
    /// <param name="st">AVStream that the packet belongs to</param>
    [DllImport(LibraryName)]
    public static extern void av_pkt_dump_log2(IntPtr cl, int level, ConstPtr<AVPacket> pkt, int dumpPayload,
        ConstPtr<AVStream> st);

    /// <summary>
    /// Get the AVCodecID for the given codec tag tag. If no codec id is found returns AV_CODEC_ID_NONE.
    /// </summary>
    /// <param name="tags">List of supported codec_id-codec_tag pairs, as stored
    /// in AVInputFormat.codec_tag and AVOutputFormat.codec_tag.</param>
    /// <param name="tag">Codec tag to match to a codec ID.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVCodecID av_codec_get_id(ConstPtr<ConstPtr<AVCodecTag>> tags, uint tag);

    /// <summary>
    /// Get the codec tag for the given codec id. If no codec tag is found returns 0.
    /// </summary>
    /// <param name="tags">List of supported codec_id-codec_tag pairs, as stored
    /// in AVInputFormat.codec_tag and AVOutputFormat.codec_tag.</param>
    /// <param name="id">Codec id that should be searched for in the list.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint av_codec_get_tag(ConstPtr<ConstPtr<AVCodecTag>> tags, AVCodecID id);

    /// <summary>
    /// Get the codec tag for the given codec id.
    /// </summary>
    /// <param name="tags">List of supported codec_id-codec_tag pairs, as stored
    /// in AVInputFormat.codec_tag and AVOutputFormat.codec_tag.</param>
    /// <param name="id">Codec id that should be searched for in the list.</param>
    /// <param name="tag">A pointer to the found tag.</param>
    /// <returns>0 if id was not found in tags, > 0 if it was found.</returns>
    [DllImport(LibraryName)]
    public static extern int av_codec_get_tag2(ConstPtr<ConstPtr<AVCodecTag>> tags, AVCodecID id, out uint tag);

    [DllImport(LibraryName)]
    public static extern int av_find_default_stream_index(Ptr<AVFormatContext> s);

    /// <summary>
    /// Get the index for a specific timestamp.
    /// </summary>
    /// <param name="st">stream that the timestamp belongs to</param>
    /// <param name="timestamp">timestamp to retrieve the index for</param>
    /// <param name="flags">if AVSEEK_FLAG_BACKWARD then the returned index will correspond
    /// to the timestamp which is &lt;= the requested one, if backward
    /// is 0, then it will be >=
    /// if AVSEEK_FLAG_ANY seek to any frame, only keyframes otherwise</param>
    /// <returns>&lt; 0 if no such timestamp could be found</returns>
    [DllImport(LibraryName)]
    public static extern int av_index_search_timestamp(Ptr<AVStream> st, long timestamp, AVIOSeekFlags flags);

    /// <summary>
    /// Get the index entry count for the given AVStream.
    /// </summary>
    /// <param name="st">stream</param>
    /// <returns>the number of index entries in the stream</returns>
    [DllImport(LibraryName)]
    public static extern int avformat_index_get_entries_count(ConstPtr<AVStream> st);

    /// <summary>
    /// Get the AVIndexEntry corresponding to the given index.
    /// </summary>
    /// <param name="st">Stream containing the requested AVIndexEntry.</param>
    /// <param name="idx">The desired index.</param>
    /// <returns>A pointer to the requested AVIndexEntry if it exists, NULL otherwise.
    /// Note: The pointer returned by this function is only guaranteed to be valid
    /// until any function that takes the stream or the parent AVFormatContext
    /// as input argument is called.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVIndexEntry> avformat_index_get_entry(Ptr<AVStream> st, int idx);

    /// <summary>
    /// Get the AVIndexEntry corresponding to the given timestamp.
    /// </summary>
    /// <param name="st">Stream containing the requested AVIndexEntry.</param>
    /// <param name="wantedTimestamp">Timestamp to retrieve the index entry for.</param>
    /// <param name="flags">If AVSEEK_FLAG_BACKWARD then the returned entry will correspond
    /// to the timestamp which is &lt;= the requested one, if backward
    /// is 0, then it will be &gt;=
    /// if AVSEEK_FLAG_ANY seek to any frame, only keyframes otherwise.</param>
    /// <returns>A pointer to the requested AVIndexEntry if it exists, NULL otherwise.
    /// Note: The pointer returned by this function is only guaranteed to be valid
    /// until any function that takes the stream or the parent AVFormatContext
    /// as input argument is called.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVIndexEntry> avformat_index_get_entry_from_timestamp(Ptr<AVStream> st,
        long wantedTimestamp, AVIOSeekFlags flags);

    /// <summary>
    /// Add an index entry into a sorted list. Update the entry if the list
    /// already contains it.
    /// </summary>
    /// <param name="st"></param>
    /// <param name="pos"></param>
    /// <param name="timestamp">timestamp in the time base of the given stream</param>
    /// <param name="size"></param>
    /// <param name="distance"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_add_index_entry(Ptr<AVStream> st, long pos, long timestamp, int size,
        int distance, int flags);

    /// <summary>
    /// Split a URL string into components.
    ///
    /// The pointers to buffers for storing individual components may be null,
    /// in order to ignore that component. Buffers for components not found are
    /// set to empty strings. If the port is not found, it is set to a negative value.
    /// </summary>
    /// <param name="proto">the buffer for the protocol</param>
    /// <param name="protoSize">the size of the proto buffer</param>
    /// <param name="authorization">the buffer for the authorization</param>
    /// <param name="authorizationSize">the size of the authorization buffer</param>
    /// <param name="hostname">the buffer for the host name</param>
    /// <param name="hostnameSize">the size of the hostname buffer</param>
    /// <param name="port">a pointer to store the port number in</param>
    /// <param name="path">the buffer for the path</param>
    /// <param name="pathSize">the size of the path buffer</param>
    /// <param name="url">the URL to split</param>
    [DllImport(LibraryName)]
    public static extern void av_url_split(Ptr<byte> proto, int protoSize, Ptr<byte> authorization,
        int authorizationSize, Ptr<byte> hostname, int hostnameSize, out int port, Ptr<byte> path, int pathSize,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string url);

    /// <summary>
    /// Print detailed information about the input or output format, such as
    /// duration, bitrate, streams, container, programs, metadata, side data,
    /// codec and time base.
    /// </summary>
    /// <param name="ic">the context to analyze</param>
    /// <param name="index">index of the stream to dump information about</param>
    /// <param name="url">the URL to print, such as source or destination file</param>
    /// <param name="isOutput">Select whether the specified context is an input(0) or output(1)</param>
    [DllImport(LibraryName)]
    public static extern void av_dump_format(Ptr<AVFormatContext> ic, int index,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string url, int isOutput);

    /// <summary>
    /// Allow multiple %d
    /// </summary>
    public const int AV_FRAME_FILENAME_FLAGS_MULTIPLE = 1;

    /// <summary>
    /// Return in 'buf' the path with '%d' replaced by a number.
    ///
    /// Also handles the '%0nd' format where 'n' is the total number of digits and '%%'.
    /// </summary>
    /// <param name="buf">destination buffer</param>
    /// <param name="bufSize">destination buffer size</param>
    /// <param name="path">numbered sequence string</param>
    /// <param name="number">frame number</param>
    /// <param name="flags">AV_FRAME_FILENAME_FLAGS_*</param>
    /// <returns>0 if OK, -1 on format error</returns>
    [DllImport(LibraryName)]
    public static extern int av_get_frame_filename2(Ptr<byte> buf, int bufSize,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path, int number, AVFrameFilenameFlags flags);

    /// <summary>
    /// Return in 'buf' the path with '%d' replaced by a number.
    ///
    /// Also handles the '%0nd' format where 'n' is the total number of digits and '%%'.
    /// </summary>
    /// <param name="buf">destination buffer</param>
    /// <param name="bufSize">destination buffer size</param>
    /// <param name="path">numbered sequence string</param>
    /// <param name="number">frame number</param>
    /// <returns>0 if OK, -1 on format error</returns>
    [DllImport(LibraryName)]
    public static extern int av_get_frame_filename(Ptr<byte> buf, int bufSize,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string path, int number);

    /// <summary>
    /// Check whether filename actually is a numbered sequence generator.
    /// </summary>
    /// <param name="filename">possible numbered sequence string</param>
    /// <returns>1 if a valid numbered sequence string, 0 otherwise</returns>
    [DllImport(LibraryName)]
    public static extern int av_filename_number_test([MarshalAs(UnmanagedType.LPUTF8Str)] string filename);

    /// <summary>
    /// Generate an SDP for an RTP session.
    ///
    /// Note, this overwrites the id values of AVStreams in the muxer contexts
    /// for getting unique dynamic payload types.
    /// </summary>
    /// <param name="ac">array of AVFormatContexts describing the RTP streams. If the
    /// array is composed by only one context, such context can contain
    /// multiple AVStreams (one AVStream per RTP stream). Otherwise,
    /// all the contexts in the array (an AVCodecContext per RTP stream)
    /// must contain only one AVStream.</param>
    /// <param name="fileCount">number of AVCodecContexts contained in ac</param>
    /// <param name="buf">buffer where the SDP will be stored (must be allocated by the caller)</param>
    /// <param name="size">the size of the buffer</param>
    /// <returns>0 if OK, AVERROR_xxx on error</returns>
    [DllImport(LibraryName)]
    public static extern int av_sdp_create(Ptr<Ptr<AVFormatContext>> ac, int fileCount, Ptr<byte> buf, int size);

    /// <summary>
    /// Return a positive value if the given filename has one of the given
    /// extensions, 0 otherwise.
    /// </summary>
    /// <param name="filename">file name to check against the given extensions</param>
    /// <param name="extensions">a comma-separated list of filename extensions</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_match_ext([MarshalAs(UnmanagedType.LPUTF8Str)] string filename,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string extensions);

    /// <summary>
    /// Test if the given container can store a codec.
    /// </summary>
    /// <param name="format">container to check for compatibility</param>
    /// <param name="codecId">codec to potentially store in container</param>
    /// <param name="stdCompliance">standards compliance level, one of FF_COMPLIANCE_*</param>
    /// <returns>
    /// 1 if codec with ID codec_id can be stored in ofmt, 0 if it cannot.
    /// A negative number if this information is not available.
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int avformat_query_codec(ConstPtr<AVOutputFormat> format, AVCodecID codecId,
        AVStandardCompliance stdCompliance);

    /// <summary>
    /// Get the tables mapping RIFF FourCCs to libavcodec AVCodecIDs. The tables are
    /// meant to be passed to av_codec_get_id()/av_codec_get_tag() as in the
    /// following code:
    /// uint32_t tag = MKTAG('H', '2', '6', '4');
    /// const struct AVCodecTag *table[] = { avformat_get_riff_video_tags(), 0 };
    /// enum AVCodecID id = av_codec_get_id(table, tag);
    /// </summary>
    /// <returns>the table mapping RIFF FourCCs for video to libavcodec AVCodecID.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodecTag> avformat_get_riff_video_tags();

    /// <summary>
    /// Get the tables mapping RIFF FourCCs to libavcodec AVCodecIDs. The tables are
    /// meant to be passed to av_codec_get_id()/av_codec_get_tag() as in the
    /// following code:
    /// uint32_t tag = MKTAG('H', '2', '6', '4');
    /// const struct AVCodecTag *table[] = { avformat_get_riff_video_tags(), 0 };
    /// enum AVCodecID id = av_codec_get_id(table, tag);
    /// </summary>
    /// <returns>the table mapping RIFF FourCCs for audio to AVCodecID.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodecTag> avformat_get_riff_audio_tags();

    /// <summary>
    /// Get the tables mapping RIFF FourCCs to libavcodec AVCodecIDs. The tables are
    /// meant to be passed to av_codec_get_id()/av_codec_get_tag() as in the
    /// following code:
    /// uint32_t tag = MKTAG('H', '2', '6', '4');
    /// const struct AVCodecTag *table[] = { avformat_get_riff_video_tags(), 0 };
    /// enum AVCodecID id = av_codec_get_id(table, tag);
    /// </summary>
    /// <returns>the table mapping MOV FourCCs for video to libavcodec AVCodecID.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodecTag> avformat_get_mov_video_tags();

    /// <summary>
    /// Get the tables mapping RIFF FourCCs to libavcodec AVCodecIDs. The tables are
    /// meant to be passed to av_codec_get_id()/av_codec_get_tag() as in the
    /// following code:
    /// uint32_t tag = MKTAG('H', '2', '6', '4');
    /// const struct AVCodecTag *table[] = { avformat_get_riff_video_tags(), 0 };
    /// enum AVCodecID id = av_codec_get_id(table, tag);
    /// </summary>
    /// <returns>the table mapping MOV FourCCs for audio to AVCodecID.</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodecTag> avformat_get_mov_audio_tags();

    /// <summary>
    /// Guess the sample aspect ratio of a frame, based on both the stream and the
    /// frame aspect ratio.
    ///
    /// Since the frame aspect ratio is set by the codec but the stream aspect ratio
    /// is set by the demuxer, these two may not be equal. This function tries to
    /// return the value that you should use if you would like to display the frame.
    ///
    /// Basic logic is to use the stream aspect ratio if it is set to something sane
    /// otherwise use the frame aspect ratio. This way a container setting, which is
    /// usually easy to modify can override the coded value in the frames.
    /// </summary>
    /// <param name="format">the format context which the stream is part of</param>
    /// <param name="stream">the stream which the frame is part of</param>
    /// <param name="frame">the frame with the aspect ratio to be determined</param>
    /// <returns>the guessed (valid) sample_aspect_ratio, 0/1 if no idea</returns>
    [DllImport(LibraryName)]
    public static extern AVRational av_guess_sample_aspect_ratio(Ptr<AVFormatContext> format, Ptr<AVStream> stream,
        Ptr<AVFrame> frame);

    /// <summary>
    /// Guess the frame rate, based on both the container and codec information.
    /// </summary>
    /// <param name="ctx">the format context which the stream is part of</param>
    /// <param name="stream">the stream which the frame is part of</param>
    /// <param name="frame">the frame for which the frame rate should be determined, may be NULL</param>
    /// <returns>the guessed (valid) frame rate, 0/1 if no idea</returns>
    [DllImport(LibraryName)]
    public static extern AVRational av_guess_frame_rate(Ptr<AVFormatContext> ctx, Ptr<AVStream> stream,
        Ptr<AVFrame> frame);

    /// <summary>
    /// Check if the stream st contained in s is matched by the stream specifier spec.
    ///
    /// See the "stream specifiers" chapter in the documentation for the syntax of spec.
    ///
    /// A stream specifier can match several streams in the format.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="st"></param>
    /// <param name="spec"></param>
    /// <returns> >0 if st is matched by spec; 0  if st is not matched by spec; AVERROR code if spec is invalid</returns>
    [DllImport(LibraryName)]
    public static extern int avformat_match_stream_specifier(Ptr<AVFormatContext> s, Ptr<AVStream> st,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string spec);

    [DllImport(LibraryName)]
    public static extern int avformat_queue_attached_pictures(Ptr<AVFormatContext> s);

    /// <summary>
    /// Transfer internal timing information from one stream to another.
    ///
    /// This function is useful when doing stream copy.
    /// </summary>
    /// <param name="ofmt">target output format for ost</param>
    /// <param name="ost">output stream which needs timings copy and adjustments</param>
    /// <param name="ist">reference input stream to copy timings from</param>
    /// <param name="copyTb">define from where the stream codec timebase needs to be imported</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int avformat_transfer_internal_stream_timing_info(ConstPtr<AVOutputFormat> ofmt,
        Ptr<AVStream> ost, ConstPtr<AVStream> ist, AVTimebaseSource copyTb);

    /// <summary>
    /// Get the internal codec timebase from a stream.
    /// </summary>
    /// <param name="st">input stream to extract the timebase from</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVRational av_stream_get_codec_timebase(Ptr<AVStream> st);
}
