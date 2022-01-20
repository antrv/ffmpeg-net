namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Format I/O context.
/// New fields can be added to the end with minor version bumps.
/// Removal, reordering and changes to existing fields require a major version bump.
///
/// sizeof(AVFormatContext) must not be used outside libav*, use avformat_alloc_context() to create an AVFormatContext.
///
/// Fields can be accessed through AVOptions (av_opt*),
/// the name string used matches the associated command line parameter name and
/// can be found in libavformat/options_table.h.
/// The AVOption/command line parameter names differ in some cases from the C
/// structure field names for historic reasons or brevity.
/// </summary>
public struct AVFormatContext
{
    /// <summary>
    /// A class for logging and @ref avoptions. Set by avformat_alloc_context().
    /// Exports (de)muxer private options if they exist.
    /// </summary>
    public ConstPtr<AVClass> Class;

    /// <summary>
    /// The input container format.
    /// Demuxing only, set by avformat_open_input().
    /// </summary>
    public ConstPtr<AVInputFormat> InputFormat;

    /// <summary>
    /// The output container format.
    /// Muxing only, must be set by the caller before avformat_write_header().
    /// </summary>
    public ConstPtr<AVOutputFormat> OutputFormat;

    /// <summary>
    /// Format private data. This is an AVOptions-enabled struct
    /// if and only if iformat/oformat.priv_class is not NULL.
    ///
    /// - muxing: set by avformat_write_header()
    /// - demuxing: set by avformat_open_input()
    /// </summary>
    public IntPtr PrivateData;

    /// <summary>
    /// I/O context.
    ///
    /// - demuxing: either set by the user before avformat_open_input() (then
    ///             the user must close it manually) or set by avformat_open_input().
    ///
    /// - muxing: set by the user before avformat_write_header(). The caller must
    ///           take care of closing / freeing the IO context.
    ///
    /// Do NOT set this field if AVFMT_NOFILE flag is set in
    /// iformat/oformat.flags. In such a case, the (de)muxer will handle
    /// I/O in some other way and this field will be NULL.
    /// </summary>
    public Ptr<AVIOContext> IoContext;

    /// <summary>
    /// Flags signalling stream properties. A combination of AVFMTCTX_*.
    /// Set by libavformat.
    /// </summary>
    public AVFormatContextFlags CtxFlags;

    /// <summary>
    /// Number of elements in AVFormatContext.streams.
    /// Set by avformat_new_stream(), must not be modified by any other code.
    /// </summary>
    public int StreamCount;

    /// <summary>
    /// A list of all streams in the file. New streams are created with avformat_new_stream().
    ///
    /// - demuxing: streams are created by libavformat in avformat_open_input().
    ///             If AVFMTCTX_NOHEADER is set in ctx_flags, then new streams may also
    ///             appear in av_read_frame().
    /// - muxing: streams are created by the user before avformat_write_header().
    ///
    /// Freed by libavformat in avformat_free_context().
    /// </summary>
    public Ptr<Ptr<AVStream>> Streams;

    /// <summary>
    /// input or output URL. Unlike the old filename field, this field has no length restriction.
    ///
    /// - demuxing: set by avformat_open_input(), initialized to an empty
    ///             string if url parameter was NULL in avformat_open_input().
    /// - muxing: may be set by the caller before calling avformat_write_header()
    ///           (or avformat_init_output() if that is called first) to a string
    ///           which is freeable by av_free(). Set to an empty string if it
    ///           was NULL in avformat_init_output().
    ///
    /// Freed by libavformat in avformat_free_context().
    /// </summary>
    public Utf8StringPtr Url;

    /// <summary>
    /// Position of the first frame of the component, in
    /// AV_TIME_BASE fractional seconds. NEVER set this value directly:
    /// It is deduced from the AVStream values.
    ///
    /// Demuxing only, set by libavformat.
    /// </summary>
    public long StartTime;

    /// <summary>
    /// Duration of the stream, in AV_TIME_BASE fractional
    /// seconds. Only set this value if you know none of the individual stream
    /// durations and also do not set any of them. This is deduced from the
    /// AVStream values if not set.
    ///
    /// Demuxing only, set by libavformat.
    /// </summary>
    public long Duration;

    /// <summary>
    /// Total stream bitrate in bit/s, 0 if not
    /// available. Never set it directly if the file_size and the
    /// duration are known as FFmpeg can compute it automatically.
    /// </summary>
    public long BitRate;

    public uint PacketSize;
    public int MaxDelay;

