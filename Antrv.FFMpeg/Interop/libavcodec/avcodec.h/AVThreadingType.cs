namespace Antrv.FFMpeg.Interop;

public enum AVThreadingType
{
    Default = 0,

    /// <summary>
    /// Decode more than one frame at once
    /// </summary>
    FF_THREAD_FRAME = 1,

    /// <summary>
    /// Decode more than one part of a single frame at once
    /// </summary>
    FF_THREAD_SLICE = 2,
}
