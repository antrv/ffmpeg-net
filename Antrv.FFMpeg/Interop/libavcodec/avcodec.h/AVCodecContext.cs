namespace Antrv.FFMpeg.Interop;

using DrawHorizBandDelegate = ActionPtr<Ptr<AVCodecContext>, Ptr<AVFrame>, Array8<int>, int, int, int>;
using GetFormatDelegate = FuncPtr<Ptr<AVCodecContext>, ConstPtr<AVPixelFormat>, AVPixelFormat>;
using GetBuffer2Delegate = FuncPtr<Ptr<AVCodecContext>, Ptr<AVFrame>, int, AVGetBufferFlags>;
using ExecuteDelegate = FuncPtr<Ptr<AVCodecContext>, FuncPtr<Ptr<AVCodecContext>, IntPtr, int>, IntPtr, Ptr<int>, int, int>;
using Execute2Delegate = FuncPtr<Ptr<AVCodecContext>, FuncPtr<Ptr<AVCodecContext>, IntPtr, int, int, int>, IntPtr, Ptr<int>, int, int>;
using GetEncodeBufferDelegate = FuncPtr<Ptr<AVCodecContext>, Ptr<AVPacket>, AVGetBufferFlags, int>;

/// <summary>
/// main external API structure.
/// New fields can be added to the end with minor version bumps.
/// Removal, reordering and changes to existing fields require a major version bump.
/// You can use AVOptions (av_opt* / av_set/get*()) to access these fields from user applications.
/// The name string for AVOptions options matches the associated command line
/// parameter name and can be found in libavcodec/options_table.h
/// The AVOption/command line parameter names differ in some cases from the C
/// structure field names for historic reasons or brevity.
/// sizeof(AVCodecContext) must not be used outside libav*.
/// </summary>
public struct AVCodecContext
{
    /// <summary>
    /// information on struct for av_log
    /// - set by avcodec_alloc_context3
    /// </summary>
    public ConstPtr<AVClass> Class;

    public int LogLevelOffset;

    public AVMediaType CodecType;

    public ConstPtr<AVCodec> Codec;

    public AVCodecID CodecId;

    /// <summary>
    /// fourcc (LSB first, so "ABCD" -> ('D'&lt;&lt;24) + ('C'&lt;&lt;16) + ('B'&lt;&lt;8) + 'A').
    /// This is used to work around some encoder bugs.
    /// A demuxer should set this to what is stored in the field used to identify the codec.
    /// If there are multiple such fields in a container then the demuxer should choose the one
    /// which maximizes the information about the used codec.
    /// If the codec tag field in a container is larger than 32 bits then the demuxer should
    /// remap the longer ID to 32 bits with a table or other structure. Alternatively a new
    /// extra_codec_tag + size could be added but for this a clear advantage must be demonstrated
    /// first.
    /// - encoding: Set by user, if not then the default based on codec_id will be used.
    /// - decoding: Set by user, will be converted to uppercase by libavcodec during init.
    /// </summary>
    public uint CodecTag;

    public IntPtr PrivateData;

    /// <summary>
    /// Private context used for internal data.
    /// Unlike priv_data, this is not codec-specific. It is used in general libavcodec functions.
    /// </summary>
    public Ptr<AVCodecInternal> Internal;

    /// <summary>
    /// Private data of the user, can be used to carry app specific stuff.
    /// - encoding: Set by user.
    /// - decoding: Set by user.
    /// </summary>
    public IntPtr Opaque;

    /// <summary>
    /// The average bitrate:
    /// - encoding: Set by user; unused for constant quantizer encoding.
    /// - decoding: Set by user, may be overwritten by libavcodec
    ///                          if this info is available in the stream
    /// </summary>
    public long Bitrate;

    /// <summary>
    /// number of bits the bitstream is allowed to diverge from the reference.
    /// the reference can be CBR (for CBR pass1) or VBR (for pass2)
    /// - encoding: Set by user; unused for constant quantizer encoding.
    /// - decoding: unused
    /// </summary>
    public int BitrateTolerance;

    /// <summary>
    /// Global quality for codecs which cannot change it per frame.
    /// This should be proportional to MPEG-1/2/4 qscale.
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int GlobalQuality;

    /// <summary>
    /// - encoding: Set by user. To use the default codec value, set it to -1.
    /// - decoding: unused
    /// </summary>
    public int CompressionLevel;

    /// <summary>
    /// - encoding: Set by user.
    /// - decoding: Set by user.
    /// </summary>
    public AVCodecFlags Flags;

    /// <summary>
    /// - encoding: Set by user.
    /// - decoding: Set by user.
    /// </summary>
    public AVCodecFlags2 Flags2;

    /// <summary>
    /// some codecs need / can use extradata like Huffman tables.
    /// MJPEG: Huffman tables
    /// rv10: additional flags
    /// MPEG-4: global headers (they can be in the bitstream or here)
    /// The allocated memory should be AV_INPUT_BUFFER_PADDING_SIZE bytes larger
    /// than extradata_size to avoid problems if it is read with the bitstream reader.
    /// The bytewise contents of extradata must not depend on the architecture or CPU endianness.
    /// Must be allocated with the av_malloc() family of functions.
    /// - encoding: Set/allocated/freed by libavcodec.
    /// - decoding: Set/allocated/freed by user.
    /// </summary>
    public Ptr<byte> ExtraData;

    public int ExtraDataSize;

    /// <summary>
    /// This is the fundamental unit of time (in seconds) in terms
    /// of which frame timestamps are represented. For fixed-fps content,
    /// timebase should be 1/framerate and timestamp increments should be
    /// identically 1.
    /// This often, but not always is the inverse of the frame rate or field rate
    /// for video. 1/time_base is not the average frame rate if the frame rate is not constant.
    /// Like containers, elementary streams also can store timestamps, 1/time_base
    /// is the unit in which these timestamps are specified.
    /// As example of such codec time base see ISO/IEC 14496-2:2001(E)
    /// vop_time_increment_resolution and fixed_vop_rate
    /// (fixed_vop_rate == 0 implies that it is different from the framerate)
    ///
    /// - encoding: MUST be set by user.
    /// - decoding: the use of this field for decoding is deprecated. Use framerate instead.
    /// </summary>
    public AVRational TimeBase;

