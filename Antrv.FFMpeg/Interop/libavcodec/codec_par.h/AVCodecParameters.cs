namespace Antrv.FFMpeg.Interop;

public struct AVCodecParameters
{
    /// <summary>
    /// General type of the encoded data.
    /// </summary>
    public AVMediaType CodecType;

    /// <summary>
    /// Specific type of the encoded data (the codec used).
    /// </summary>
    public AVCodecID CodecId;

    /// <summary>
    /// Additional information about the codec (corresponds to the AVI FOURCC).
    /// </summary>
    public uint CodecTag;

    /// <summary>
    /// Extra binary data needed for initializing the decoder, codec-dependent.
    ///
    /// Must be allocated with av_malloc() and will be freed by
    /// avcodec_parameters_free(). The allocated size of extradata must be at
    /// least extradata_size + AV_INPUT_BUFFER_PADDING_SIZE, with the padding
    /// bytes zeroed.
    /// </summary>
    public Ptr<byte> ExtraData;

    /// <summary>
    /// Size of the extradata content in bytes.
    /// </summary>
    public int ExtraDataSize;

    /// <summary>
    /// - video: the pixel format, the value corresponds to enum AVPixelFormat.
    /// - audio: the sample format, the value corresponds to enum AVSampleFormat.
    /// </summary>
    public int Format;

    /// <summary>
    /// The average bitrate of the encoded data (in bits per second).
    /// </summary>
    public long BitRate;

    /// <summary>
    /// The number of bits per sample in the codedwords.
    ///
    /// This is basically the bitrate per sample. It is mandatory for a bunch of
    /// formats to actually decode them. It's the number of bits for one sample in
    /// the actual coded bitstream.
    /// 
    /// This could be for example 4 for ADPCM
    /// For PCM formats this matches bits_per_raw_sample
    /// Can be 0
    /// </summary>
    public int BitsPerCodedSample;

    /// <summary>
    /// This is the number of valid bits in each output sample. If the
    /// sample format has more bits, the least significant bits are additional
    /// padding bits, which are always 0. Use right shifts to reduce the sample
    /// to its actual size. For example, audio formats with 24 bit samples will
    /// have bits_per_raw_sample set to 24, and format set to AV_SAMPLE_FMT_S32.
    /// To get the original sample use "(int32_t)sample >> 8"."
    ///
    /// For ADPCM this might be 12 or 16 or similar
    /// Can be 0
    /// </summary>
    public int BitsPerRawSample;

    /// <summary>
    /// Codec-specific bitstream restrictions that the stream conforms to.
    /// </summary>
    public int Profile;
    /// <summary>
    /// Codec-specific bitstream restrictions that the stream conforms to.
    /// </summary>
    public int Level;

    /// <summary>
    /// Video only. The dimensions of the video frame in pixels.
    /// </summary>
    public int Width;
    /// <summary>
    /// Video only. The dimensions of the video frame in pixels.
    /// </summary>
    public int Height;

    /// <summary>
    /// Video only. The aspect ratio (width / height) which a single pixel
    /// should have when displayed.
    ///
    /// When the aspect ratio is unknown / undefined, the numerator should be
    /// set to 0 (the denominator may have any value).
    /// </summary>
    public AVRational SampleAspectRatio;

    /// <summary>
    /// Video only. The order of the fields in interlaced video.
    /// </summary>
    public AVFieldOrder FieldOrder;

    /// <summary>
    /// Video only. Additional colorspace characteristics.
    /// </summary>
    public AVColorRange ColorRange;
    /// <summary>
    /// Video only. Additional colorspace characteristics.
    /// </summary>
    public AVColorPrimaries ColorPrimaries;
    /// <summary>
    /// Video only. Additional colorspace characteristics.
    /// </summary>
    public AVColorTransferCharacteristic ColorTrc;
    /// <summary>
    /// Video only. Additional colorspace characteristics.
    /// </summary>
    public AVColorSpace ColorSpace;
    /// <summary>
    /// Video only. Additional colorspace characteristics.
    /// </summary>
    public AVChromaLocation ChromaLocation;

    /// <summary>
    /// Video only. Number of delayed frames.
    /// </summary>
    public int VideoDelay;

    /// <summary>
    /// Audio only. The channel layout bitmask. May be 0 if the channel layout is
    /// unknown or unspecified, otherwise the number of bits set must be equal to
    /// the channels field.
    /// </summary>
    public AVChannelLayout ChannelLayout;

    /// <summary>
    /// Audio only. The number of audio channels.
    /// </summary>
    public int Channels;

    /// <summary>
    /// Audio only. The number of audio samples per second.
    /// </summary>
    public int SampleRate;

    /// <summary>
    /// Audio only. The number of bytes per coded audio frame, required by some formats.
    /// Corresponds to nBlockAlign in WAVEFORMATEX.
    /// </summary>
    public int BlockAlign;

    /// <summary>
    /// Audio only. Audio frame size, if known. Required by some formats to be static.
    /// </summary>
    public int FrameSize;

    /// <summary>
    /// Audio only. The amount of padding (in samples) inserted by the encoder at
    /// the beginning of the audio. I.e. this number of leading decoded samples
    /// must be discarded by the caller to get the original audio without leading padding.
    /// </summary>
    public int InitialPadding;

    /// <summary>
    /// Audio only. The amount of padding (in samples) appended by the encoder to
    /// the end of the audio. I.e. this number of decoded samples must be
    /// discarded by the caller from the end of the stream to get the original
    /// audio without any trailing padding.
    /// </summary>
    public int TrailingPadding;

    /// <summary>
    /// Audio only. Number of samples to skip after a discontinuity.
    /// </summary>
    public int SeekPreroll;
}
