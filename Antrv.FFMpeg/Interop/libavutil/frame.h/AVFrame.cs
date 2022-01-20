using Antrv.FFMpeg.Types;

namespace Antrv.FFMpeg.Interop;

/// <summary>
/// This structure describes decoded (raw) audio or video data.
///
/// AVFrame must be allocated using av_frame_alloc(). Note that this only
/// allocates the AVFrame itself, the buffers for the data must be managed
/// through other means (see below).
/// AVFrame must be freed with av_frame_free().
///
/// AVFrame is typically allocated once and then reused multiple times to hold
/// different data (e.g. a single AVFrame to hold frames received from a
/// decoder). In such a case, av_frame_unref() will free any references held by
/// the frame and reset it to its original clean state before it
/// is reused again.
///
/// The data described by an AVFrame is usually reference counted through the
/// AVBuffer API. The underlying buffer references are stored in AVFrame.buf /
/// AVFrame.extended_buf. An AVFrame is considered to be reference counted if at
/// least one reference is set, i.e. if AVFrame.buf[0] != NULL. In such a case,
/// every single data plane must be contained in one of the buffers in
/// AVFrame.buf or AVFrame.extended_buf.
/// There may be a single buffer for all the data, or one separate buffer for
/// each plane, or anything in between.
///
/// sizeof(AVFrame) is not a part of the public ABI, so new fields may be added
/// to the end with a minor bump.
///
/// Fields can be accessed through AVOptions, the name string used, matches the
/// C structure field name for fields accessible through AVOptions. The AVClass
/// for AVFrame can be obtained from avcodec_get_frame_class()
/// </summary>
public struct AVFrame
{
    /// <summary>
    /// pointer to the picture/channel planes.
    /// This might be different from the first allocated byte. For video,
    /// it could even point to the end of the image data.
    ///
    /// All pointers in data and extended_data must point into one of the
    /// AVBufferRef in buf or extended_buf.
    ///
    /// Some decoders access areas outside 0,0 - width,height, please
    /// see avcodec_align_dimensions2(). Some filters and swscale can read
    /// up to 16 bytes beyond the planes, if these filters are to be used,
    /// then 16 extra bytes must be allocated.
    ///
    /// NOTE: Pointers not needed by the format MUST be set to NULL.
    ///
    /// @attention In case of video, the data[] pointers can point to the
    /// end of image data in order to reverse line order, when used in
    /// combination with negative values in the linesize[] array.
    /// </summary>
    public Array8<Ptr<byte>> Data;

    /// <summary>
    /// For video, a positive or negative value, which is typically indicating
    /// the size in bytes of each picture line, but it can also be:
    /// - the negative byte size of lines for vertical flipping
    ///   (with data[n] pointing to the end of the data
    /// - a positive or negative multiple of the byte size as for accessing
    ///   even and odd fields of a frame (possibly flipped)
    ///
    /// For audio, only linesize[0] may be set. For planar audio, each channel
    /// plane must be the same size.
    ///
    /// For video the linesizes should be multiples of the CPUs alignment
    /// preference, this is 16 or 32 for modern desktop CPUs.
    /// Some code requires such alignment other code can be slower without
    /// correct alignment, for yet other it makes no difference.
    ///
    /// @note The linesize may be larger than the size of usable data -- there
    /// may be extra padding present for performance reasons.
    ///
    /// @attention In case of video, line size values can be negative to achieve
    /// a vertically inverted iteration over image lines.
    /// </summary>
    public Array8<int> LineSize;

    /// <summary>
    /// pointers to the data planes/channels.
    ///
    /// For video, this should simply point to data[].
    ///
    /// For planar audio, each channel has a separate data pointer, and
    /// linesize[0] contains the size of each channel buffer.
    /// For packed audio, there is just one data pointer, and linesize[0]
    /// contains the total size of the buffer for all channels.
    ///
    /// Note: Both data and extended_data should always be set in a valid frame,
    /// but for planar audio with more channels that can fit in data,
    /// extended_data must be used in order to access all channels.
    /// </summary>
    public Ptr<Ptr<byte>> ExtendedData;

    /// <summary>
    /// Video dimensions.
    /// Video frames only. The coded dimensions (in pixels) of the video frame,
    /// i.e. the size of the rectangle that contains some well-defined values.
    ///
    /// @note The part of the frame intended for display/presentation is further
    /// restricted by the @ref cropping "Cropping rectangle".
    /// </summary>
    public int Width, Height;

