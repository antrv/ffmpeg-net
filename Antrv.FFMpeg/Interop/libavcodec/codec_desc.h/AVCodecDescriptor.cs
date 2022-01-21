namespace Antrv.FFMpeg.Interop;

/// <summary>
/// This struct describes the properties of a single codec described by an AVCodecID.
/// </summary>
public struct AVCodecDescriptor
{
    public AVCodecID Id;

    public AVMediaType Type;

    /// <summary>
    /// Name of the codec described by this descriptor. It is non-empty and
    /// unique for each codec descriptor. It should contain alphanumeric
    /// characters and '_' only.
    /// </summary>
    public Utf8StringPtr Name;

    /// <summary>
    /// A more descriptive name for this codec. May be NULL.
    /// </summary>
    public Utf8StringPtr LongName;

    /// <summary>
    /// Codec properties, a combination of AV_CODEC_PROP_* flags.
    /// </summary>
    public AVCodecProperties Properties;

    /// <summary>
    /// MIME type(s) associated with the codec.
    /// May be NULL; if not, a NULL-terminated array of MIME types.
    /// The first item is always non-NULL and is the preferred MIME type.
    /// </summary>
    public ConstPtr<Utf8StringPtr> MimeTypes;

    /// <summary>
    /// If non-NULL, an array of profiles recognized for this codec.
    /// Terminated with FF_PROFILE_UNKNOWN.
    /// </summary>
    public ConstPtr<AVProfile> Profiles;
}
