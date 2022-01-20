namespace Antrv.FFMpeg.Interop;

public struct AVComponentDescriptor
{
    /// <summary>
    /// Which of the 4 planes contains the component.
    /// </summary>
    public int Plane;

    /// <summary>
    /// Number of elements between 2 horizontally consecutive pixels.
    /// Elements are bits for bitstream formats, bytes otherwise.
    /// </summary>
    public int Step;

    /// <summary>
    /// Number of elements before the component of the first pixel.
    /// Elements are bits for bitstream formats, bytes otherwise.
    /// </summary>
    public int Offset;

    /// <summary>
    /// Number of least significant bits that must be shifted away to get the value.
    /// </summary>
    public int Shift;

    /// <summary>
    /// Number of bits in the component.
    /// </summary>
    public int Depth;
}