    /// <summary>
    /// Flags modifying the (de)muxer behaviour. A combination of AVFMT_FLAG_*.
    /// Set by the user before avformat_open_input() / avformat_write_header().
    /// </summary>
    public AVFormatBehaviorFlags Flags;

    /// <summary>
    /// Maximum number of bytes read from input in order to determine stream
    /// properties. Used when reading the global header and in
    /// avformat_find_stream_info().
    ///
    /// Demuxing only, set by the caller before avformat_open_input().
    ///
    /// Note: this is not used for determining the AVInputFormat "input format"
    /// </summary>
    public long ProbeSize;

    /// <summary>
    /// Maximum duration (in AV_TIME_BASE units) of the data read
    /// from input in avformat_find_stream_info().
    /// Demuxing only, set by the caller before avformat_find_stream_info().
    /// Can be set to 0 to let avformat choose using a heuristic.
    /// </summary>
    public long MaxAnalyzeDuration;

    public ConstPtr<byte> Key;
    public int KeyLen;

    public uint ProgramCount;
    public Ptr<Ptr<AVProgram>> Programs;

    /// <summary>
    /// Forced video codec_id.
    /// Demuxing: Set by user.
    /// </summary>
    public AVCodecID VideoCodecId;

    /// <summary>
    /// Forced audio codec_id.
    /// Demuxing: Set by user.
    /// </summary>
    public AVCodecID AudioCodecId;

    /// <summary>
    /// Forced subtitle codec_id.
    /// Demuxing: Set by user.
    /// </summary>
    public AVCodecID SubtitleCodecId;

    /// <summary>
    /// Maximum amount of memory in bytes to use for the index of each stream.
    /// If the index exceeds this size, entries will be discarded as
    /// needed to maintain a smaller size. This can lead to slower or less
    /// accurate seeking (depends on demuxer).
    /// Demuxers for which a full in-memory index is mandatory will ignore this.
    /// - muxing: unused
    /// - demuxing: set by user
    ///
    /// </summary>
    public uint MaxIndexSize;

    /// <summary>
    /// Maximum amount of memory in bytes to use for buffering frames
    /// obtained from realtime capture devices.
    /// </summary>
    public uint MaxPictureBuffer;

    /// <summary>
    /// Number of chapters in AVChapter array.
    /// When muxing, chapters are normally written in the file header,
    /// so nb_chapters should normally be initialized before write_header
    /// is called. Some muxers (e.g. mov and mkv) can also write chapters
    /// in the trailer.  To write chapters in the trailer, nb_chapters
    /// must be zero when write_header is called and non-zero when
    /// write_trailer is called.
    /// - muxing: set by user
    /// - demuxing: set by libavformat
    /// </summary>
    public uint ChapterCount;
    public Ptr<Ptr<AVChapter>> Chapters;

    /// <summary>
    /// Metadata that applies to the whole file.
    /// - demuxing: set by libavformat in avformat_open_input()
    /// - muxing: may be set by the caller before avformat_write_header()
    ///
    /// Freed by libavformat in avformat_free_context().
    /// </summary>
    public Ptr<AVDictionary> Metadata;

    /// <summary>
    /// Start time of the stream in real world time, in microseconds
    /// since the Unix epoch (00:00 1st January 1970). That is, pts=0 in the
    /// stream was captured at this real world time.
    /// - muxing: Set by the caller before avformat_write_header(). If set to
    ///           either 0 or AV_NOPTS_VALUE, then the current wall-time will be used.
    /// - demuxing: Set by libavformat. AV_NOPTS_VALUE if unknown. Note that
    ///             the value may become known after some number of frames have been received.
    /// </summary>
    public long StartTimeRealtime;

    /// <summary>
    /// The number of frames used for determining the framerate in
    /// avformat_find_stream_info().
    /// Demuxing only, set by the caller before avformat_find_stream_info().
    /// </summary>
    public int FpsProbeSize;

    /// <summary>
    /// Error recognition; higher values will detect more errors but may
    /// misdetect some more or less valid parts as errors.
    /// Demuxing only, set by the caller before avformat_open_input().
    /// </summary>
    public int ErrorRecognition;

    /// <summary>
    /// Custom interrupt callbacks for the I/O layer.
    ///
    /// demuxing: set by the user before avformat_open_input().
    /// muxing: set by the user before avformat_write_header()
    /// (mainly useful for AVFMT_NOFILE formats). The callback
    /// should also be passed to avio_open2() if it's used to
    /// open the file.
    /// </summary>
    public AVIOInterruptCB InterruptCallback;

    /// <summary>
    /// Flags to enable debugging.
    /// </summary>
    public AVFormatDebugFlags Debug;