    /// <summary>
    /// For some codecs, the time base is closer to the field rate than the frame rate.
    /// Most notably, H.264 and MPEG-2 specify time_base as half of frame duration
    /// if no telecine is used ...
    /// Set to time_base ticks per frame. Default 1, e.g., H.264/MPEG-2 set it to 2.
    /// </summary>
    public int TicksPerFrame;

    /// <summary>
    /// Codec delay.
    /// Encoding: Number of frames delay there will be from the encoder input to
    ///           the decoder output. (we assume the decoder matches the spec)
    /// Decoding: Number of frames delay in addition to what a standard decoder
    ///           as specified in the spec would produce.
    /// Video:
    ///     Number of frames the decoded output will be delayed relative to the encoded input.
    /// Audio:
    ///     For encoding, this field is unused (see initial_padding).
    ///     For decoding, this is the number of samples the decoder needs to
    ///     output before the decoder's output is valid. When seeking, you should
    ///     start decoding this many samples prior to your desired seek point.
    ///
    /// - encoding: Set by libavcodec.
    /// - decoding: Set by libavcodec.
    /// </summary>
    public int Delay;

    /// <summary>
    /// Video only: picture width and height.
    ///
    /// NOTE: Those fields may not match the values of the last AVFrame output
    /// by avcodec_receive_frame() due frame reordering.
    ///
    /// - encoding: MUST be set by user.
    /// - decoding: May be set by the user before opening the decoder if known e.g.
    ///             from the container. Some decoders will require the dimensions
    ///             to be set by the caller. During decoding, the decoder may
    ///             overwrite those values as required while parsing the data.
    /// </summary>
    public int Width, Height;

    /// <summary>
    /// Bitstream width and height, may be different from width/height e.g. when
    /// the decoded frame is cropped before being output or lowres is enabled.
    ///
    /// NOTE: Those field may not match the value of the last AVFrame output
    /// by avcodec_receive_frame() due frame reordering.
    ///
    /// - encoding: unused
    /// - decoding: May be set by the user before opening the decoder if known
    ///             e.g. from the container. During decoding, the decoder may
    ///             overwrite those values as required while parsing the data.
    /// </summary>
    public int CodedWidth, CodedHeight;

    /// <summary>
    /// The number of pictures in a group of pictures, or 0 for intra_only.
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int PictureGroupSize;

    /// <summary>
    /// Pixel format, see AV_PIX_FMT_xxx.
    /// May be set by the demuxer if known from headers.
    /// May be overridden by the decoder if it knows better.
    /// NOTE: This field may not match the value of the last AVFrame output
    /// by avcodec_receive_frame() due frame reordering.
    /// - encoding: Set by user.
    /// - decoding: Set by user if known, overridden by libavcodec while parsing the data.
    /// </summary>
    public AVPixelFormat PixelFormat;

    /// <summary>
    /// If non NULL, 'draw_horiz_band' is called by the libavcodec
    /// decoder to draw a horizontal band. It improves cache usage. Not
    /// all codecs can do that. You must check the codec capabilities beforehand.
    /// When multithreading is used, it may be called from multiple threads
    /// at the same time; threads might draw different parts of the same AVFrame,
    /// or multiple AVFrames, and there is no guarantee that slices will be drawn
    /// in order.
    /// The function is also used by hardware acceleration APIs.
    /// It is called at least once during frame decoding to pass
    /// the data needed for hardware render.
    /// In that mode instead of pixel data, AVFrame points to
    /// a structure specific to the acceleration API. The application
    /// reads the structure and can change some fields to indicate progress
    /// or mark state.
    /// - encoding: unused
    /// - decoding: Set by user.
    /// </summary>
    public DrawHorizBandDelegate DrawHorizBand // s, src, offset, y, type, height
    {
        get => (DrawHorizBandDelegate)DrawHorizBandPtr;
        set => DrawHorizBandPtr = (IntPtr)value;
    }

    public IntPtr DrawHorizBandPtr;

    /// <summary>
    /// Callback to negotiate the pixel format. Decoding only, may be set by the
    /// caller before avcodec_open2().
    ///
    /// Called by some decoders to select the pixel format that will be used for
    /// the output frames. This is mainly used to set up hardware acceleration,
    /// then the provided format list contains the corresponding hwaccel pixel
    /// formats alongside the "software" one. The software pixel format may also
    /// be retrieved from \ref sw_pix_fmt.
    /// 
    /// This callback will be called when the coded frame properties (such as
    /// resolution, pixel format, etc.) change and more than one output format is
    /// supported for those new properties. If a hardware pixel format is chosen
    /// and initialization for it fails, the callback may be called again
    /// immediately.
    /// 
    /// This callback may be called from different threads if the decoder is
    /// multi-threaded, but not from more than one thread simultaneously.
    /// 
    /// @param fmt list of formats which may be used in the current
    ///            configuration, terminated by AV_PIX_FMT_NONE.
    /// @warning Behavior is undefined if the callback returns a value other
    ///          than one of the formats in fmt or AV_PIX_FMT_NONE.
    /// @return the chosen format or AV_PIX_FMT_NONE
    /// </summary>
    public GetFormatDelegate GetFormat
    {
        get => (GetFormatDelegate)GetFormatPtr;
        set => GetFormatPtr = (IntPtr)value;
    }

    public IntPtr GetFormatPtr;

    /// <summary>
    /// maximum number of B-frames between non-B-frames
    /// Note: The output will be delayed by max_b_frames+1 relative to the input.
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int MaxBFrames;

    /// <summary>
    /// qscale factor between IP and B-frames
    /// If > 0 then the last P-frame quantizer will be used (q= lastp_q*factor+offset).
    /// If &lt; 0 then normal ratecontrol will be done (q= -normal_q*factor+offset).
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public float BQuantFactor;

    /// <summary>
    /// qscale offset between IP and B-frames
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public float BQuantOffset;

