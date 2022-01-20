using Antrv.FFMpeg.Types;

namespace Antrv.FFMpeg.Interop;

/// <summary>
/// This structure describes how to handle film grain synthesis in video
/// for specific codecs. Must be present on every frame where film grain is
/// meant to be synthesized for correct presentation.
///
/// The struct must be allocated with av_film_grain_params_alloc() and
/// its size is not a part of the public ABI.
/// </summary>
public struct AVFilmGrainParams 
{
    /// <summary>
    /// Specifies the codec for which this structure is valid.
    /// </summary>
    public AVFilmGrainParamsType Type;

    /// <summary>
    /// Seed to use for the synthesis process, if the codec allows for it.
    /// For H.264, this refers to `pic_offset` as defined in SMPTE RDD 5-2006.
    /// </summary>
    public ulong Seed;

    /// <summary>
    /// Additional fields may be added both here and in any structure included.
    /// If a codec's film grain structure differs slightly over another
    /// codec's, fields within may change meaning depending on the type.
    /// </summary>
    public Union<AVFilmGrainAomParams, AVFilmGrainH274Params> Codec;
}