    /// <summary>
    /// Maximum buffering duration for interleaving.
    ///
    /// To ensure all the streams are interleaved correctly,
    /// av_interleaved_write_frame() will wait until it has at least one packet
    /// for each stream before actually writing any packets to the output file.
    /// When some streams are "sparse" (i.e. there are large gaps between
    /// successive packets), this can result in excessive buffering.
    ///
    /// This field specifies the maximum difference between the timestamps of the
    /// first and the last packet in the muxing queue, above which libavformat
    /// will output a packet regardless of whether it has queued a packet for all
    /// the streams.
    ///
    /// Muxing only, set by the caller before avformat_write_header().
    /// </summary>
    public long MaxInterleaveDelta;

    /// <summary>
    /// Allow non-standard and experimental extension
    /// see AVCodecContext.strict_std_compliance
    /// </summary>
    public int StrictStdCompliance;

    /// <summary>
    /// Flags indicating events happening on the file, a combination of AVFMT_EVENT_FLAG_*.
    /// - demuxing: may be set by the demuxer in avformat_open_input(),
    ///   avformat_find_stream_info() and av_read_frame(). Flags must be cleared
    ///   by the user once the event has been handled.
    /// - muxing: may be set by the user after avformat_write_header() to
    ///   indicate a user-triggered event.  The muxer will clear the flags for
    ///   events it has handled in av_[interleaved]_write_frame().
    /// </summary>
    public AVFormatEventFlags EventFlags;

    /// <summary>
    /// Maximum number of packets to read while waiting for the first timestamp.
    /// Decoding only.
    /// </summary>
    public int MaxTsProbe;

    /// <summary>
    /// Avoid negative timestamps during muxing.
    /// Any value of the AVFMT_AVOID_NEG_TS_* constants.
    /// Note, this only works when using av_interleaved_write_frame. (interleave_packet_per_dts is in use)
    /// - muxing: Set by user
    /// - demuxing: unused
    /// </summary>
    public AVFormatAvoidNegativeTs AvoidNegativeTs;

    /// <summary>
    /// Transport stream id.
    /// This will be moved into demuxer private options. Thus no API/ABI compatibility
    /// </summary>
    public int TsId;

    /// <summary>
    /// Audio preload in microseconds.
    /// Note, not all formats support this and unpredictable things may happen if it is used when not supported.
    /// - encoding: Set by user
    /// - decoding: unused
    /// </summary>
    public int AudioPreload;

    /// <summary>
    /// Max chunk time in microseconds.
    /// Note, not all formats support this and unpredictable things may happen if it is used when not supported.
    /// - encoding: Set by user
    /// - decoding: unused
    /// </summary>
    public int MaxChunkDuration;

    /// <summary>
    /// Max chunk size in bytes
    /// Note, not all formats support this and unpredictable things may happen if it is used when not supported.
    /// - encoding: Set by user
    /// - decoding: unused
    /// </summary>
    public int MaxChunkSize;

    /// <summary>
    /// forces the use of wallclock timestamps as pts/dts of packets
    /// This has undefined results in the presence of B frames.
    /// - encoding: unused
    /// - decoding: Set by user
    /// </summary>
    public int UseWallclockAsTimestamps;

    /// <summary>
    /// avio flags, used to force AVIO_FLAG_DIRECT.
    /// - encoding: unused
    /// - decoding: Set by user
    /// </summary>
    public AVIOFlags AvioFlags;

    /// <summary>
    /// The duration field can be estimated through various ways, and this field can be used
    /// to know how the duration was estimated.
    /// - encoding: unused
    /// - decoding: Read by user
    /// </summary>
    public AVDurationEstimationMethod DurationEstimationMethod;

    /// <summary>
    /// Skip initial bytes when opening stream
    /// - encoding: unused
    /// - decoding: Set by user
    /// </summary>
    public long SkipInitialBytes;

    /// <summary>
    /// Correct single timestamp overflows
    /// - encoding: unused
    /// - decoding: Set by user
    /// </summary>
    public uint CorrectTsOverflow;

    /// <summary>
    /// Force seeking to any (also non key) frames.
    /// - encoding: unused
    /// - decoding: Set by user
    /// </summary>
    public int Seek2Any;

    /// <summary>
    /// Flush the I/O context after each packet.
    /// - encoding: Set by user
    /// - decoding: unused
    /// </summary>
    public int FlushPackets;

    /// <summary>
    /// format probing score.
    /// The maximal score is AVPROBE_SCORE_MAX, its set when the demuxer probes the format.
    /// - encoding: unused
    /// - decoding: set by avformat, read by user
    /// </summary>
    public int ProbeScore;

