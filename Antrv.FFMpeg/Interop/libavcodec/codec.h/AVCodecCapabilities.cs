﻿namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVCodecCapabilities
{
    None = 0,

    /// <summary>
    /// Decoder can use draw_horiz_band callback.
    /// </summary>
    AV_CODEC_CAP_DRAW_HORIZ_BAND = 1 << 0,

    /// <summary>
    /// Codec uses get_buffer() or get_encode_buffer() for allocating buffers and
    /// supports custom allocators.
    /// If not set, it might not use get_buffer() or get_encode_buffer() at all, or
    /// use operations that assume the buffer was allocated by
    /// avcodec_default_get_buffer2 or avcodec_default_get_encode_buffer.
    /// </summary>
    AV_CODEC_CAP_DR1 = 1 << 1,

    /// <summary>
    /// Deprecated: Use parsers to always send proper frames.
    /// </summary>
    [Obsolete("Use parsers to always send proper frames.")]
    AV_CODEC_CAP_TRUNCATED = 1 << 3,

    /// <summary>
    /// Encoder or decoder requires flushing with NULL input at the end in order to give the complete and correct output.
    ///
    /// NOTE: If this flag is not set, the codec is guaranteed to never be fed with
    /// with NULL data. The user can still send NULL data to the public encode
    /// or decode function, but libavcodec will not pass it along to the codec unless this flag is set.
    ///
    /// Decoders: The decoder has a non-zero delay and needs to be fed with avpkt->data=NULL,
    /// avpkt->size=0 at the end to get the delayed data until the decoder no longer returns frames.
    ///
    /// Encoders: The encoder needs to be fed with NULL data at the end of encoding until the encoder no longer returns data.
    ///
    /// NOTE: For encoders implementing the AVCodec.encode2() function, setting this
    /// flag also means that the encoder must set the pts and duration for
    /// each output packet. If this flag is not set, the pts and duration will be determined by libavcodec from the input frame.
    /// </summary>
    AV_CODEC_CAP_DELAY = 1 << 5,

    /// <summary>
    /// Codec can be fed a final frame with a smaller size. This can be used to prevent truncation of the last audio samples.
    /// </summary>
    AV_CODEC_CAP_SMALL_LAST_FRAME = 1 << 6,

    /// <summary>
    /// Codec can output multiple frames per AVPacket
    /// Normally demuxers return one frame at a time, demuxers which do not do
    /// are connected to a parser to split what they return into proper frames.
    /// This flag is reserved to the very rare category of codecs which have a
    /// bitstream that cannot be split into frames without timeconsuming
    /// operations like full decoding. Demuxers carrying such bitstreams thus
    /// may return multiple frames in a packet. This has many disadvantages like
    /// prohibiting stream copy in many cases thus it should only be considered as a last resort.
    /// </summary>

    AV_CODEC_CAP_SUBFRAMES = 1 << 8,

    /// <summary>
    /// Codec is experimental and is thus avoided in favor of non experimental encoders
    /// </summary>
    AV_CODEC_CAP_EXPERIMENTAL = 1 << 9,

    /// <summary>
    /// Codec should fill in channel configuration and samplerate instead of container
    /// </summary>
    AV_CODEC_CAP_CHANNEL_CONF = 1 << 10,

    /// <summary>
    /// Codec supports frame-level multithreading.
    /// </summary>
    AV_CODEC_CAP_FRAME_THREADS = 1 << 12,

    /// <summary>
    /// Codec supports slice-based (or partition-based) multithreading.
    /// </summary>
    AV_CODEC_CAP_SLICE_THREADS = 1 << 13,

    /// <summary>
    /// Codec supports changed parameters at any point.
    /// </summary>
    AV_CODEC_CAP_PARAM_CHANGE = 1 << 14,

    /// <summary>
    /// Codec supports multithreading through a method other than slice- or
    /// frame-level multithreading. Typically this marks wrappers around
    /// multithreading-capable external libraries.
    /// </summary>
    AV_CODEC_CAP_OTHER_THREADS       =1 << 15,

    AV_CODEC_CAP_AUTO_THREADS = AV_CODEC_CAP_OTHER_THREADS,

    /// <summary>
    /// Audio encoder supports receiving a different number of samples in each call.
    /// </summary>
    AV_CODEC_CAP_VARIABLE_FRAME_SIZE = 1 << 16,

    /// <summary>
    /// Decoder is not a preferred choice for probing.
    /// This indicates that the decoder is not a good choice for probing.
    /// It could for example be an expensive to spin up hardware decoder,
    /// or it could simply not provide a lot of useful information about
    /// the stream.
    /// A decoder marked with this flag should only be used as last resort
    /// choice for probing.
    /// </summary>
    AV_CODEC_CAP_AVOID_PROBING = 1 << 17,

    /// <summary>
    /// Deprecated and unused. Use AVCodecDescriptor.props instead
    /// </summary>
    [Obsolete("Deprecated and unused. Use AVCodecDescriptor.props instead")]
    AV_CODEC_CAP_INTRA_ONLY = 0x40000000,

    /// <summary>
    /// Deprecated and unused. Use AVCodecDescriptor.props instead
    /// </summary>
    [Obsolete("Deprecated and unused. Use AVCodecDescriptor.props instead")]
    AV_CODEC_CAP_LOSSLESS = unchecked((int)0x80000000),

    /// <summary>
    /// Codec is backed by a hardware implementation. Typically used to
    /// identify a non-hwaccel hardware decoder. For information about hwaccels, use
    /// avcodec_get_hw_config() instead.
    /// </summary>
    AV_CODEC_CAP_HARDWARE = 1 << 18,

    /// <summary>
    /// Codec is potentially backed by a hardware implementation, but not
    /// necessarily. This is used instead of AV_CODEC_CAP_HARDWARE, if the
    /// implementation provides some sort of internal fallback.
    /// </summary>
    AV_CODEC_CAP_HYBRID = 1 << 19,

    /// <summary>
    /// This codec takes the reordered_opaque field from input AVFrames
    /// and returns it in the corresponding field in AVCodecContext after encoding.
    /// </summary>
    AV_CODEC_CAP_ENCODER_REORDERED_OPAQUE = 1 << 20,

    /// <summary>
    /// This encoder can be flushed using avcodec_flush_buffers(). If this flag is
    /// not set, the encoder must be closed and reopened to ensure that no frames remain pending.
    /// </summary>
    AV_CODEC_CAP_ENCODER_FLUSH = 1 << 21,
}
