namespace Antrv.FFMpeg.Interop;

public enum AVSampleFormat
{
    AV_SAMPLE_FMT_NONE = -1,

    /// <summary>
    /// unsigned 8 bits
    /// </summary>
    AV_SAMPLE_FMT_U8,

    /// <summary>
    /// signed 16 bits
    /// </summary>
    AV_SAMPLE_FMT_S16,

    /// <summary>
    /// signed 32 bits
    /// </summary>
    AV_SAMPLE_FMT_S32,

    /// <summary>
    /// float
    /// </summary>
    AV_SAMPLE_FMT_FLT,

    /// <summary>
    /// double
    /// </summary>
    AV_SAMPLE_FMT_DBL,

    /// <summary>
    /// unsigned 8 bits, planar
    /// </summary>
    AV_SAMPLE_FMT_U8P,

    /// <summary>
    /// signed 16 bits, planar
    /// </summary>
    AV_SAMPLE_FMT_S16P,

    /// <summary>
    /// signed 32 bits, planar
    /// </summary>
    AV_SAMPLE_FMT_S32P,

    /// <summary>
    /// float, planar
    /// </summary>
    AV_SAMPLE_FMT_FLTP,

    /// <summary>
    /// double, planar
    /// </summary>
    AV_SAMPLE_FMT_DBLP,

    /// <summary>
    /// signed 64 bits
    /// </summary>
    AV_SAMPLE_FMT_S64,

    /// <summary>
    /// signed 64 bits, planar
    /// </summary>
    AV_SAMPLE_FMT_S64P,

    /// <summary>
    /// Number of sample formats. DO NOT USE if linking dynamically
    /// </summary>
    AV_SAMPLE_FMT_NB
}
