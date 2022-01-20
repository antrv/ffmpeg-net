namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// minimum number of bytes to read from a DV stream in order to determine the profile (6 DIF blocks)
    /// </summary>
    public const int DV_PROFILE_BYTES = 6 * 80;

    /// <summary>
    /// Get a DV profile for the provided compressed frame.
    /// </summary>
    /// <param name="sys">the profile used for the previous frame, may be NULL</param>
    /// <param name="frame">the compressed data buffer</param>
    /// <param name="bufferSize">size of the buffer in bytes</param>
    /// <returns>the DV profile for the supplied data or NULL on failure</returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVDVProfile> av_dv_frame_profile(ConstPtr<AVDVProfile> sys, ConstPtr<byte> frame,
        uint bufferSize);

    /// <summary>
    /// Get a DV profile for the provided stream parameters.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="pixelFormat"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVDVProfile> av_dv_codec_profile(int width, int height, AVPixelFormat pixelFormat);

    /// <summary>
    /// Get a DV profile for the provided stream parameters.
    /// The frame rate is used as a best-effort parameter.
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="pixelFormat"></param>
    /// <param name="frameRate"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVDVProfile> av_dv_codec_profile2(int width, int height, AVPixelFormat pixelFormat,
        AVRational frameRate);
}