    /// <summary>
    /// Size of the frame reordering buffer in the decoder.
    /// For MPEG-2 it is 1 IPB or 0 low delay IP.
    /// - encoding: Set by libavcodec.
    /// - decoding: Set by libavcodec.
    /// </summary>
    public int HasBFrames;

    /// <summary>
    /// qscale factor between P- and I-frames
    /// If > 0 then the last P-frame quantizer will be used (q = lastp_q * factor + offset).
    /// If &lt; 0 then normal ratecontrol will be done (q= -normal_q*factor+offset).
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public float IQuantFactor;

    /// <summary>
    /// qscale offset between P and I-frames
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public float IQuantOffset;

    /// <summary>
    /// luminance masking (0 - disabled)
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public float LumiMasking;

    /// <summary>
    /// temporary complexity masking (0 - disabled)
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public float TemporalCplxMasking;

    /// <summary>
    /// spatial complexity masking (0 - disabled)
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public float SpatialCplxMasking;

    /// <summary>
    /// p block masking (0 - disabled)
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public float PMasking;

    /// <summary>
    /// darkness masking (0 - disabled)
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public float DarkMasking;

    /// <summary>
    /// slice count
    /// - encoding: Set by libavcodec.
    /// - decoding: Set by user (or 0).
    /// </summary>
    public int SliceCount;

    /// <summary>
    /// slice offsets in the frame in bytes
    /// - encoding: Set/allocated by libavcodec.
    /// - decoding: Set/allocated by user (or NULL).
    /// </summary>
    public Ptr<int> SliceOffset;

    /// <summary>
    /// sample aspect ratio (0 if unknown)
    /// That is the width of a pixel divided by the height of the pixel.
    /// Numerator and denominator must be relatively prime and smaller than 256 for some video standards.
    /// - encoding: Set by user.
    /// - decoding: Set by libavcodec.
    /// </summary>
    public AVRational SampleAspectRatio;

    /// <summary>
    /// motion estimation comparison function
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public AVCodecCmpFunction MeCmp;

    /// <summary>
    /// subpixel motion estimation comparison function
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public AVCodecCmpFunction MeSubCmp;

    /// <summary>
    /// macroblock comparison function (not supported yet)
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public AVCodecCmpFunction MbCmp;

    /// <summary>
    /// interlaced DCT comparison function
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public AVCodecCmpFunction IldctCmp;

    /// <summary>
    /// ME diamond size & shape
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int DiaSize;

    /// <summary>
    /// amount of previous MV predictors (2a+1 x 2a+1 square)
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int LastPredictorCount;

    /// <summary>
    /// motion estimation prepass comparison function
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public AVCodecCmpFunction MePreCmp;

    /// <summary>
    /// ME prepass diamond size & shape
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int PreDiaSize;

    /// <summary>
    /// subpel ME quality
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int MeSubpelQuality;

    /// <summary>
    /// maximum motion estimation search range in subpel units
    /// If 0 then no limit.
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int MeRange;

    /// <summary>
    /// slice flags
    /// - encoding: unused
    /// - decoding: Set by user.
    /// </summary>
    public AVCodecSliceFlags SliceFlags;

    /// <summary>
    /// macroblock decision mode
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public AVCodecMetablockDecision MbDecision;

    /// <summary>
    /// custom intra quantization matrix
    /// Must be allocated with the av_malloc() family of functions, and will be freed in
    /// avcodec_free_context().
    /// - encoding: Set/allocated by user, freed by libavcodec. Can be NULL.
    /// - decoding: Set/allocated/freed by libavcodec.
    /// </summary>
    public Ptr<ushort> IntraMatrix;

    /// <summary>
    /// custom inter quantization matrix
    /// Must be allocated with the av_malloc() family of functions, and will be freed in
    /// avcodec_free_context().
    /// - encoding: Set/allocated by user, freed by libavcodec. Can be NULL.
    /// - decoding: Set/allocated/freed by libavcodec.
    /// </summary>
    public Ptr<ushort> InterMatrix;

    /// <summary>
    /// precision of the intra DC coefficient - 8
    /// - encoding: Set by user.
    /// - decoding: Set by libavcodec
    /// </summary>
    public int IntraDcPrecision;

    /// <summary>
    /// Number of macroblock rows at the top which are skipped.
    /// - encoding: unused
    /// - decoding: Set by user.
    /// </summary>
    public int SkipTop;

    /// <summary>
    /// Number of macroblock rows at the bottom which are skipped.
    /// - encoding: unused
    /// - decoding: Set by user.
    /// </summary>
    public int SkipBottom;

    /// <summary>
    /// minimum MB Lagrange multiplier
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int MbLmin;

    /// <summary>
    /// maximum MB Lagrange multiplier
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int MbLmax;

    /// <summary>
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int BidirRefine;

    /// <summary>
    /// minimum GOP size
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int KeyintMin;

    /// <summary>
    /// number of reference frames
    /// - encoding: Set by user.
    /// - decoding: Set by lavc.
    /// </summary>
    public int Refs;

    /// <summary>
    /// Note: Value depends upon the compare function used for fullpel ME.
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int Mv0Threshold;

    /// <summary>
    /// Chromaticity coordinates of the source primaries.
    /// - encoding: Set by user
    /// - decoding: Set by libavcodec
    /// </summary>
    public AVColorPrimaries ColorPrimaries;

    /// <summary>
    /// Color Transfer Characteristic.
    /// - encoding: Set by user
    /// - decoding: Set by libavcodec
    /// </summary>
    public AVColorTransferCharacteristic ColorTrc;

    /// <summary>
    /// YUV colorspace type.
    /// - encoding: Set by user
    /// - decoding: Set by libavcodec
    /// </summary>
    public AVColorSpace ColorSpace;

    /// <summary>
    /// MPEG vs JPEG YUV range.
    /// - encoding: Set by user
    /// - decoding: Set by libavcodec
    /// </summary>
    public AVColorRange ColorRange;

