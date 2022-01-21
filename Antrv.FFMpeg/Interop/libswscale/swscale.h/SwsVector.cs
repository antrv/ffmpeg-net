namespace Antrv.FFMpeg.Interop;

/// <summary>
/// when used for filters they must have an odd number of elements
/// coeffs cannot be shared between vectors
/// </summary>
public struct SwsVector
{
    /// <summary>
    /// pointer to the list of coefficients
    /// </summary>
    public Ptr<double> Coeff;
    /// <summary>
    /// number of coefficients in the vector
    /// </summary>
    public int Length;
}
