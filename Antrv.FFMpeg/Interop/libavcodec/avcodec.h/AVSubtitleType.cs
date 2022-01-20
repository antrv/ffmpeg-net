namespace Antrv.FFMpeg.Interop;

public enum AVSubtitleType
{
    SUBTITLE_NONE,

    /// <summary>
    /// A bitmap, pict will be set
    /// </summary>
    SUBTITLE_BITMAP,

    /// <summary>
    /// Plain text, the text field must be set by the decoder and is authoritative. ass and pict fields may contain approximations.
    /// </summary>
    SUBTITLE_TEXT,

    /// <summary>
    /// Formatted text, the ass field must be set by the decoder and is authoritative. pict and text fields may contain approximations.
    /// </summary>
    SUBTITLE_ASS,
}