    /// <summary>
    /// This defines the location of chroma samples.
    /// - encoding: Set by user
    /// - decoding: Set by libavcodec
    /// </summary>
    public AVChromaLocation ChromaSampleLocation;

    /// <summary>
    /// Number of slices.
    /// Indicates number of picture subdivisions. Used for parallelized decoding.
    /// - encoding: Set by user
    /// - decoding: unused
    /// </summary>
    public int Slices;

    /// <summary>
    /// Field order
    /// - encoding: set by libavcodec
    /// - decoding: Set by user.
    /// </summary>
    public AVFieldOrder FieldOrder;

    /// <summary>
    /// Audio only.
    /// samples per second
    /// </summary>
    public int SampleRate;

    /// <summary>
    /// Audio only.
    /// number of audio channels
    /// </summary>
    public int Channels;

    /// <summary>
    /// audio sample format
    /// - encoding: Set by user.
    /// - decoding: Set by libavcodec.
    /// </summary>
    public AVSampleFormat SampleFormat;

    /// <summary>
    /// Number of samples per channel in an audio frame.
    /// - encoding: set by libavcodec in avcodec_open2(). Each submitted frame
    /// except the last must contain exactly frame_size samples per channel.
    /// May be 0 when the codec has AV_CODEC_CAP_VARIABLE_FRAME_SIZE set, then the
    /// frame size is not restricted.
    /// - decoding: may be set by some decoders to indicate constant frame size
    /// NOTE: should not be initialized.
    /// </summary>
    public int FrameSize;

    /// <summary>
    /// Frame counter, set by libavcodec.
    /// - decoding: total number of frames returned from the decoder so far.
    /// - encoding: total number of frames passed to the encoder so far.
    /// the counter is not incremented if encoding/decoding resulted in an error.
    /// </summary>
    public int FrameNumber;

    /// <summary>
    /// number of bytes per packet if constant and known or 0
    /// Used by some WAV based audio codecs.
    /// </summary>
    public int BlockAlign;

    /// <summary>
    /// Audio cutoff bandwidth (0 means "automatic").
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int CutOff;

    /// <summary>
    /// Audio channel layout.
    /// - encoding: set by user.
    /// - decoding: set by user, may be overwritten by libavcodec.
    /// </summary>
    public AVChannelLayout ChannelLayout;

    /// <summary>
    /// Request decoder to use this channel layout if it can (0 for default)
    /// - encoding: unused
    /// - decoding: Set by user.
    /// </summary>
    public AVChannelLayout RequestChannelLayout;

    /// <summary>
    /// Type of service that the audio stream conveys.
    /// - encoding: Set by user.
    /// - decoding: Set by libavcodec.
    /// </summary>
    public AVAudioServiceType AudioServiceType;

    /// <summary>
    /// desired sample format
    /// - encoding: Not used.
    /// - decoding: Set by user.
    /// Decoder will decode to this format if it can.
    /// </summary>
    public AVSampleFormat RequestSampleFormat;

    /// <summary>
    /// This callback is called at the beginning of each frame to get data
    /// buffer(s) for it. There may be one contiguous buffer for all the data or
    /// there may be a buffer per each data plane or anything in between. What
    /// this means is, you may set however many entries in buf[] you feel necessary.
    /// Each buffer must be reference-counted using the AVBuffer API (see description
    /// of buf[] below).
    ///
    /// The following fields will be set in the frame before this callback is called:
    /// - format
    /// - width, height (video only)
    /// - sample_rate, channel_layout, nb_samples (audio only).
    ///
    /// Their values may differ from the corresponding values in
    /// AVCodecContext. This callback must use the frame values, not the codec
    /// context values, to calculate the required buffer size.
    ///
    /// This callback must fill the following fields in the frame:
    /// - data[]
    /// - linesize[]
    /// - extended_data:
    ///   * if the data is planar audio with more than 8 channels, then this
    ///     callback must allocate and fill extended_data to contain all pointers
    ///     to all data planes. data[] must hold as many pointers as it can.
    ///     extended_data must be allocated with av_malloc() and will be freed in
    ///     av_frame_unref().
    ///   * otherwise extended_data must point to data
    /// - buf[] must contain one or more pointers to AVBufferRef structures. Each of
    ///   the frame's data and extended_data pointers must be contained in these. That
    ///   is, one AVBufferRef for each allocated chunk of memory, not necessarily one
    ///   AVBufferRef per data[] entry. See: av_buffer_create(), av_buffer_alloc(),
    ///   and av_buffer_ref().
    /// - extended_buf and nb_extended_buf must be allocated with av_malloc() by
    ///   this callback and filled with the extra buffers if there are more
    ///   buffers than buf[] can hold. extended_buf will be freed in
    ///   av_frame_unref().
    ///
    /// If AV_CODEC_CAP_DR1 is not set then get_buffer2() must call
    /// avcodec_default_get_buffer2() instead of providing buffers allocated by
    /// some other means.
    ///
    /// Each data plane must be aligned to the maximum required by the target CPU.
    /// See avcodec_default_get_buffer2().
    ///
    /// Video:
    /// If AV_GET_BUFFER_FLAG_REF is set in flags then the frame may be reused
    /// (read and/or written to if it is writable) later by libavcodec.
    /// avcodec_align_dimensions2() should be used to find the required width and
    /// height, as they normally need to be rounded up to the next multiple of 16.
    /// Some decoders do not support linesizes changing between frames.
    ///
    /// If frame multithreading is used, this callback may be called from a
    /// different thread, but not from more than one at once. Does not need to be
    /// reentrant.
    ///
    /// See avcodec_align_dimensions2().
    ///
    /// Audio:
    /// Decoders request a buffer of a particular size by setting
    /// AVFrame.nb_samples prior to calling get_buffer2(). The decoder may,
    /// however, utilize only part of the buffer by setting AVFrame.nb_samples
    /// to a smaller value in the output frame.
    /// As a convenience, av_samples_get_buffer_size() and
    /// av_samples_fill_arrays() in libavutil may be used by custom get_buffer2()
    /// functions to find the required data size and to fill data pointers and
    /// linesize. In AVFrame.linesize, only linesize[0] may be set for audio
    /// since all planes must be the same size.
    ///
    /// See av_samples_get_buffer_size(), av_samples_fill_arrays().
    ///
    /// - encoding: unused
    /// - decoding: Set by libavcodec, user can override.
    /// </summary>
    public GetBuffer2Delegate GetBuffer2
    {
        get => (GetBuffer2Delegate)GetBuffer2Ptr;
        set => GetBuffer2Ptr = (IntPtr)value;
    }

