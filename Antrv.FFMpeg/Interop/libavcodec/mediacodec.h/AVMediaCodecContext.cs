namespace Antrv.FFMpeg.Interop;

/// <summary>
/// This structure holds a reference to a android/view/Surface object that will
/// be used as output by the decoder.
/// </summary>
public struct AVMediaCodecContext
{
    /// <summary>
    /// android/view/Surface object reference.
    /// </summary>
    public IntPtr Surface;
}
