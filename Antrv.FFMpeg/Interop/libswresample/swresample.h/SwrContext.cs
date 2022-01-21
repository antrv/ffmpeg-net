namespace Antrv.FFMpeg.Interop;

/// <summary>
/// The libswresample context. Unlike libavcodec and libavformat, this structure
/// is opaque. This means that if you would like to set options, you must use
/// the avoptions API and cannot directly set values to members of the structure.
/// </summary>
public struct SwrContext
{
    // Opaque structure
}
