namespace Antrv.FFMpeg.Interop;

/// <summary>
/// AVPicture types, pixel formats and basic image planes manipulation.
/// </summary>
public enum AVPictureType
{
    /// <summary>
    /// Undefined
    /// </summary>
    AV_PICTURE_TYPE_NONE = 0,

    /// <summary>
    /// Intra
    /// </summary>
    AV_PICTURE_TYPE_I,

    /// <summary>
    /// Predicted
    /// </summary>
    AV_PICTURE_TYPE_P,

    /// <summary>
    /// Bi-dir predicted
    /// </summary>
    AV_PICTURE_TYPE_B,

    /// <summary>
    /// S(GMC)-VOP MPEG-4
    /// </summary>
    AV_PICTURE_TYPE_S,

    /// <summary>
    /// Switching Intra
    /// </summary>
    AV_PICTURE_TYPE_SI,

    /// <summary>
    /// Switching Predicted
    /// </summary>
    AV_PICTURE_TYPE_SP,

    /// <summary>
    /// BI type
    /// </summary>
    AV_PICTURE_TYPE_BI,
}
