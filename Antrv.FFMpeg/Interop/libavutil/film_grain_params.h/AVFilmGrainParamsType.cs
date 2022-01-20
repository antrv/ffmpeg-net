namespace Antrv.FFMpeg.Interop;

public enum AVFilmGrainParamsType
{
    AV_FILM_GRAIN_PARAMS_NONE = 0,

    /// <summary>
    /// The union is valid when interpreted as AVFilmGrainAOMParams (codec.aom)
    /// </summary>
    AV_FILM_GRAIN_PARAMS_AV1,

    /// <summary>
    /// The union is valid when interpreted as AVFilmGrainH274Params (codec.h274)
    /// </summary>
    AV_FILM_GRAIN_PARAMS_H274,
}
