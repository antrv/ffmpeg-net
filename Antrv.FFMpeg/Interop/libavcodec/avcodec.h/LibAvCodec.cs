namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    public const int AV_INPUT_BUFFER_MIN_SIZE = 16384;

    public const int FF_COMPRESSION_DEFAULT = -1;

    public const int FF_LEVEL_UNKNOWN = -99;

    public const int AV_PARSER_PTS_NB = 4;

    /// <summary>
    /// Return the LIBAVCODEC_VERSION_INT constant.
    /// </summary>
    [DllImport(LibraryName)]
    public static extern uint avcodec_version();

    /// <summary>
    /// Return the libavcodec build-time configuration.
    /// </summary>
    [DllImport(LibraryName)]
    public static extern IntPtr avcodec_configuration();

    /// <summary>
    /// Return the libavcodec license.
    /// </summary>
    [DllImport(LibraryName)]
    public static extern IntPtr avcodec_license();

    /// <summary>
    /// Allocate an AVCodecContext and set its fields to default values. The
    /// resulting struct should be freed with avcodec_free_context().
    /// </summary>
    /// <param name="codec">if non-NULL, allocate private data and initialize defaults
    /// for the given codec. It is illegal to then call avcodec_open2()
    /// with a different codec.
    /// If NULL, then the codec-specific defaults won't be initialized,
    /// which may result in suboptimal default settings (this is
    /// important mainly for encoders, e.g. libx264).</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVCodecContext> avcodec_alloc_context3(ConstPtr<AVCodec> codec);

    /// <summary>
    /// Free the codec context and everything associated with it and write NULL to
    /// the provided pointer.
    /// </summary>
    /// <param name="ctx"></param>
    [DllImport(LibraryName)]
    public static extern void avcodec_free_context(ref Ptr<AVCodecContext> ctx);

    /// <summary>
    /// Get the AVClass for AVCodecContext. It can be used in combination with
    /// AV_OPT_SEARCH_FAKE_OBJ for examining options.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVClass> avcodec_get_class();

    /// <summary>
    /// Get the AVClass for AVSubtitleRect. It can be used in combination with
    /// AV_OPT_SEARCH_FAKE_OBJ for examining options.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVClass> avcodec_get_subtitle_rect_class();

    /// <summary>
    /// Fill the parameters struct based on the values from the supplied codec
    /// context. Any allocated fields in par are freed and replaced with duplicates
    /// of the corresponding fields in codec.
    /// </summary>
    /// <param name="parameters"></param>
    /// <param name="codec"></param>
    /// <returns>>= 0 on success, a negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_parameters_from_context(Ptr<AVCodecParameters> parameters,
        ConstPtr<AVCodecContext> codec);

    /// <summary>
    /// Fill the codec context based on the values from the supplied codec
    /// parameters. Any allocated fields in codec that have a corresponding field in
    /// par are freed and replaced with duplicates of the corresponding field in par.
    /// Fields in codec that do not have a counterpart in par are not touched.
    /// </summary>
    /// <param name="codec"></param>
    /// <param name="parameters"></param>
    /// <returns>>= 0 on success, a negative AVERROR code on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_parameters_to_context(Ptr<AVCodecContext> codec,
        ConstPtr<AVCodecParameters> parameters);

    /// <summary>
    /// Initialize the AVCodecContext to use the given AVCodec. Prior to using this
    /// function the context has to be allocated with avcodec_alloc_context3().
    ///
    /// Always call this function before using decoding routines (such as avcodec_receive_frame()).
    /// </summary>
    /// <param name="ctx">The context to initialize.</param>
    /// <param name="codec">The codec to open this context for. If a non-NULL codec has been
    /// previously passed to avcodec_alloc_context3() or
    /// for this context, then this parameter MUST be either NULL or
    /// equal to the previously passed codec.
    /// </param>
    /// <param name="options">
    /// A dictionary filled with AVCodecContext and codec-private options.
    /// On return this object will be filled with options that were not found.
    /// </param>
    /// <returns>zero on success, a negative value on error</returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_open2(Ptr<AVCodecContext> ctx, ConstPtr<AVCodec> codec, ref Ptr<AVDictionary> options);

    /// <summary>
    /// Close a given AVCodecContext and free all the data associated with it
    /// (but not the AVCodecContext itself).
    ///
    /// Calling this function on an AVCodecContext that hasn't been opened will free
    /// the codec-specific data allocated in avcodec_alloc_context3() with a non-NULL
    /// codec. Subsequent calls will do nothing.
    ///
    /// Do not use this function. Use avcodec_free_context() to destroy a
    /// codec context (either open or closed). Opening and closing a codec context
    /// multiple times is not supported anymore -- use multiple codec contexts instead.
    /// </summary>
    /// <param name="ctx"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_close(Ptr<AVCodecContext> ctx);

    /// <summary>
    /// Free all allocated data in the given subtitle struct.
    /// </summary>
    /// <param name="sub">AVSubtitle to free.</param>
    [DllImport(LibraryName)]
    public static extern void avsubtitle_free(Ptr<AVSubtitle> sub);

    /// <summary>
    /// The default callback for AVCodecContext.get_buffer2(). It is made public so
    /// it can be called by custom get_buffer2() implementations for decoders without
    /// AV_CODEC_CAP_DR1 set.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="frame"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_default_get_buffer2(Ptr<AVCodecContext> s, Ptr<AVFrame> frame, int flags);

    /// <summary>
    /// The default callback for AVCodecContext.get_encode_buffer(). It is made public so
    /// it can be called by custom get_encode_buffer() implementations for encoders without
    /// AV_CODEC_CAP_DR1 set.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="pkt"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_default_get_encode_buffer(Ptr<AVCodecContext> s, Ptr<AVPacket> pkt, int flags);

    /// <summary>
    /// Modify width and height values so that they will result in a memory
    /// buffer that is acceptable for the codec if you do not use any horizontal
    /// padding.
    /// May only be used if a codec with AV_CODEC_CAP_DR1 has been opened.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    [DllImport(LibraryName)]
    public static extern void avcodec_align_dimensions(Ptr<AVCodecContext> s, ref int width, ref int height);

    /// <summary>
    /// Modify width and height values so that they will result in a memory
    /// buffer that is acceptable for the codec if you also ensure that all
    /// line sizes are a multiple of the respective linesize_align[i].
    /// May only be used if a codec with AV_CODEC_CAP_DR1 has been opened.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="lineSizeAlign">AV_NUM_DATA_POINTERS size</param>
    [DllImport(LibraryName)]
    public static extern void avcodec_align_dimensions2(Ptr<AVCodecContext> s, ref int width, ref int height,
        ref Array8<int> lineSizeAlign);

    /// <summary>
    /// Converts AVChromaLocation to swscale x/y chroma position.
    /// The positions represent the chroma (0,0) position in a coordinates system
    /// with luma (0,0) representing the origin and luma(1,1) representing 256,256
    /// </summary>
    /// <param name="xpos">horizontal chroma sample position</param>
    /// <param name="ypos">vertical chroma sample position</param>
    /// <param name="pos"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_enum_to_chroma_pos(ref int xpos, ref int ypos, AVChromaLocation pos);

    /// <summary>
    /// Converts swscale x/y chroma position to AVChromaLocation.
    /// The positions represent the chroma (0,0) position in a coordinates system
    /// with luma (0,0) representing the origin and luma(1,1) representing 256,256
    /// </summary>
    /// <param name="xpos">horizontal chroma sample position</param>
    /// <param name="ypos">vertical chroma sample position</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVChromaLocation avcodec_chroma_pos_to_enum(int xpos, int ypos);

    /// <summary>
    /// Decode a subtitle message.
    /// Return a negative value on error, otherwise return the number of bytes used.
    /// If no subtitle could be decompressed, got_sub_ptr is zero.
    /// Otherwise, the subtitle is stored in *sub.
    /// Note that AV_CODEC_CAP_DR1 is not available for subtitle codecs. This is for
    /// simplicity, because the performance difference is expected to be negligible
    /// and reusing a get_buffer written for video codecs would probably perform badly
    /// due to a potentially very different allocation pattern.
    ///
    /// Some decoders (those marked with AV_CODEC_CAP_DELAY) have a delay between input
    /// and output. This means that for some packets they will not immediately
    /// produce decoded output and need to be flushed at the end of decoding to get
    /// all the decoded data. Flushing is done by calling this function with packets
    /// with avpkt->data set to NULL and avpkt->size set to 0 until it stops
    /// returning subtitles. It is safe to flush even those decoders that are not
    /// marked with AV_CODEC_CAP_DELAY, then no subtitles will be returned.
    ///
    /// The AVCodecContext MUST have been opened with @ref avcodec_open2()
    /// before packets may be fed to the decoder.
    /// </summary>
    /// <param name="ctx">the codec context</param>
    /// <param name="sub">The preallocated AVSubtitle in which the decoded subtitle will be stored,
    /// must be freed with avsubtitle_free if *got_sub_ptr is set.</param>
    /// <param name="gotSubPtr">Zero if no subtitle could be decompressed, otherwise, it is nonzero.</param>
    /// <param name="pkt">The input AVPacket containing the input buffer.</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_decode_subtitle2(Ptr<AVCodecContext> ctx, Ptr<AVSubtitle> sub, ref int gotSubPtr,
        Ptr<AVPacket> pkt);

    /// <summary>
    /// Supply raw packet data as input to a decoder.
    ///
    /// Internally, this call will copy relevant AVCodecContext fields, which can
    /// influence decoding per-packet, and apply them when the packet is actually
    /// decoded. (For example AVCodecContext.skip_frame, which might direct the
    /// decoder to drop the frame contained by the packet sent with this function.)
    ///
    /// The input buffer, avpkt->data must be AV_INPUT_BUFFER_PADDING_SIZE
    /// larger than the actual read bytes because some optimized bitstream
    /// readers read 32 or 64 bits at once and could read over the end.
    ///
    /// The AVCodecContext MUST have been opened with @ref avcodec_open2()
    /// before packets may be fed to the decoder.
    /// </summary>
    /// <param name="ctx">codec context</param>
    /// <param name="pkt">The input AVPacket. Usually, this will be a single video
    /// frame, or several complete audio frames. Ownership of the packet remains with the caller, and the
    /// decoder will not write to the packet. The decoder may create
    /// a reference to the packet data (or copy it if the packet is
    /// not reference-counted).
    /// Unlike with older APIs, the packet is always fully consumed,
    /// and if it contains multiple frames (e.g. some audio codecs),
    /// will require you to call avcodec_receive_frame() multiple
    /// times afterwards before you can send a new packet.
    /// It can be NULL (or an AVPacket with data set to NULL and
    /// size set to 0); in this case, it is considered a flush
    /// packet, which signals the end of the stream. Sending the
    /// first flush packet will return success. Subsequent ones are
    /// unnecessary and will return AVERROR_EOF. If the decoder
    /// still has frames buffered, it will return them after sending
    /// a flush packet.</param>
    /// <returns>
    /// 0 on success, otherwise negative error code:
    /// AVERROR(EAGAIN):   input is not accepted in the current state - user
    /// must read output with avcodec_receive_frame() (once
    /// all output is read, the packet should be resent, and
    /// the call will not fail with EAGAIN).
    ///
    /// AVERROR_EOF:       the decoder has been flushed, and no new packets can
    /// be sent to it (also returned if more than 1 flush
    /// packet is sent)
    ///
    /// AVERROR(EINVAL):   codec not opened, it is an encoder, or requires flush
    /// AVERROR(ENOMEM):   failed to add packet to internal queue, or similar
    /// other errors: legitimate decoding errors
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_send_packet(Ptr<AVCodecContext> ctx, ConstPtr<AVPacket> pkt);

    /// <summary>
    /// Return decoded output data from a decoder.
    /// </summary>
    /// <param name="ctx">codec context</param>
    /// <param name="frame">This will be set to a reference-counted video or audio frame
    /// (depending on the decoder type) allocated by the
    /// decoder. Note that the function will always call
    /// av_frame_unref(frame) before doing anything else.
    /// </param>
    /// <returns>
    /// 0:                 success, a frame was returned
    /// AVERROR(EAGAIN):   output is not available in this state - user must try to send new input
    /// AVERROR_EOF:       the decoder has been fully flushed, and there will be no more output frames
    /// AVERROR(EINVAL):   codec not opened, or it is an encoder
    /// AVERROR_INPUT_CHANGED:   current decoded frame has changed parameters with respect
    /// to first decoded frame. Applicable when flag AV_CODEC_FLAG_DROPCHANGED is set.
    /// other negative values: legitimate decoding errors
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_receive_frame(Ptr<AVCodecContext> ctx, ConstPtr<AVFrame> frame);

    /// <summary>
    /// Supply a raw video or audio frame to the encoder. Use avcodec_receive_packet()
    /// to retrieve buffered output packets.
    /// </summary>
    /// <param name="ctx">codec context</param>
    /// <param name="frame">AVFrame containing the raw audio or video frame to be encoded.
    /// Ownership of the frame remains with the caller, and the
    /// encoder will not write to the frame. The encoder may create
    /// a reference to the frame data (or copy it if the frame is
    /// not reference-counted).
    /// It can be NULL, in which case it is considered a flush
    /// packet.  This signals the end of the stream. If the encoder
    /// still has packets buffered, it will return them after this
    /// call. Once flushing mode has been entered, additional flush
    /// packets are ignored, and sending frames will return
    /// AVERROR_EOF.
    ///
    /// For audio:
    /// If AV_CODEC_CAP_VARIABLE_FRAME_SIZE is set, then each frame
    /// can have any number of samples.
    /// If it is not set, frame->nb_samples must be equal to
    /// ctx->frame_size for all frames except the last.
    /// The final frame may be smaller than ctx->frame_size.
    /// </param>
    /// <returns>
    /// 0 on success, otherwise negative error code:
    /// AVERROR(EAGAIN):   input is not accepted in the current state - user
    /// must read output with avcodec_receive_packet() (once
    /// all output is read, the packet should be resent, and
    /// the call will not fail with EAGAIN).
    /// AVERROR_EOF:       the encoder has been flushed, and no new frames can be sent to it
    /// AVERROR(EINVAL):   codec not opened, it is a decoder, or requires flush
    /// AVERROR(ENOMEM):   failed to add packet to internal queue, or similar
    /// other errors: legitimate encoding errors
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_send_frame(Ptr<AVCodecContext> ctx, Ptr<AVFrame> frame);

    /// <summary>
    /// Read encoded data from the encoder.
    /// </summary>
    /// <param name="ctx">codec context</param>
    /// <param name="pkt">This will be set to a reference-counted packet allocated by the
    /// encoder. Note that the function will always call
    /// av_packet_unref(avpkt) before doing anything else.</param>
    /// <returns>
    /// 0 on success, otherwise negative error code:
    /// AVERROR(EAGAIN):   output is not available in the current state - user must try to send input
    /// AVERROR_EOF:       the encoder has been fully flushed, and there will be no more output packets
    /// AVERROR(EINVAL):   codec not opened, or it is a decoder
    /// other errors: legitimate encoding errors
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_receive_packet(Ptr<AVCodecContext> ctx, Ptr<AVPacket> pkt);

    /// <summary>
    /// Create and return a AVHWFramesContext with values adequate for hardware
    /// decoding. This is meant to get called from the get_format callback, and is
    /// a helper for preparing a AVHWFramesContext for AVCodecContext.hw_frames_ctx.
    /// This API is for decoding with certain hardware acceleration modes/APIs only.
    ///
    /// The returned AVHWFramesContext is not initialized. The caller must do this
    /// with av_hwframe_ctx_init().
    ///
    /// Calling this function is not a requirement, but makes it simpler to avoid
    /// codec or hardware API specific details when manually allocating frames.
    ///
    /// Alternatively to this, an API user can set AVCodecContext.hw_device_ctx,
    /// which sets up AVCodecContext.hw_frames_ctx fully automatically, and makes
    /// it unnecessary to call this function or having to care about
    /// AVHWFramesContext initialization at all.
    ///
    /// There are a number of requirements for calling this function:
    /// - It must be called from get_format with the same avctx parameter that was
    ///   passed to get_format. Calling it outside of get_format is not allowed, and
    ///   can trigger undefined behavior.
    /// - The function is not always supported (see description of return values).
    ///   Even if this function returns successfully, hwaccel initialization could
    ///   fail later. (The degree to which implementations check whether the stream
    ///   is actually supported varies. Some do this check only after the user's
    ///   get_format callback returns.)
    /// - The hw_pix_fmt must be one of the choices suggested by get_format. If the
    ///   user decides to use a AVHWFramesContext prepared with this API function,
    ///   the user must return the same hw_pix_fmt from get_format.
    /// - The device_ref passed to this function must support the given hw_pix_fmt.
    /// - After calling this API function, it is the user's responsibility to
    ///   initialize the AVHWFramesContext (returned by the out_frames_ref parameter),
    ///   and to set AVCodecContext.hw_frames_ctx to it. If done, this must be done
    ///   before returning from get_format (this is implied by the normal
    ///   AVCodecContext.hw_frames_ctx API rules).
    /// - The AVHWFramesContext parameters may change every time time get_format is
    ///   called. Also, AVCodecContext.hw_frames_ctx is reset before get_format. So
    ///   you are inherently required to go through this process again on every
    ///   get_format call.
    /// - It is perfectly possible to call this function without actually using
    ///   the resulting AVHWFramesContext. One use-case might be trying to reuse a
    ///   previously initialized AVHWFramesContext, and calling this API function
    ///   only to test whether the required frame parameters have changed.
    /// - Fields that use dynamically allocated values of any kind must not be set
    ///   by the user unless setting them is explicitly allowed by the documentation.
    ///   If the user sets AVHWFramesContext.free and AVHWFramesContext.user_opaque,
    ///   the new free callback must call the potentially set previous free callback.
    ///   This API call may set any dynamically allocated fields, including the free
    ///   callback.
    ///
    /// The function will set at least the following fields on AVHWFramesContext
    /// (potentially more, depending on hwaccel API):
    ///
    /// - All fields set by av_hwframe_ctx_alloc().
    /// - Set the format field to hw_pix_fmt.
    /// - Set the sw_format field to the most suited and most versatile format. (An
    ///   implication is that this will prefer generic formats over opaque formats
    ///   with arbitrary restrictions, if possible.)
    /// - Set the width/height fields to the coded frame size, rounded up to the
    ///   API-specific minimum alignment.
    /// - Only _if_ the hwaccel requires a pre-allocated pool: set the initial_pool_size
    ///   field to the number of maximum reference surfaces possible with the codec,
    ///   plus 1 surface for the user to work (meaning the user can safely reference
    ///   at most 1 decoded surface at a time), plus additional buffering introduced
    ///   by frame threading. If the hwaccel does not require pre-allocation, the
    ///   field is left to 0, and the decoder will allocate new surfaces on demand
    ///   during decoding.
    /// - Possibly AVHWFramesContext.hwctx fields, depending on the underlying
    ///   hardware API.
    ///
    /// Essentially, out_frames_ref returns the same as av_hwframe_ctx_alloc(), but
    /// with basic frame parameters set.
    ///
    /// The function is stateless, and does not change the AVCodecContext or the
    /// device_ref AVHWDeviceContext.
    /// </summary>
    /// <param name="ctx">The context which is currently calling get_format, and which
    /// implicitly contains all state needed for filling the returned
    /// AVHWFramesContext properly.</param>
    /// <param name="deviceRef">A reference to the AVHWDeviceContext describing the device
    /// which will be used by the hardware decoder.</param>
    /// <param name="hwPixelFormat">The hwaccel format you are going to return from get_format.</param>
    /// <param name="outFramesRef">On success, set to a reference to an _uninitialized_
    /// AVHWFramesContext, created from the given device_ref.
    /// Fields will be set to values required for decoding.
    /// Not changed if an error is returned.
    /// </param>
    /// <returns>
    /// zero on success, a negative value on error. The following error codes
    /// have special semantics:
    /// AVERROR(ENOENT): the decoder does not support this functionality. Setup
    /// is always manual, or it is a decoder which does not
    /// support setting AVCodecContext.hw_frames_ctx at all,
    /// or it is a software format.
    /// AVERROR(EINVAL): it is known that hardware decoding is not supported for
    /// this configuration, or the device_ref is not supported
    /// for the hwaccel referenced by hw_pix_fmt.
    /// </returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_get_hw_frames_parameters(Ptr<AVCodecContext> ctx, Ptr<AVBufferRef> deviceRef,
        AVPixelFormat hwPixelFormat, out Ptr<AVBufferRef> outFramesRef);

    /// <summary>
    /// Iterate over all registered codec parsers.
    /// </summary>
    /// <param name="opaque">a pointer where libavcodec will store the iteration state. Must
    /// point to NULL to start the iteration.</param>
    /// <returns>the next registered codec parser or NULL when the iteration is finished</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVCodecParser> av_parser_iterate(ref IntPtr opaque);

    [DllImport(LibraryName)]
    public static extern Ptr<AVCodecParserContext> av_parser_init(AVCodecID codecId);

    /// <summary>
    /// Parse a packet.
    /// </summary>
    /// <param name="s">parser context.</param>
    /// <param name="ctx">codec context.</param>
    /// <param name="outBuffer">set to pointer to parsed buffer or NULL if not yet finished.</param>
    /// <param name="outBufferSize">set to size of parsed buffer or zero if not yet finished.</param>
    /// <param name="buffer">input buffer.</param>
    /// <param name="bufferSize">buffer size in bytes without the padding. I.e. the full buffer
    /// size is assumed to be buf_size + AV_INPUT_BUFFER_PADDING_SIZE.
    /// To signal EOF, this should be 0 (so that the last frame can be output).</param>
    /// <param name="pts">input presentation timestamp.</param>
    /// <param name="dts">input decoding timestamp.</param>
    /// <param name="pos">input byte position in stream.</param>
    /// <returns>the number of bytes of the input bitstream used.</returns>
    [DllImport(LibraryName)]
    public static extern int av_parser_parse2(Ptr<AVCodecParserContext> s, Ptr<AVCodecContext> ctx,
        out Ptr<byte> outBuffer, out int outBufferSize, Ptr<byte> buffer, int bufferSize, long pts, long dts, long pos);

    [DllImport(LibraryName)]
    public static extern void av_parser_close(Ptr<AVCodecParserContext> s);

    [DllImport(LibraryName)]
    public static extern int avcodec_encode_subtitle(Ptr<AVCodecContext> ctx, Ptr<byte> buffer, int bufferSize,
        ConstPtr<AVSubtitle> subtitle);

    /// <summary>
    /// Return a value representing the fourCC code associated to the
    /// pixel format pix_fmt, or 0 if no associated fourCC code can be
    /// found.
    /// </summary>
    /// <param name="pixelFormat"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint avcodec_pix_fmt_to_codec_tag(AVPixelFormat pixelFormat);

    /// <summary>
    /// Find the best pixel format to convert to given a certain source pixel
    /// format.  When converting from one pixel format to another, information loss
    /// may occur.  For example, when converting from RGB24 to GRAY, the color
    /// information will be lost. Similarly, other losses occur when converting from
    /// some formats to other formats. avcodec_find_best_pix_fmt_of_2() searches which of
    /// the given pixel formats should be used to suffer the least amount of loss.
    /// The pixel formats from which it chooses one, are determined by the
    /// pix_fmt_list parameter.
    /// </summary>
    /// <param name="pixFmtList">AV_PIX_FMT_NONE terminated array of pixel formats to choose from</param>
    /// <param name="srcPixFmt">source pixel format</param>
    /// <param name="hasAlpha">Whether the source pixel format alpha channel is used.</param>
    /// <param name="loss">Combination of flags informing you what kind of losses will occur.</param>
    /// <returns>The best pixel format to convert to or -1 if none was found.</returns>
    [DllImport(LibraryName)]
    public static extern AVPixelFormat avcodec_find_best_pix_fmt_of_list(ConstPtr<AVPixelFormat> pixFmtList,
        AVPixelFormat srcPixFmt, int hasAlpha, out int loss);

    [DllImport(LibraryName)]
    public static extern AVPixelFormat avcodec_default_get_format(ConstPtr<AVCodecContext> s,
        ConstPtr<AVPixelFormat> fmt);

    [DllImport(LibraryName)]
    public static extern void avcodec_string(Ptr<byte> buffer, int bufferSize, Ptr<AVCodecContext> enc, int encode);

    [DllImport(LibraryName)]
    public static extern int avcodec_default_execute(Ptr<AVCodecContext> c,
        FuncPtr<Ptr<AVCodecContext>, IntPtr, int> func, IntPtr arg, out int ret, int count, int size);

    [DllImport(LibraryName)]
    public static extern int avcodec_default_execute2(Ptr<AVCodecContext> c,
        FuncPtr<Ptr<AVCodecContext>, IntPtr, int, int, int> func, IntPtr arg, out int ret, int count);

    /// <summary>
    /// Fill AVFrame audio data and linesize pointers.
    ///
    /// The buffer buf must be a preallocated buffer with a size big enough
    /// to contain the specified samples amount. The filled AVFrame data
    /// pointers will point to this buffer.
    ///
    /// AVFrame extended_data channel pointers are allocated if necessary for planar audio.
    /// </summary>
    /// <param name="frame">the AVFrame
    /// frame->nb_samples must be set prior to calling the
    /// function. This function fills in frame->data,
    /// frame->extended_data, frame->linesize[0].</param>
    /// <param name="channels">channel count</param>
    /// <param name="sampleFmt">sample format</param>
    /// <param name="buf">buffer to use for frame data</param>
    /// <param name="bufSize">size of buffer</param>
    /// <param name="align">plane size sample alignment (0 = default)</param>
    /// <returns>&gt;=0 on success, negative error code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_fill_audio_frame(Ptr<AVFrame> frame, int channels, AVSampleFormat sampleFmt,
        ConstPtr<byte> buf, int bufSize, int align);

    /// <summary>
    /// Reset the internal codec state / flush internal buffers. Should be called
    /// e.g. when seeking or when switching to a different stream.
    ///
    /// Note: for decoders, this function just releases any references the decoder
    /// might keep internally, but the caller's references remain valid.
    /// Note: for encoders, this function will only do something if the encoder
    /// declares support for AV_CODEC_CAP_ENCODER_FLUSH. When called, the encoder
    /// will drain any remaining packets, and can then be re-used for a different
    /// stream (as opposed to sending a null frame which will leave the encoder
    /// in a permanent EOF state after draining). This can be desirable if the
    /// cost of tearing down and replacing the encoder instance is high.
    /// </summary>
    /// <param name="ctx"></param>
    [DllImport(LibraryName)]
    public static extern void avcodec_flush_buffers(Ptr<AVCodecContext> ctx);

    /// <summary>
    /// Return audio frame duration.
    /// </summary>
    /// <param name="ctx">codec context</param>
    /// <param name="frameBytes">size of the frame, or 0 if unknown</param>
    /// <returns>frame duration, in samples, if known. 0 if not able to determine.</returns>
    [DllImport(LibraryName)]
    public static extern int av_get_audio_frame_duration(Ptr<AVCodecContext> ctx, int frameBytes);

    /// <summary>
    /// Same behaviour av_fast_malloc but the buffer has additional
    /// AV_INPUT_BUFFER_PADDING_SIZE at the end which will always be 0.
    ///
    /// In addition the whole buffer will initially and after resizes
    /// be 0-initialized so that no uninitialized data will ever appear.
    /// </summary>
    /// <param name="ptr"></param>
    /// <param name="size"></param>
    /// <param name="minSize"></param>
    [DllImport(LibraryName)]
    public static extern void av_fast_padded_malloc(IntPtr ptr, ref uint size, nuint minSize);

    /// <summary>
    /// Same behaviour av_fast_padded_malloc except that buffer will always
    /// be 0-initialized after call.
    /// </summary>
    /// <param name="ptr"></param>
    /// <param name="size"></param>
    /// <param name="minSize"></param>
    [DllImport(LibraryName)]
    public static extern void av_fast_padded_mallocz(IntPtr ptr, ref uint size, nuint minSize);

    /// <summary>
    /// Returns a positive value if s is open (i.e. avcodec_open2() was called on it
    /// with no corresponding avcodec_close()), 0 otherwise.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int avcodec_is_open(Ptr<AVCodecContext> s);
}
