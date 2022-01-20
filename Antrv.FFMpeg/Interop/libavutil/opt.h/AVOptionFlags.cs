namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVOptionFlags
{
    None = 0,

    /// <summary>
    /// a generic parameter which can be set by the user for muxing or encoding
    /// </summary>
    AV_OPT_FLAG_ENCODING_PARAM = 1,

    /// <summary>
    /// a generic parameter which can be set by the user for demuxing or decoding
    /// </summary>
    AV_OPT_FLAG_DECODING_PARAM = 2,
    AV_OPT_FLAG_AUDIO_PARAM = 8,
    AV_OPT_FLAG_VIDEO_PARAM = 16,
    AV_OPT_FLAG_SUBTITLE_PARAM = 32,

    /// <summary>
    /// The option is intended for exporting values to the caller.
    /// </summary>
    AV_OPT_FLAG_EXPORT = 64,

    /// <summary>
    /// The option may not be set through the AVOptions API, only read.
    /// This flag only makes sense when AV_OPT_FLAG_EXPORT is also set.
    /// </summary>
    AV_OPT_FLAG_READONLY = 128,

    /// <summary>
    /// a generic parameter which can be set by the user for bit stream filtering
    /// </summary>
    AV_OPT_FLAG_BSF_PARAM = 1 << 8,

    /// <summary>
    /// a generic parameter which can be set by the user at runtime
    /// </summary>
    AV_OPT_FLAG_RUNTIME_PARAM = 1 << 15,

    /// <summary>
    /// a generic parameter which can be set by the user for filtering
    /// </summary>
    AV_OPT_FLAG_FILTERING_PARAM = 1 << 16,

    /// <summary>
    /// set if option is deprecated, users should refer to AVOption.help text for more information
    /// </summary>
    AV_OPT_FLAG_DEPRECATED = 1 << 17,

    /// <summary>
    /// set if option constants can also reside in child objects
    /// </summary>
    AV_OPT_FLAG_CHILD_CONSTS = 1 << 18,
}