    public IntPtr GetBuffer2Ptr;

    /// <summary>
    /// amount of qscale change between easy &amp; hard scenes (0.0-1.0)
    /// </summary>
    public float QCompress;

    /// <summary>
    /// amount of qscale smoothing over time (0.0-1.0)
    /// </summary>
    public float QBlur;

    /// <summary>
    /// minimum quantizer
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int QMin;

    /// <summary>
    /// maximum quantizer
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int QMax;

    /// <summary>
    /// maximum quantizer difference between frames
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int MaxQDiff;

    /// <summary>
    /// decoder bitstream buffer size
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int RcBufferSize;

    /// <summary>
    /// ratecontrol override, see RcOverride
    /// - encoding: Allocated/set/freed by user.
    /// - decoding: unused
    /// </summary>
    public int RcOverrideCount;
    public Ptr<RcOverride> RcOverride;

    /// <summary>
    /// maximum bitrate
    /// - encoding: Set by user.
    /// - decoding: Set by user, may be overwritten by libavcodec.
    /// </summary>
    public long RcMaxRate;

    /// <summary>
    /// minimum bitrate
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public long RcMinRate;

    /// <summary>
    /// Ratecontrol attempt to use, at maximum, value of what can be used without an underflow.
    /// - encoding: Set by user.
    /// - decoding: unused.
    /// </summary>
    public float RcMaxAvailableVbvUse;

    /// <summary>
    /// Ratecontrol attempt to use, at least, value times the amount needed to prevent a vbv overflow.
    /// - encoding: Set by user.
    /// - decoding: unused.
    /// </summary>
    public float RcMinVbvOverflowUse;

    /// <summary>
    /// Number of bits which should be loaded into the rc buffer before decoding starts.
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int RcInitialBufferOccupancy;

    /// <summary>
    /// trellis RD quantization
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int Trellis;

    /// <summary>
    /// pass1 encoding statistics output buffer
    /// - encoding: Set by libavcodec.
    /// - decoding: unused
    /// </summary>
    public Ptr<byte> StatsOut;

    /// <summary>
    /// pass2 encoding statistics input buffer
    /// Concatenated stuff from stats_out of pass1 should be placed here.
    /// - encoding: Allocated/set/freed by user.
    /// - decoding: unused
    /// </summary>
    public Ptr<byte> StatsIn;

    /// <summary>
    /// Work around bugs in encoders which sometimes cannot be detected automatically.
    /// - encoding: Set by user
    /// - decoding: Set by user
    /// </summary>
    public AVWorkaroundBugs WorkaroundBugs;

    /// <summary>
    /// strictly follow the standard (MPEG-4, ...).
    /// - encoding: Set by user.
    /// - decoding: Set by user.
    /// Setting this to STRICT or higher means the encoder and decoder will
    /// generally do stupid things, whereas setting it to unofficial or lower
    /// will mean the encoder might produce output that is not supported by all
    /// spec-compliant decoders. Decoders don't differentiate between normal,
    /// unofficial and experimental (that is, they always try to decode things
    /// when they can) unless they are explicitly asked to behave stupidly
    /// (=strictly conform to the specs)
    /// </summary>
    public AVStandardCompliance StrictStdCompliance;

    /// <summary>
    /// error concealment flags
    /// - encoding: unused
    /// - decoding: Set by user.
    /// </summary>
    public AVErrorConcealmentFlags ErrorConcealment;

    /// <summary>
    /// debug
    /// - encoding: Set by user.
    /// - decoding: Set by user.
    /// </summary>
    public AVDebugFlags Debug;

    /// <summary>
    /// Error recognition; may misdetect some more or less valid parts as errors.
    /// - encoding: Set by user.
    /// - decoding: Set by user.
    /// </summary>
    public AVErrorRecognitionFlags ErrorRecognition;

    /// <summary>
    /// opaque 64-bit number (generally a PTS) that will be reordered and
    /// output in AVFrame.reordered_opaque
    /// - encoding: Set by libavcodec to the reordered_opaque of the input
    ///             frame corresponding to the last returned packet. Only
    ///             supported by encoders with the
    ///             AV_CODEC_CAP_ENCODER_REORDERED_OPAQUE capability.
    /// - decoding: Set by user.
    /// </summary>
    public long ReorderedOpaque;

    /// <summary>
    /// Hardware accelerator in use
    /// - encoding: unused.
    /// - decoding: Set by libavcodec
    /// </summary>
    public ConstPtr<AVHWAccel> HwAccel;

    /// <summary>
    /// Hardware accelerator context.
    /// For some hardware accelerators, a global context needs to be
    /// provided by the user. In that case, this holds display-dependent
    /// data FFmpeg cannot instantiate itself. Please refer to the
    /// FFmpeg HW accelerator documentation to know how to fill this.
    /// 
    /// - encoding: unused
    /// - decoding: Set by user
    /// </summary>
    public IntPtr HwAccelContext;

    /// <summary>
    /// error
    /// - encoding: Set by libavcodec if flags & AV_CODEC_FLAG_PSNR.
    /// - decoding: unused
    /// </summary>
    public Array8<ulong> Error;

    /// <summary>
    /// DCT algorithm, see FF_DCT_* below
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public AVDCTAlgorithm DctAlgorithm;

    /// <summary>
    /// IDCT algorithm, see FF_IDCT_* below.
    /// - encoding: Set by user.
    /// - decoding: Set by user.
    /// </summary>
    public AVIDCTAlgorithm IdctAlgorithm;

    /// <summary>
    /// bits per sample/pixel from the demuxer (needed for huffyuv).
    /// - encoding: Set by libavcodec.
    /// - decoding: Set by user.
    /// </summary>
    public int BitsPerCodedSample;

