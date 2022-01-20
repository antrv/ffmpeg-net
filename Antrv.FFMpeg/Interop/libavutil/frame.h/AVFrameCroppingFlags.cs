namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Flags for frame cropping.
/// </summary>
[Flags]
public enum AVFrameCroppingFlags
{
    None = 0,
    /// <summary>
    /// Apply the maximum possible cropping, even if it requires setting the
    /// AVFrame.data[] entries to unaligned pointers. Passing unaligned data
    /// to FFmpeg API is generally not allowed, and causes undefined behavior
    /// (such as crashes). You can pass unaligned data only to FFmpeg APIs that
    /// are explicitly documented to accept it. Use this flag only if you
    /// absolutely know what you are doing.
    /// </summary>
    AV_FRAME_CROP_UNALIGNED = 1 << 0,
}
