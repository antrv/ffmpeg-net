namespace Antrv.FFMpeg.Interop;

/// <summary>
/// This struct describes the constraints on hardware frames attached to
/// a given device with a hardware-specific configuration.  This is returned
/// by av_hwdevice_get_hwframe_constraints() and must be freed by
/// av_hwframe_constraints_free() after use.
/// </summary>
public struct AVHWFramesConstraints
{
    /// <summary>
    /// A list of possible values for format in the hw_frames_ctx,
    /// terminated by AV_PIX_FMT_NONE.  This member will always be filled.
    /// </summary>
    public Ptr<AVPixelFormat> ValidHwFormats;

    /// <summary>
    /// A list of possible values for sw_format in the hw_frames_ctx,
    /// terminated by AV_PIX_FMT_NONE.  Can be NULL if this information is not known.
    /// </summary>
    public Ptr<AVPixelFormat> ValidSwFormats;

    /// <summary>
    /// The minimum size of frames in this hw_frames_ctx. (Zero if not known.)
    /// </summary>
    public int MinWidth, MinHeight;

    /// <summary>
    /// The maximum size of frames in this hw_frames_ctx. (INT_MAX if not known / no limit.)
    /// </summary>
    public int MaxWidth, MaxHeight;
}
