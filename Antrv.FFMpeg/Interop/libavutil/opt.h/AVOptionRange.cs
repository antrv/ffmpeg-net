namespace Antrv.FFMpeg.Interop;

/// <summary>
/// A single allowed range of values, or a single allowed value.
/// </summary>
public struct AVOptionRange
{
    /// <summary>
    /// Value range.
    /// For string ranges this represents the min/max length.
    /// For dimensions this represents the min/max pixel count or width/height in multi-component case.
    /// </summary>
    public double ValueMin, ValueMax;

    /// <summary>
    /// Value's component range.
    /// For string this represents the unicode range for chars, 0-127 limits to ASCII.
    /// </summary>
    public double ComponentMin, ComponentMax;

    /// <summary>
    /// Range flag.
    /// If set to 1 the struct encodes a range, if set to 0 a single value.
    /// </summary>
    public int IsRange;
}
