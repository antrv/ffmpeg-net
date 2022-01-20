using Antrv.FFMpeg.Types;

namespace Antrv.FFMpeg.Interop;

/// <summary>
/// This structure describes how to handle film grain synthesis for codecs using
/// the ITU-T H.274 Versatile supplemental enhancement information message.
///
/// The struct must be allocated as part of AVFilmGrainParams using
/// av_film_grain_params_alloc(). Its size is not a part of the public ABI.
/// </summary>
public struct AVFilmGrainH274Params 
{
    /// <summary>
    /// Specifies the film grain simulation mode.
    /// 0 = Frequency filtering, 1 = Auto-regression
    /// </summary>
    public int ModelId;

    /// <summary>
    /// Specifies the bit depth used for the luma component.
    /// </summary>
    public int BitDepthLuma;

    /// <summary>
    /// Specifies the bit depth used for the chroma components.
    /// </summary>
    public int BitDepthChroma;

    public AVColorRange ColorRange;
    public AVColorPrimaries ColorPrimaries;
    public AVColorTransferCharacteristic ColorTrc;
    public AVColorSpace ColorSpace;

    /// <summary>
    /// Specifies the blending mode used to blend the simulated film grain with the decoded images.
    /// 0 = Additive, 1 = Multiplicative
    /// </summary>
    public int BlendingModeId;

    /// <summary>
    /// Specifies a scale factor used in the film grain characterization equations.
    /// </summary>
    public int Log2ScaleFactor;

    /// <summary>
    /// Indicates if the modeling of film grain for a given component is present.
    /// (y, cb, cr)
    /// </summary>
    public Array3<int> ComponentModelPresent;

    /// <summary>
    /// Specifies the number of intensity intervals for which a specific
    /// set of model values has been estimated, with a range of [1, 256].
    /// (y, cb, cr)
    /// </summary>
    public Array3<ushort> NumIntensityIntervals;

    /// <summary>
    /// Specifies the number of model values present for each intensity
    /// interval in which the film grain has been modelled, with a range of [1, 6].
    /// (y, cb, cr)
    /// </summary>
    public Array3<byte> NumModelValues;

    /// <summary>
    /// Specifies the lower bounds of each intensity interval for which
    /// the set of model values applies for the component.
    /// (y, cb, cr) (intensity interval)
    /// </summary>
    public Array3<Array256<byte>> IntensityIntervalLowerBound;

    /// <summary>
    /// Specifies the upper bound of each intensity interval for which the set of
    /// model values applies for the component.
    /// (y, cb, cr) (intensity interval)
    /// </summary>
    public Array3<Array256<byte>> IntensityIntervalUpperBound;

    /// <summary>
    /// Specifies the model values for the component for each intensity interval.
    /// - When model_id == 0, the following applies:
    ///     For comp_model_value[y], the range of values is [0, 2^bit_depth_luma - 1]
    ///     For comp_model_value[cb..cr], the range of values is [0, 2^bit_depth_chroma - 1]
    /// - Otherwise, the following applies:
    ///     For comp_model_value[y], the range of values is [-2^(bit_depth_luma - 1), 2^(bit_depth_luma - 1) - 1]
    ///     For comp_model_value[cb..cr], the range of values is [-2^(bit_depth_chroma - 1), 2^(bit_depth_chroma - 1) - 1]
    /// (y, cb, cr) (intensity interval) (model, value)
    /// </summary>
    public Array3<Array256<Array6<short>>> CompModelValue;
}