    /// <summary>
    /// Bits per sample/pixel of internal libavcodec pixel/sample format.
    /// - encoding: set by user.
    /// - decoding: set by libavcodec.
    /// </summary>
    public int BitsPerRawSample;

    /// <summary>
    /// low resolution decoding, 1-> 1/2 size, 2->1/4 size
    /// - encoding: unused
    /// - decoding: Set by user.
    /// </summary>
    public int LowResolution;

    /// <summary>
    /// thread count is used to decide how many independent tasks should be passed to execute()
    /// - encoding: Set by user.
    /// - decoding: Set by user.
    /// </summary>
    public int ThreadCount;

    /// <summary>
    /// Which multithreading methods to use.
    /// Use of FF_THREAD_FRAME will increase decoding delay by one frame per thread,
    /// so clients which cannot provide future frames should not use it.
    /// - encoding: Set by user, otherwise the default is used.
    /// - decoding: Set by user, otherwise the default is used.
    /// </summary>
    public AVThreadingType ThreadType;

    /// <summary>
    /// Which multithreading methods are in use by the codec.
    /// - encoding: Set by libavcodec.
    /// - decoding: Set by libavcodec.
    /// </summary>
    public AVThreadingType ActiveThreadType;

    /// <summary>
    /// Set by the client if its custom get_buffer() callback can be called
    /// synchronously from another thread, which allows faster multithreaded decoding.
    /// draw_horiz_band() will be called from other threads regardless of this setting.
    /// Ignored if the default get_buffer() is used.
    /// - encoding: Set by user.
    /// - decoding: Set by user.
    ///
    /// Deprecated: The custom get_buffer2() callback should always be
    /// thread-safe. Thread-unsafe get_buffer2() implementations will be
    /// invalid starting with LIBAVCODEC_VERSION_MAJOR=60; in other words,
    /// libavcodec will behave as if this field was always set to 1.
    /// Callers that want to be forward compatible with future libavcodec
    /// versions should wrap access to this field in
    /// #if LIBAVCODEC_VERSION_MAJOR &lt; 60
    /// </summary>
    [Obsolete]
    public int ThreadSafeCallbacks;

    /// <summary>
    /// The codec may call this to execute several independent things.
    /// It will return only after finishing all tasks.
    /// The user may replace this with some multithreaded implementation,
    /// the default implementation will execute the parts serially.
    /// - encoding: Set by libavcodec, user can override.
    /// - decoding: Set by libavcodec, user can override.
    /// 
    /// count is the number of things to execute
    /// </summary>
    public ExecuteDelegate Execute // c, func, arg2, ret, count, size
    {
        get => (ExecuteDelegate)ExecutePtr;
        set => ExecutePtr = (IntPtr)value;
    }

    public IntPtr ExecutePtr;

    /// <summary>
    /// The codec may call this to execute several independent things.
    /// It will return only after finishing all tasks.
    /// The user may replace this with some multithreaded implementation,
    /// the default implementation will execute the parts serially.
    /// Also see avcodec_thread_init and e.g. the --enable-pthread configure option.
    /// - encoding: Set by libavcodec, user can override.
    /// - decoding: Set by libavcodec, user can override.
    ///
    /// c - context passed also to func
    /// count - the number of things to execute
    /// arg2 - argument passed unchanged to func
    /// ret - return values of executed functions, must have space for "count" values. May be NULL.
    /// func - function that will be called count times, with jobnr from 0 to count-1.
    ///        threadnr will be in the range 0 to c->thread_count-1 &lt; MAX_THREADS and so that no
    ///        two instances of func executing at the same time will have the same threadnr.
    /// return always 0 currently, but code should handle a future improvement where when any call to func
    /// returns &lt; 0 no further calls to func may be done and &lt; 0 is returned.
    /// </summary>
    public Execute2Delegate Execute2 // c, func, arg2, ret, count, size
    {
        get => (Execute2Delegate)Execute2Ptr;
        set => Execute2Ptr = (IntPtr)value;
    }

    public IntPtr Execute2Ptr;

    /// <summary>
    /// noise vs. sse weight for the nsse comparison function
    /// - encoding: Set by user.
    /// - decoding: unused
    /// </summary>
    public int NsseWeight;

    /// <summary>
    /// profile
    /// - encoding: Set by user.
    /// - decoding: Set by libavcodec.
    /// </summary>
    public AVProfileId Profile;

    /// <summary>
    /// level
    /// - encoding: Set by user.
    /// - decoding: Set by libavcodec.
    /// FF_LEVEL_UNKNOWN = -99
    /// </summary>
    public int Level;

    /// <summary>
    /// Skip loop filtering for selected frames.
    /// - encoding: unused
    /// - decoding: Set by user.
    /// </summary>
    public AVDiscard SkipLoopFilter;

    /// <summary>
    /// Skip IDCT/dequantization for selected frames.
    /// - encoding: unused
    /// - decoding: Set by user.
    /// </summary>
    public AVDiscard SkipIdct;

    /// <summary>
    /// Skip decoding for selected frames.
    /// - encoding: unused
    /// - decoding: Set by user.
    /// </summary>
    public AVDiscard SkipFrame;

    /// <summary>
    /// Header containing style information for text subtitles.
    /// For SUBTITLE_ASS subtitle type, it should contain the whole ASS
    /// [Script Info] and [V4+ Styles] section, plus the [Events] line and
    /// the Format line following. It shouldn't include any Dialogue line.
    /// - encoding: Set/allocated/freed by user (before avcodec_open2())
    /// - decoding: Set/allocated/freed by libavcodec (by avcodec_open2())
    /// </summary>
    public Ptr<byte> SubtitleHeader;
    public int SubtitleHeaderSize;

