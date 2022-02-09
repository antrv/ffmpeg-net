namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Media Type
/// </summary>
public enum AVMediaType
{
    /// <summary>
    /// Usually treated as AVMEDIA_TYPE_DATA
    /// </summary>
    Unknown = -1,
    Video,
    Audio,

    /// <summary>
    /// Opaque data information usually continuous
    /// </summary>
    Data,
    Subtitle,

    /// <summary>
    /// Opaque data information usually sparse
    /// </summary>
    Attachment,
}