    /// <summary>
    /// number of audio samples (per channel) described by this frame
    /// </summary>
    public int NbSamples;

    /// <summary>
    /// format of the frame, -1 if unknown or unset
    /// Values correspond to enum AVPixelFormat for video frames,
    /// enum AVSampleFormat for audio)
    /// </summary>
    public int Format;

    /// <summary>
    /// 1 -> keyframe, 0-> not
    /// </summary>
    public int KeyFrame;

    /// <summary>
    /// Picture type of the frame.
    /// </summary>
    public AVPictureType PictType;

    /// <summary>
    /// Sample aspect ratio for the video frame, 0/1 if unknown/unspecified.
    /// </summary>
    public AVRational SampleAspectRatio;

    /// <summary>
    /// Presentation timestamp in time_base units (time when frame should be shown to user).
    /// </summary>
    public long Pts;

    /// <summary>
    /// DTS copied from the AVPacket that triggered returning this frame. (if frame threading isn't used)
    /// This is also the Presentation time of this AVFrame calculated from
    /// only AVPacket.dts values without pts values.
    /// </summary>
    public long PktDts;

    /// <summary>
    /// Time base for the timestamps in this frame.
    /// In the future, this field may be set on frames output by decoders or
    /// filters, but its value will be by default ignored on input to encoders
    /// or filters.
    /// </summary>
    public AVRational TimeBase;

    /// <summary>
    /// picture number in bitstream order
    /// </summary>
    public int CodedPictureNumber;
    /// <summary>
    /// picture number in display order
    /// </summary>
    public int DisplayPictureNumber;

    /// <summary>
    /// quality (between 1 (good) and FF_LAMBDA_MAX (bad))
    /// </summary>
    public int Quality;

    /// <summary>
    /// for some private data of the user
    /// </summary>
    public Ptr<byte> Opaque;

    /// <summary>
    /// When decoding, this signals how much the picture must be delayed.
    /// extra_delay = repeat_pict / (2*fps)
    /// </summary>
    public int RepeatPict;

    /// <summary>
    /// The content of the picture is interlaced.
    /// </summary>
    public int InterlacedFrame;

    /// <summary>
    /// If the content is interlaced, is top field displayed first.
    /// </summary>
    public int TopFieldFirst;

    /// <summary>
    /// Tell user application that palette has changed from previous frame.
    /// </summary>
    public int PaletteHasChanged;

    /// <summary>
    /// reordered opaque 64 bits (generally an integer or a double precision float
    /// PTS but can be anything).
    /// The user sets AVCodecContext.reordered_opaque to represent the input at
    /// that time,
    /// the decoder reorders values as needed and sets AVFrame.reordered_opaque
    /// to exactly one of the values provided by the user through AVCodecContext.reordered_opaque
    /// </summary>
    public long ReorderedOpaque;

    /// <summary>
    /// Sample rate of the audio data.
    /// </summary>
    public int SampleRate;

    /// <summary>
    /// Channel layout of the audio data.
    /// </summary>
    public AVChannelLayout ChannelLayout;

    /// <summary>
    /// AVBuffer references backing the data for this frame. All the pointers in
    /// data and extended_data must point inside one of the buffers in buf or
    /// extended_buf. This array must be filled contiguously -- if buf[i] is
    /// non-NULL then buf[j] must also be non-NULL for all j &lt; i.
    ///
    /// There may be at most one AVBuffer per data plane, so for video this array
    /// always contains all the references. For planar audio with more than
    /// AV_NUM_DATA_POINTERS channels, there may be more buffers than can fit in
    /// this array. Then the extra AVBufferRef pointers are stored in the
    /// extended_buf array.
    /// </summary>
    public Array8<Ptr<AVBufferRef>> Buf;

    /// <summary>
    /// For planar audio which requires more than AV_NUM_DATA_POINTERS
    /// AVBufferRef pointers, this array will hold all the references which
    /// cannot fit into AVFrame.buf.
    ///
    /// Note that this is different from AVFrame.extended_data, which always
    /// contains all the pointers. This array only contains the extra pointers,
    /// which cannot fit into AVFrame.buf.
    ///
    /// This array is always allocated using av_malloc() by whoever constructs
    /// the frame. It is freed in av_frame_unref().
    /// </summary>
    public Ptr<Ptr<AVBufferRef>> ExtendedBuf;

