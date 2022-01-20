namespace Antrv.FFMpeg.Interop;

public struct AVOutputFormat
{
    public Utf8StringPtr Name;

    /// <summary>
    /// Descriptive name for the format, meant to be more human-readable
    /// than name. You should use the NULL_IF_CONFIG_SMALL() macro to define it.
    /// </summary>
    public Utf8StringPtr LongName;

    public Utf8StringPtr MimeType;

    /// <summary>
    /// comma-separated filename extensions
    /// </summary>
    public Utf8StringPtr Extensions;

    /// <summary>
    /// default audio codec
    /// </summary>
    public AVCodecID AudioCodec;

    /// <summary>
    /// default video codec
    /// </summary>
    public AVCodecID VideoCodec;

    /// <summary>
    /// default subtitle codec
    /// </summary>
    public AVCodecID SubtitleCodec;

    /// <summary>
    /// can use flags: AVFMT_NOFILE, AVFMT_NEEDNUMBER,
    /// AVFMT_GLOBALHEADER, AVFMT_NOTIMESTAMPS, AVFMT_VARIABLE_FPS,
    /// AVFMT_NODIMENSIONS, AVFMT_NOSTREAMS, AVFMT_ALLOW_FLUSH,
    /// AVFMT_TS_NONSTRICT, AVFMT_TS_NEGATIVE
    /// </summary>
    public AVFormatFlags Flags;

    /// <summary>
    /// List of supported codec_id-codec_tag pairs, ordered by "better
    /// choice first". The arrays are all terminated by AV_CODEC_ID_NONE.
    /// </summary>
    public ConstPtr<ConstPtr<AVCodecTag>> CodecTags;

    /// <summary>
    /// AVClass for the private context
    /// </summary>
    public ConstPtr<AVClass> PrivateClass;

    // ***************************************************************
    // No fields below this line are part of the public API. They
    // may not be used outside of libavformat and can be changed and
    // removed at will.
    // New public fields should be added right above.
    // ***************************************************************
}