    /// <summary>
    /// Audio only. The number of "priming" samples (padding) inserted by the
    /// encoder at the beginning of the audio. I.e. this number of leading
    /// decoded samples must be discarded by the caller to get the original audio
    /// without leading padding.
    ///
    /// - decoding: unused
    /// - encoding: Set by libavcodec. The timestamps on the output packets are
    ///             adjusted by the encoder so that they always refer to the
    ///             first sample of the data actually contained in the packet,
    ///             including any added padding.  E.g. if the timebase is
    ///             1/samplerate and the timestamp of the first input sample is
    ///             0, the timestamp of the first output packet will be
    ///             -initial_padding.
    /// </summary>
    public int InitialPadding;

    /// <summary>
    /// - decoding: For codecs that store a framerate value in the compressed
    ///             bitstream, the decoder may export it here. { 0, 1} when unknown.
    /// - encoding: May be used to signal the framerate of CFR content to an encoder.
    /// </summary>
    public AVRational FrameRate;

    /// <summary>
    /// Nominal unaccelerated pixel format, see AV_PIX_FMT_xxx.
    /// - encoding: unused.
    /// - decoding: Set by libavcodec before calling get_format()
    /// </summary>
    public AVPixelFormat SwPixelFormat;

    /// <summary>
    /// Timebase in which pkt_dts/pts and AVPacket.dts/pts are.
    /// - encoding unused.
    /// - decoding set by user.
    /// </summary>
    public AVRational PktTimebase;

    /// <summary>
    /// AVCodecDescriptor
    /// - encoding: unused.
    /// - decoding: set by libavcodec.
    /// </summary>
    public ConstPtr<AVCodecDescriptor> CodecDescriptor;

    /// <summary>
    /// Current statistics for PTS correction.
    /// - decoding: maintained and used by libavcodec, not intended to be used by user apps
    /// - encoding: unused
    /// </summary>
    public long PtsCorrectionNumFaultyPts; // Number of incorrect PTS values so far
    public long PtsCorrectionNumFaultyDts; // Number of incorrect DTS values so far
    public long PtsCorrectionLastPts; // PTS of the last frame
    public long PtsCorrectionLastDts; // DTS of the last frame

    /// <summary>
    /// Character encoding of the input subtitles file.
    /// - decoding: set by user
    /// - encoding: unused
    /// </summary>
    public Ptr<byte> SubCharEnc; // char *

    /// <summary>
    /// Subtitles character encoding mode. Formats or codecs might be adjusting
    /// this setting (if they are doing the conversion themselves for instance).
    /// - decoding: set by libavcodec
    /// - encoding: unused
    /// </summary>
    public AVSubtitleCharEncodingMode SubCharEncMode;

    /// <summary>
    /// Skip processing alpha if supported by codec.
    /// Note that if the format uses pre-multiplied alpha (common with VP6,
    /// and recommended due to better video quality/compression)
    /// the image will look as if alpha-blended onto a black background.
    /// However for formats that do not use pre-multiplied alpha
    /// there might be serious artefacts (though e.g. libswscale currently
    /// assumes pre-multiplied alpha anyway).
    ///
    /// - decoding: set by user
    /// - encoding: unused
    /// </summary>
    public int SkipAlpha;

    /// <summary>
    /// Number of samples to skip after a discontinuity
    /// - decoding: unused
    /// - encoding: set by libavcodec
    /// </summary>
    public int SeekPreRoll;

    /// <summary>
    /// Deprecated: unused.
    /// </summary>
    [Obsolete]
    public AVDebugMotionVectorsFlags DebugMv;

    /// <summary>
    /// custom intra quantization matrix
    /// - encoding: Set by user, can be NULL.
    /// - decoding: unused.
    /// </summary>
    public Ptr<ushort> ChromaIntraMatrix;

    /// <summary>
    /// dump format separator.
    /// can be ", " or "\n      " or anything else
    /// - encoding: Set by user.
    /// - decoding: Set by user.
    /// </summary>
    public Ptr<byte> DumpSeparator;

    /// <summary>
    /// ',' separated list of allowed decoders.
    /// If NULL then all are allowed
    /// - encoding: unused
    /// - decoding: set by user
    /// </summary>
    public Ptr<byte> CodecWhitelist;

    /// <summary>
    /// Properties of the stream that gets decoded
    /// - encoding: unused
    /// - decoding: set by libavcodec
    /// </summary>
    public AVCodecStreamProperties Properties;

    /// <summary>
    /// Additional data associated with the entire coded stream.
    /// - decoding: unused
    /// - encoding: may be set by libavcodec after avcodec_open2().
    /// </summary>
    public Ptr<AVPacketSideData> CodedSideData;
    public int NumberCodedSideData;

    /// <summary>
    /// A reference to the AVHWFramesContext describing the input (for encoding)
    /// or output (decoding) frames. The reference is set by the caller and
    /// afterwards owned (and freed) by libavcodec - it should never be read by
    /// the caller after being set.
    ///
    /// - decoding: This field should be set by the caller from the get_format()
    ///             callback. The previous reference (if any) will always be
    ///             unreffed by libavcodec before the get_format() call.
    ///
    ///             If the default get_buffer2() is used with a hwaccel pixel
    ///             format, then this AVHWFramesContext will be used for
    ///             allocating the frame buffers.
    ///
    /// - encoding: For hardware encoders configured to use a hwaccel pixel
    ///             format, this field should be set by the caller to a reference
    ///             to the AVHWFramesContext describing input frames.
    ///             AVHWFramesContext.format must be equal to AVCodecContext.pix_fmt.
    ///
    ///             This field should be set before avcodec_open2() is called.
    /// </summary>
    public Ptr<AVBufferRef> HwFramesCtx;

    /// <summary>
    /// unused
    /// </summary>
    [Obsolete("unused")]
    public int SubTextFormat;

    /// <summary>
    /// Audio only. The amount of padding (in samples) appended by the encoder to
    /// the end of the audio. I.e. this number of decoded samples must be
    /// discarded by the caller from the end of the stream to get the original
    /// audio without any trailing padding.
    /// - decoding: unused
    /// - encoding: unused
    /// </summary>
    public int TrailingPadding;

    /// <summary>
    /// The number of pixels per image to maximally accept.
    /// - decoding: set by user
    /// - encoding: set by user
    /// </summary>
    public long MaxPixels;