    /// <summary>
    /// Number of elements in extended_buf.
    /// </summary>
    public int NbExtendedBuf;

    public Ptr<Ptr<AVFrameSideData>> SideData;
    public int NbSideData;

    /// <summary>
    /// Frame flags
    /// </summary>
    public AVFrameFlags Flags;

    /// <summary>
    /// MPEG vs JPEG YUV range.
    /// - encoding: Set by user
    /// - decoding: Set by libavcodec
    /// </summary>
    public AVColorRange ColorRange;

    public AVColorPrimaries ColorPrimaries;

    public AVColorTransferCharacteristic ColorTrc;

    /// <summary>
    /// YUV colorspace type.
    /// - encoding: Set by user
    /// - decoding: Set by libavcodec
    /// </summary>
    public AVColorSpace ColorSpace;

    public AVChromaLocation ChromaLocation;

    /// <summary>
    /// frame timestamp estimated using various heuristics, in stream time base
    /// - encoding: unused
    /// - decoding: set by libavcodec, read by user.
    /// </summary>
    public long BestEffortTimestamp;

    /// <summary>
    /// reordered pos from the last AVPacket that has been input into the decoder
    /// - encoding: unused
    /// - decoding: Read by user.
    /// </summary>
    public long PktPos;

    /// <summary>
    /// duration of the corresponding packet, expressed in
    /// AVStream->time_base units, 0 if unknown.
    /// - encoding: unused
    /// - decoding: Read by user.
    /// </summary>
    public long PktDuration;

    /// <summary>
    /// metadata.
    /// - encoding: Set by user.
    /// - decoding: Set by libavcodec.
    /// </summary>
    public Ptr<AVDictionary> Metadata;

    /// <summary>
    /// decode error flags of the frame, set to a combination of
    /// FF_DECODE_ERROR_xxx flags if the decoder produced a frame, but there
    /// were errors during the decoding.
    /// - encoding: unused
    /// - decoding: set by libavcodec, read by user.
    /// </summary>
    public AVFrameDecodeErrorFlags DecodeErrorFlags;

    /// <summary>
    /// number of audio channels, only used for audio.
    /// - encoding: unused
    /// - decoding: Read by user.
    /// </summary>
    public int Channels;

    /// <summary>
    /// size of the corresponding packet containing the compressed
    /// frame.
    /// It is set to a negative value if unknown.
    /// - encoding: unused
    /// - decoding: set by libavcodec, read by user.
    /// </summary>
    public int PktSize;

    /// <summary>
    /// For hwaccel-format frames, this should be a reference to the
    /// AVHWFramesContext describing the frame.
    /// </summary>
    public Ptr<AVBufferRef> HwFramesCtx;

    /// <summary>
    /// AVBufferRef for free use by the API user. FFmpeg will never check the
    /// contents of the buffer ref. FFmpeg calls av_buffer_unref() on it when
    /// the frame is unreferenced. av_frame_copy_props() calls create a new
    /// reference with av_buffer_ref() for the target frame's opaque_ref field.
    ///
    /// This is unrelated to the opaque field, although it serves a similar
    /// purpose.
    /// </summary>
    public Ptr<AVBufferRef> OpaqueRef;

    /// <summary>
    /// Cropping.
    /// Video frames only. The number of pixels to discard from the the
    /// top/bottom/left/right border of the frame to obtain the sub-rectangle of
    /// the frame intended for presentation.
    /// </summary>
    public nuint CropTop, CropBottom, CropLeft, CropRight;

    /// <summary>
    /// AVBufferRef for internal use by a single libav* library.
    /// Must not be used to transfer data between libraries.
    /// Has to be NULL when ownership of the frame leaves the respective library.
    ///
    /// Code outside the FFmpeg libs should never check or change the contents of the buffer ref.
    ///
    /// FFmpeg calls av_buffer_unref() on it when the frame is unreferenced.
    /// av_frame_copy_props() calls create a new reference with av_buffer_ref()
    /// for the target frame's private_ref field.
    /// </summary>
    public Ptr<AVBufferRef> PrivateRef;
}
