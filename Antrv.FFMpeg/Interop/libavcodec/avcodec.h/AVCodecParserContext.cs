using Antrv.FFMpeg.Types;

namespace Antrv.FFMpeg.Interop;

public struct AVCodecParserContext
{
    public IntPtr PrivateData;

    public ConstPtr<AVCodecParser> Parser;

    /// <summary>
    /// offset of the current frame
    /// </summary>
    public long FrameOffset;

    /// <summary>
    /// current offset (incremented by each av_parser_parse())
    /// </summary>
    public long CurrentOffset;

    /// <summary>
    /// offset of the next frame
    /// </summary>
    public long NextFrameOffset;

    /// <summary>
    /// XXX: Put it back in AVCodecContext.
    /// </summary>
    public int PictureType;

    /// <summary>
    /// This field is used for proper frame duration computation in lavf.
    /// It signals, how much longer the frame duration of the current frame
    /// is compared to normal frame duration.
    ///
    /// frame_duration = (1 + repeat_pict) * time_base
    ///
    /// It is used by codecs like H.264 to display telecined material.
    ///
    /// XXX: Put it back in AVCodecContext.
    /// </summary>
    public int RepeatPicture;

    /// <summary>
    /// pts of the current frame
    /// </summary>
    public long Pts;

    /// <summary>
    /// dts of the current frame
    /// </summary>
    public long Dts;

    // private data
    public long LastPts;
    public long LastDts;
    public int FetchTimestamp;

    public int CurrentFrameStartIndex;
    public Array4<long> CurrentFrameOffset; // AV_PARSER_PTS_NB times
    public Array4<long> CurrentFramePts; // AV_PARSER_PTS_NB times
    public Array4<long> CurrentFrameDts; // AV_PARSER_PTS_NB times

    public AVCodecParserContextFlags Flags;

    /// <summary>
    /// byte offset from starting packet start
    /// </summary>
    public long Offset;

    public Array4<long> CurrentFrameEnd; // AV_PARSER_PTS_NB times

    /// <summary>
    /// Set by parser to 1 for key frames and 0 for non-key frames.
    /// It is initialized to -1, so if the parser doesn't set this flag,
    /// old-style fallback using AV_PICTURE_TYPE_I picture type as key frames
    /// will be used.
    /// </summary>
    public int KeyFrame;

    /// <summary>
    /// Synchronization point for start of timestamp generation.
    /// Set to >0 for sync point, 0 for no sync point and &lt;0 for undefined (default).
    /// For example, this corresponds to presence of H.264 buffering period SEI message.
    /// </summary>
    public int DtsSyncPoint;

    /// <summary>
    /// Offset of the current timestamp against last timestamp sync point in
    /// units of AVCodecContext.time_base.
    ///
    /// Set to INT_MIN when dts_sync_point unused. Otherwise, it must
    /// contain a valid timestamp offset.
    ///
    /// Note that the timestamp of sync point has usually a nonzero
    /// dts_ref_dts_delta, which refers to the previous sync point. Offset of
    /// the next frame after timestamp sync point will be usually 1.
    ///
    /// For example, this corresponds to H.264 cpb_removal_delay.
    /// </summary>
    public int DtsRefDtsDelta;

    /// <summary>
    /// Presentation delay of current frame in units of AVCodecContext.time_base.
    ///
    /// Set to INT_MIN when dts_sync_point unused. Otherwise, it must
    /// contain valid non-negative timestamp delta (presentation time of a frame
    /// must not lie in the past).
    ///
    /// This delay represents the difference between decoding and presentation
    /// time of the frame.
    ///
    /// For example, this corresponds to H.264 dpb_output_delay.
    /// </summary>
    public int PtsDtsDelta;

    /// <summary>
    /// Position of the packet in file.
    /// Analogous to cur_frame_pts/dts
    /// </summary>
    public Array4<long> CurrentFramePos; // AV_PARSER_PTS_NB times

    /// <summary>
    /// Byte position of currently parsed frame in stream.
    /// </summary>
    public long Pos;

    /// <summary>
    /// Previous frame byte position.
    /// </summary>
    public long LastPos;

    /// <summary>
    /// Duration of the current frame.
    /// For audio, this is in units of 1 / AVCodecContext.sample_rate.
    /// For all other types, this is in units of AVCodecContext.time_base.
    /// </summary>
    public int Duration;

    public AVFieldOrder FieldOrder;

    /// <summary>
    /// Indicate whether a picture is coded as a frame, top field or bottom field.
    ///
    /// For example, H.264 field_pic_flag equal to 0 corresponds to
    /// AV_PICTURE_STRUCTURE_FRAME. An H.264 picture with field_pic_flag
    /// equal to 1 and bottom_field_flag equal to 0 corresponds to
    /// AV_PICTURE_STRUCTURE_TOP_FIELD.
    /// </summary>
    public AVPictureStructure PictureStructure;

    /// <summary>
    /// Picture number incremented in presentation or output order.
    /// This field may be reinitialized at the first picture of a new sequence.
    ///
    /// For example, this corresponds to H.264 PicOrderCnt.
    /// </summary>
    public int OutputPictureNumber;

    /// <summary>
    /// Dimensions of the decoded video intended for presentation.
    /// </summary>
    public int Width, Height;

    /// <summary>
    /// Dimensions of the coded video.
    /// </summary>
    public int CodedWidth, CodedHeight;

    /// <summary>
    /// The format of the coded data, corresponds to enum AVPixelFormat for video
    /// and for enum AVSampleFormat for audio.
    ///
    /// Note that a decoder can have considerable freedom in how exactly it
    /// decodes the data, so the format reported here might be different from the
    /// one returned by a decoder.
    /// </summary>
    public int Format;
}
