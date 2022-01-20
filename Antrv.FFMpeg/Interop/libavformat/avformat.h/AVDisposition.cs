namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVDisposition
{
    None = 0,

    /// <summary>
    /// The stream should be chosen by default among other streams of the same type,
    /// unless the user has explicitly specified otherwise.
    /// </summary>
    AV_DISPOSITION_DEFAULT = 1 << 0,

    /// <summary>
    /// The stream is not in original language.
    ///
    /// Note: AV_DISPOSITION_ORIGINAL is the inverse of this disposition. At most
    /// one of them should be set in properly tagged streams.
    /// This disposition may apply to any stream type, not just audio.
    /// </summary>
    AV_DISPOSITION_DUB = 1 << 1,

    /// <summary>
    /// The stream is in original language.
    /// see the notes for AV_DISPOSITION_DUB
    /// </summary>
    AV_DISPOSITION_ORIGINAL = 1 << 2,

    /// <summary>
    /// The stream is a commentary track.
    /// </summary>
    AV_DISPOSITION_COMMENT = 1 << 3,

    /// <summary>
    /// The stream contains song lyrics.
    /// </summary>
    AV_DISPOSITION_LYRICS = 1 << 4,

    /// <summary>
    /// The stream contains karaoke audio.
    /// </summary>
    AV_DISPOSITION_KARAOKE = 1 << 5,

    /// <summary>
    /// Track should be used during playback by default.
    /// Useful for subtitle track that should be displayed
    /// even when user did not explicitly ask for subtitles.
    /// </summary>
    AV_DISPOSITION_FORCED = 1 << 6,

    /// <summary>
    /// The stream is intended for hearing impaired audiences.
    /// </summary>
    AV_DISPOSITION_HEARING_IMPAIRED = 1 << 7,

    /// <summary>
    /// The stream is intended for visually impaired audiences.
    /// </summary>
    AV_DISPOSITION_VISUAL_IMPAIRED = 1 << 8,

    /// <summary>
    /// The audio stream contains music and sound effects without voice.
    /// </summary>
    AV_DISPOSITION_CLEAN_EFFECTS = 1 << 9,

    /// <summary>
    /// The stream is stored in the file as an attached picture/"cover art" (e.g.
    /// APIC frame in ID3v2). The first (usually only) packet associated with it
    /// will be returned among the first few packets read from the file unless
    /// seeking takes place. It can also be accessed at any time in AVStream.attached_pic.
    /// </summary>
    AV_DISPOSITION_ATTACHED_PIC = 1 << 10,

    /// <summary>
    /// The stream is sparse, and contains thumbnail images, often corresponding
    /// to chapter markers. Only ever used with AV_DISPOSITION_ATTACHED_PIC.
    /// </summary>
    AV_DISPOSITION_TIMED_THUMBNAILS = 1 << 11,

    /// <summary>
    /// The subtitle stream contains captions, providing a transcription and possibly
    /// a translation of audio. Typically intended for hearing-impaired audiences.
    /// </summary>
    AV_DISPOSITION_CAPTIONS = 1 << 16,

    /// <summary>
    /// The subtitle stream contains a textual description of the video content.
    /// Typically intended for visually-impaired audiences or for the cases where the
    /// video cannot be seen.
    /// </summary>
    AV_DISPOSITION_DESCRIPTIONS = 1 << 17,

    /// <summary>
    /// The subtitle stream contains time-aligned metadata that is not intended to be
    /// directly presented to the user.
    /// </summary>
    AV_DISPOSITION_METADATA = 1 << 18,

    /// <summary>
    /// The audio stream is intended to be mixed with another stream before presentation.
    /// Corresponds to mix_type=0 in mpegts.
    /// </summary>
    AV_DISPOSITION_DEPENDENT = 1 << 19,

    /// <summary>
    /// The video stream contains still images.
    /// </summary>
    AV_DISPOSITION_STILL_IMAGE = 1 << 20,
}