    /// <summary>
    /// Maximum number of bytes read from input in order to identify the
    /// AVInputFormat "input format". Only used when the format is not set explicitly by the caller.
    ///
    /// Demuxing only, set by the caller before avformat_open_input().
    /// </summary>
    public int FormatProbeSize;

    /// <summary>
    /// ',' separated list of allowed decoders.
    /// If NULL then all are allowed
    /// - encoding: unused
    /// - decoding: set by user
    /// </summary>
    public Utf8StringPtr CodecWhiteList;

    /// <summary>
    /// ',' separated list of allowed demuxers.
    /// If NULL then all are allowed
    /// - encoding: unused
    /// - decoding: set by user
    /// </summary>
    public Utf8StringPtr FormatWhiteList;

    /// <summary>
    /// IO repositioned flag.
    /// This is set by avformat when the underlaying IO context read pointer
    /// is repositioned, for example when doing byte based seeking.
    /// Demuxers can use the flag to detect such changes.
    /// </summary>
    public int IoRepositioned;

    /// <summary>
    /// Forced video codec.
    /// This allows forcing a specific decoder, even when there are multiple with the same codec_id.
    /// Demuxing: Set by user
    /// </summary>
    public ConstPtr<AVCodec> VideoCodec;

    /// <summary>
    /// Forced audio codec.
    /// This allows forcing a specific decoder, even when there are multiple with the same codec_id.
    /// Demuxing: Set by user
    /// </summary>
    public ConstPtr<AVCodec> AudioCodec;

    /// <summary>
    /// Forced subtitle codec.
    /// This allows forcing a specific decoder, even when there are multiple with the same codec_id.
    /// Demuxing: Set by user
    /// </summary>
    public ConstPtr<AVCodec> SubtitleCodec;

    /// <summary>
    /// Forced data codec.
    /// This allows forcing a specific decoder, even when there are multiple with the same codec_id.
    /// Demuxing: Set by user
    /// </summary>
    public ConstPtr<AVCodec> DataCodec;

    /// <summary>
    /// Number of bytes to be written as padding in a metadata header.
    /// Demuxing: Unused.
    /// Muxing: Set by user via av_format_set_metadata_header_padding.
    /// </summary>
    public int MetadataHeaderPadding;

    /// <summary>
    /// User data.
    /// This is a place for some private data of the user.
    /// </summary>
    public IntPtr Opaque;

    /// <summary>
    /// Callback used by devices to communicate with application.
    /// </summary>
    public IntPtr ControlMessageCb; // av_format_control_message

    /// <summary>
    /// Output timestamp offset, in microseconds.
    /// Muxing: set by user
    /// </summary>
    public long OutputTsOffset;

    /// <summary>
    /// dump format separator.
    /// can be ", " or "\n      " or anything else
    /// - muxing: Set by user.
    /// - demuxing: Set by user.
    /// </summary>
    public Ptr<byte> DumpSeparator;

    /// <summary>
    /// Forced Data codec_id.
    /// Demuxing: Set by user.
    /// </summary>
    public AVCodecID DataCodecId;

    /// <summary>
    /// ',' separated list of allowed protocols.
    /// - encoding: unused
    /// - decoding: set by user
    /// </summary>
    public Utf8StringPtr ProtocolWhiteList;

    /// <summary>
    /// A callback for opening new IO streams.
    /// </summary>
    public IntPtr IoOpen; // TODO callback

    /// <summary>
    /// A callback for closing the streams opened with AVFormatContext.io_open().
    /// </summary>
    public IntPtr IoClose; // TODO callback

    /// <summary>
    /// ',' separated list of disallowed protocols.
    /// - encoding: unused
    /// - decoding: set by user
    /// </summary>
    public Utf8StringPtr ProtocolBlackList;

    /// <summary>
    /// The maximum number of streams.
    /// - encoding: unused
    /// - decoding: set by user
    /// </summary>
    public int MaxStreams;

    /// <summary>
    /// Skip duration calculation in estimate_timings_from_pts.
    /// - encoding: unused
    /// - decoding: set by user
    /// </summary>
    public int SkipEstimateDurationFromPts;

    /// <summary>
    /// Maximum number of packets that can be probed
    /// - encoding: unused
    /// - decoding: set by user
    /// </summary>
    public int MaxProbePackets;

    /// <summary>
    /// A callback for closing the streams opened with AVFormatContext.io_open().
    ///
    /// Using this is preferred over io_close, because this can return an error.
    /// Therefore this callback is used instead of io_close by the generic
    /// libavformat code if io_close is NULL or the default.
    /// </summary>
    public IntPtr IoClose2; // TODO callback
}
