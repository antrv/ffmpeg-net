namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Stream structure.
/// New fields can be added to the end with minor version bumps.
/// Removal, reordering and changes to existing fields require a major version bump.
/// sizeof(AVStream) must not be used outside libav*.
/// </summary>
public struct AVStream
{
    // A class for @ref avoptions. Set on stream creation.
    // This field will be added in libavformat-60.
    //public ConstPtr<AVClass> Class;

    /// <summary>
    /// stream index in AVFormatContext
    /// </summary>
    public int Index;

    /// <summary>
    /// Format-specific stream ID.
    /// decoding: set by libavformat
    /// encoding: set by the user, replaced by libavformat if left unset
    /// </summary>
    public int Id;

    public IntPtr PrivateData;

    /// <summary>
    /// This is the fundamental unit of time (in seconds) in terms of which frame timestamps are represented.
    ///
    /// decoding: set by libavformat
    /// encoding: May be set by the caller before avformat_write_header() to
    ///           provide a hint to the muxer about the desired timebase. In
    ///           avformat_write_header(), the muxer will overwrite this field
    ///           with the timebase that will actually be used for the timestamps
    ///           written into the file (which may or may not be related to the
    ///           user-provided one, depending on the format).
    /// </summary>
    public AVRational TimeBase;

    /// <summary>
    /// Decoding: pts of the first frame of the stream in presentation order, in stream time base.
    /// Only set this if you are absolutely 100% sure that the value you set
    /// it to really is the pts of the first frame.
    /// This may be undefined (AV_NOPTS_VALUE).
    /// The ASF header does NOT contain a correct start_time the ASF
    /// demuxer must NOT set this.
    /// </summary>
    public long StartTime;

    /// <summary>
    /// Decoding: duration of the stream, in stream time base.
    /// If a source file does not specify a duration, but does specify
    /// a bitrate, this value will be estimated from bitrate and file size.
    ///
    /// Encoding: May be set by the caller before avformat_write_header() to
    /// provide a hint to the muxer about the estimated duration.
    /// </summary>
    public long Duration;

    /// <summary>
    /// number of frames in this stream if known or 0
    /// </summary>
    public long Frames;

    /// <summary>
    /// Stream disposition - a combination of AV_DISPOSITION_* flags.
    /// - demuxing: set by libavformat when creating the stream or in avformat_find_stream_info().
    /// - muxing: may be set by the caller before avformat_write_header().
    /// </summary>
    public AVDisposition Disposition;

    /// <summary>
    /// Selects which packets can be discarded at will and do not need to be demuxed.
    /// </summary>
    public AVDiscard Discard;

    /// <summary>
    /// sample aspect ratio (0 if unknown)
    /// - encoding: Set by user.
    /// - decoding: Set by libavformat.
    /// </summary>
    public AVRational SampleAspectRatio;

    public Ptr<AVDictionary> Metadata;

    /// <summary>
    /// Average framerate
    /// - demuxing: May be set by libavformat when creating the stream or in avformat_find_stream_info().
    /// - muxing: May be set by the caller before avformat_write_header().
    /// </summary>
    public AVRational AvgFrameRate;

    /// <summary>
    /// For streams with AV_DISPOSITION_ATTACHED_PIC disposition, this packet
    /// will contain the attached picture.
    ///
    /// decoding: set by libavformat, must not be modified by the caller.
    /// encoding: unused
    /// </summary>
    public AVPacket AttachedPicture;

    /// <summary>
    /// An array of side data that applies to the whole stream (i.e. the
    /// container does not allow it to change between packets).
    ///
    /// There may be no overlap between the side data in this array and side data
    /// in the packets. I.e. a given side data is either exported by the muxer
    /// (demuxing) / set by the caller (muxing) in this array, then it never
    /// appears in the packets, or the side data is exported / sent through
    /// the packets (always in the first packet where the value becomes known or
    /// changes), then it does not appear in this array.
    ///
    /// - demuxing: Set by libavformat when the stream is created.
    /// - muxing: May be set by the caller before avformat_write_header().
    ///
    /// Freed by libavformat in avformat_free_context().
    /// </summary>
    public Ptr<AVPacketSideData> SideData;

    /// <summary>
    /// The number of elements in the AVStream.side_data array.
    /// </summary>
    public int SideDataSize;

    /// <summary>
    /// Flags indicating events happening on the stream, a combination of AVSTREAM_EVENT_FLAG_*.
    ///
    /// - demuxing: may be set by the demuxer in avformat_open_input(),
    ///   avformat_find_stream_info() and av_read_frame(). Flags must be cleared
    ///   by the user once the event has been handled.
    /// - muxing: may be set by the user after avformat_write_header(). to
    ///   indicate a user-triggered event.  The muxer will clear the flags for
    ///   events it has handled in av_[interleaved]_write_frame().
    /// </summary>
    public AVStreamEventFlags EventFlags;

    /// <summary>
    /// Real base framerate of the stream.
    /// This is the lowest framerate with which all timestamps can be
    /// represented accurately (it is the least common multiple of all
    /// framerates in the stream). Note, this value is just a guess!
    /// For example, if the time base is 1/90000 and all frames have either
    /// approximately 3600 or 1800 timer ticks, then r_frame_rate will be 50/1.
    /// </summary>
    public AVRational RealFrameRate;

    /// <summary>
    /// Codec parameters associated with this stream. Allocated and freed by
    /// libavformat in avformat_new_stream() and avformat_free_context() respectively.
    ///
    /// - demuxing: filled by libavformat on stream creation or in avformat_find_stream_info()
    /// - muxing: filled by the caller before avformat_write_header()
    /// </summary>
    public Ptr<AVCodecParameters> CodecParameters;

    /// <summary>
    /// Number of bits in timestamps. Used for wrapping control.
    /// - demuxing: set by libavformat
    /// - muxing: set by libavformat
    /// </summary>
    public int PtsWrapBits;
}
