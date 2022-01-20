namespace Antrv.FFMpeg.Interop;

public struct AVCodec
{
    /// <summary>
    /// Name of the codec implementation.
    /// The name is globally unique among encoders and among decoders (but an encoder and a decoder can share the same name).
    /// This is the primary way to find a codec from the user perspective.
    /// </summary>
    public Utf8StringPtr Name;

    /// <summary>
    /// Descriptive name for the codec, meant to be more human readable than name.
    /// You should use the NULL_IF_CONFIG_SMALL() macro to define it.
    /// </summary>
    public Utf8StringPtr LongName;

    public AVMediaType Type;

    public AVCodecID Id;

    /// <summary>
    /// Codec capabilities.
    /// </summary>
    public AVCodecCapabilities Capabilities;

    /// <summary>
    /// maximum value for lowres supported by the decoder
    /// </summary>
    public byte MaxLowRes;

    /// <summary>
    /// array of supported framerates, or NULL if any, array is terminated by {0,0}
    /// </summary>
    public ConstPtr<AVRational> SupportedFramerates;

    /// <summary>
    /// array of supported pixel formats, or NULL if unknown, array is terminated by -1
    /// </summary>
    public ConstPtr<AVPixelFormat> PixelFormats;

    /// <summary>
    /// array of supported audio samplerates, or NULL if unknown, array is terminated by 0
    /// </summary>
    public ConstPtr<int> SupportedSamplerates;

    /// <summary>
    /// array of supported sample formats, or NULL if unknown, array is terminated by -1
    /// </summary>
    public ConstPtr<AVSampleFormat> SampleFormats;

    /// <summary>
    /// array of support channel layouts, or NULL if unknown. array is terminated by 0
    /// </summary>
    public ConstPtr<AVChannelLayout> ChannelLayouts;

    /// <summary>
    /// AVClass for the private context
    /// </summary>
    public ConstPtr<AVClass> PrivateClass;

    /// <summary>
    /// array of recognized profiles, or NULL if unknown, array is terminated by {FF_PROFILE_UNKNOWN}
    /// </summary>
    public ConstPtr<AVProfile> Profiles;

    /// <summary>
    /// Group name of the codec implementation.
    /// This is a short symbolic name of the wrapper backing this codec. A
    /// wrapper uses some kind of external implementation for the codec, such
    /// as an external library, or a codec implementation provided by the OS or
    /// the hardware.
    /// If this field is NULL, this is a builtin, libavcodec native codec.
    /// If non-NULL, this will be the suffix in AVCodec.name in most cases
    /// (usually AVCodec.name will be of the form "&lt;codec_name>_&lt;wrapper_name>").
    /// </summary>
    public Utf8StringPtr WrapperName;

    // No fields below this line are part of the public API. They
    // may not be used outside of libavcodec and can be changed and
    // removed at will. New public fields should be added right above.
}