    /// <summary>
    /// A reference to the AVHWDeviceContext describing the device which will
    /// be used by a hardware encoder/decoder.  The reference is set by the
    /// caller and afterwards owned (and freed) by libavcodec.
    ///
    /// This should be used if either the codec device does not require
    /// hardware frames or any that are used are to be allocated internally by
    /// libavcodec.  If the user wishes to supply any of the frames used as
    /// encoder input or decoder output then hw_frames_ctx should be used
    /// instead.  When hw_frames_ctx is set in get_format() for a decoder, this
    /// field will be ignored while decoding the associated stream segment, but
    /// may again be used on a following one after another get_format() call.
    ///
    /// For both encoders and decoders this field should be set before
    /// avcodec_open2() is called and must not be written to thereafter.
    ///
    /// Note that some decoders may require this field to be set initially in
    /// order to support hw_frames_ctx at all - in that case, all frames
    /// contexts used must be created on the same device.
    /// </summary>
    public Ptr<AVBufferRef> HwDeviceCtx;

    /// <summary>
    /// Bit set of AV_HWACCEL_FLAG_* flags, which affect hardware accelerated decoding (if active).
    /// - encoding: unused
    /// - decoding: Set by user (either before avcodec_open2(), or in the
    ///             AVCodecContext.get_format callback)
    /// </summary>
    public AVHWAccelFlags HwAccelFlags;

    /// <summary>
    /// Video decoding only. Certain video codecs support cropping, meaning that
    /// only a sub-rectangle of the decoded frame is intended for display.  This
    /// option controls how cropping is handled by libavcodec.
    ///
    /// When set to 1 (the default), libavcodec will apply cropping internally.
    /// I.e. it will modify the output frame width/height fields and offset the
    /// data pointers (only by as much as possible while preserving alignment, or
    /// by the full amount if the AV_CODEC_FLAG_UNALIGNED flag is set) so that
    /// the frames output by the decoder refer only to the cropped area. The
    /// crop_* fields of the output frames will be zero.
    ///
    /// When set to 0, the width/height fields of the output frames will be set
    /// to the coded dimensions and the crop_* fields will describe the cropping
    /// rectangle. Applying the cropping is left to the caller.
    ///
    /// When hardware acceleration with opaque output frames is used,
    /// libavcodec is unable to apply cropping from the top/left border.
    ///
    /// when this option is set to zero, the width/height fields of the
    /// AVCodecContext and output AVFrames have different meanings. The codec
    /// context fields store display dimensions (with the coded dimensions in
    /// coded_width/height), while the frame fields store the coded dimensions
    /// (with the display dimensions being determined by the crop_* fields).
    /// </summary>
    public int ApplyCropping;

    /// <summary>
    /// Video decoding only.  Sets the number of extra hardware frames which
    /// the decoder will allocate for use by the caller.  This must be set
    /// before avcodec_open2() is called.
    ///
    /// Some hardware decoders require all frames that they will use for
    /// output to be defined in advance before decoding starts.  For such
    /// decoders, the hardware frame pool must therefore be of a fixed size.
    /// The extra frames set here are on top of any number that the decoder
    /// needs internally in order to operate normally (for example, frames
    /// used as reference pictures).
    /// </summary>
    public int ExtraHwFrames;

    /// <summary>
    /// The percentage of damaged samples to discard a frame.
    /// - decoding: set by user
    /// - encoding: unused
    /// </summary>
    public int DiscardDamagedPercentage;

    /// <summary>
    /// The number of samples per frame to maximally accept.
    /// - decoding: set by user
    /// - encoding: set by user
    /// </summary>
    public long MaxSamples;

    /// <summary>
    /// Bit set of AV_CODEC_EXPORT_DATA_* flags, which affects the kind of
    /// metadata exported in frame, packet, or coded stream side data by
    /// decoders and encoders.
    /// - decoding: set by user
    /// - encoding: set by user
    /// </summary>
    public AVCodecExportSideDataFlags ExportSideData;

    /// <summary>
    /// This callback is called at the beginning of each packet to get a data buffer for it.
    ///
    /// The following field will be set in the packet before this callback is called:
    /// - size
    /// This callback must use the above value to calculate the required buffer size,
    /// which must padded by at least AV_INPUT_BUFFER_PADDING_SIZE bytes.
    ///
    /// In some specific cases, the encoder may not use the entire buffer allocated by this
    /// callback.This will be reflected in the size value in the packet once returned by
    /// avcodec_receive_packet().
    ///
    /// This callback must fill the following fields in the packet:
    /// - data: alignment requirements for AVPacket apply, if any. Some architectures and
    /// encoders may benefit from having aligned data.
    /// - buf: must contain a pointer to an AVBufferRef structure. The packet's
    /// data pointer must be contained in it. See: av_buffer_create(), av_buffer_alloc(),
    /// and av_buffer_ref().
    ///
    /// If AV_CODEC_CAP_DR1 is not set then get_encode_buffer() must call
    /// avcodec_default_get_encode_buffer() instead of providing a buffer allocated by
    /// some other means.
    ///
    /// The flags field may contain a combination of AV_GET_ENCODE_BUFFER_FLAG_ flags.
    /// They may be used for example to hint what use the buffer may get after being
    /// created.
    /// Implementations of this callback may ignore flags they don't understand.
    /// If AV_GET_ENCODE_BUFFER_FLAG_REF is set in flags then the packet may be reused
    /// (read and/or written to if it is writable) later by libavcodec.
    ///
    /// This callback must be thread-safe, as when frame threading is used, it may
    /// be called from multiple threads simultaneously.
    ///
    /// @see avcodec_default_get_encode_buffer()
    ///
    /// - encoding: Set by libavcodec, user can override.
    /// - decoding: unused
    /// </summary>
    public GetEncodeBufferDelegate GetEncodeBuffer
    {
        get => (GetEncodeBufferDelegate)GetEncodeBufferPtr;
        set => GetEncodeBufferPtr = (IntPtr)value;
    }

    public IntPtr GetEncodeBufferPtr;
}
