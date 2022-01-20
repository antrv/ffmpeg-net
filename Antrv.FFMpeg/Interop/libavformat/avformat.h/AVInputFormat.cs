namespace Antrv.FFMpeg.Interop;

public struct AVInputFormat
{
    /// <summary>
    /// A comma separated list of short names for the format. New names
    /// may be appended with a minor bump.
    /// </summary>
    public Utf8StringPtr Name;

    /// <summary>
    /// Descriptive name for the format, meant to be more human-readable
    /// than name. You should use the NULL_IF_CONFIG_SMALL() macro to define it.
    /// </summary>
    public Utf8StringPtr LongName;

    /// <summary>
    /// Can use flags: AVFMT_NOFILE, AVFMT_NEEDNUMBER, AVFMT_SHOW_IDS,
    /// AVFMT_NOTIMESTAMPS, AVFMT_GENERIC_INDEX, AVFMT_TS_DISCONT, AVFMT_NOBINSEARCH,
    /// AVFMT_NOGENSEARCH, AVFMT_NO_BYTE_SEEK, AVFMT_SEEK_TO_PTS.
    /// </summary>
    public AVFormatFlags Flags;

    /// <summary>
    /// If extensions are defined, then no probe is done. You should
    /// usually not use extension format guessing because it is not
    /// reliable enough
    /// </summary>
    public Utf8StringPtr Extensions;

    /// <summary>
    /// List of supported codec_id-codec_tag pairs, ordered by "better
    /// choice first". The arrays are all terminated by AV_CODEC_ID_NONE.
    /// </summary>
    public ConstPtr<ConstPtr<AVCodecTag>> CodecTags;

    /// <summary>
    /// AVClass for the private context
    /// </summary>
    public Ptr<AVClass> PrivateClass;

    /// <summary>
    /// Comma-separated list of mime types.
    /// It is used check for matching mime types while probing.
    /// </summary>
    public Utf8StringPtr MimeTypes;

    // ***************************************************************
    // No fields below this line are part of the public API. They
    // may not be used outside of libavformat and can be changed and
    // removed at will.
    // New public fields should be added right above.
    // ***************************************************************
}
