namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVCodecExportSideDataFlags
{
    None = 0,

    /// <summary>
    /// Export motion vectors through frame side data.
    /// </summary>
    AV_CODEC_EXPORT_DATA_MVS = 1 << 0,

    /// <summary>
    /// Export encoder Producer Reference Time through packet side data
    /// </summary>
    AV_CODEC_EXPORT_DATA_PRFT = 1 << 1,

    /// <summary>
    /// Decoding only.
    /// Export the AVVideoEncParams structure through frame side data.
    /// </summary>
    AV_CODEC_EXPORT_DATA_VIDEO_ENC_PARAMS = 1 << 2,

    /// <summary>
    /// Decoding only.
    /// Do not apply film grain, export it instead.
    /// </summary>
    AV_CODEC_EXPORT_DATA_FILM_GRAIN = 1 << 3,
}
