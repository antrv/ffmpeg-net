using Antrv.FFMpeg.Types;

namespace Antrv.FFMpeg.Interop;

/// <summary>
/// This structure describes how to handle film grain synthesis for AOM codecs.
///
/// The struct must be allocated as part of AVFilmGrainParams using
/// av_film_grain_params_alloc(). Its size is not a part of the public ABI.
/// </summary>
public struct AVFilmGrainAomParams 
{
    /// <summary>
    /// Number of points of the piecewise linear scaling function for the uma plane.
    /// </summary>
    public int NumYPoints;

    /// <summary>
    /// The scale and value for each point of the piecewise linear scaling function for the uma plane.
    /// </summary>
    public Array14<Array2<byte>> YPoints;

    /// <summary>
    /// Signals whether to derive the chroma scaling function from the luma.
    /// Not equivalent to copying the luma values and scales.
    /// </summary>
    public int ChromaScalingFromLuma;

    /// <summary>
    /// If chroma_scaling_from_luma is set to 0, signals the chroma scaling function parameters.
    /// (cb, cr)
    /// </summary>
    public Array2<int> NumUvPoints;

    /// <summary>
    /// (cb, cr) (value, scaling)
    /// </summary>
    public Array2<Array10<Array2<byte>>> UvPoints;

    /// <summary>
    /// Specifies the shift applied to the chroma components.
    /// For AV1, its within [8; 11] and determines the range and quantization of the film grain.
    /// </summary>
    public int ScalingShift;

    /// <summary>
    /// Specifies the auto-regression lag.
    /// </summary>
    public int ArCoeffLag;

    /// <summary>
    /// Luma auto-regression coefficients. The number of coefficients is
    /// given by 2 * ar_coeff_lag * (ar_coeff_lag + 1).
    /// </summary>
    public Array24<sbyte> ArCoeffsY;

    /// <summary>
    /// Chroma auto-regression coefficients. The number of coefficients is
    /// given by 2 * ar_coeff_lag * (ar_coeff_lag + 1) + !!num_y_points.
    /// (cb, cr)
    /// </summary>
    public Array2<Array25<sbyte>> ArCoeffsUv;

    /// <summary>
    /// Specifies the range of the auto-regressive coefficients. Values of 6, 7, 8 and so on
    /// represent a range of [-2, 2), [-1, 1), [-0.5, 0.5) and so on. For AV1 must be between 6 and 9.
    /// </summary>
    public int ArCoeffShift;

    /// <summary>
    /// Signals the down shift applied to the generated gaussian numbers during synthesis.
    /// </summary>
    public int GrainScaleShift;

    /// <summary>
    /// Specifies the chroma multipliers for the index to the component scaling function.
    /// (cb, cr)
    /// </summary>
    public Array2<int> UvMult;
    /// <summary>
    /// Specifies the luma multipliers for the index to the component scaling function.
    /// (cb, cr)
    /// </summary>
    public Array2<int> UvMultLuma;

    /// <summary>
    /// Offset used for component scaling function. For AV1 its a 9-bit value with a range [-256, 255]
    /// (cb, cr)
    /// </summary>
    public Array2<int> UvOffset;

    /// <summary>
    /// Signals whether to overlap film grain blocks.
    /// </summary>
    public int OverlapFlag;

    /// <summary>
    /// Signals to clip to limited color levels after film grain application.
    /// </summary>
    public int LimitOutputRange;
}
