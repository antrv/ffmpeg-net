namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVCodecProperties
{
    None = 0,

    /// <summary>
    /// Codec uses only intra compression.
    /// Video and audio codecs only.
    /// </summary>
    AV_CODEC_PROP_INTRA_ONLY = 1 << 0,

    /// <summary>
    /// Codec supports lossy compression. Audio and video codecs only.
    /// A codec may support both lossy and lossless compression modes.
    /// </summary>
    AV_CODEC_PROP_LOSSY = 1 << 1,

    /// <summary>
    /// Codec supports lossless compression. Audio and video codecs only.
    /// </summary>
    AV_CODEC_PROP_LOSSLESS = 1 << 2,

    /// <summary>
    /// Codec supports frame reordering. That is, the coded order (the order in which
    /// the encoded packets are output by the encoders / stored / input to the
    /// decoders) may be different from the presentation order of the corresponding
    /// frames.
    ///
    /// For codecs that do not have this property set, PTS and DTS should always be equal.
    /// </summary>
    AV_CODEC_PROP_REORDER = 1 << 3,

    /// <summary>
    /// Subtitle codec is bitmap based.
    /// Decoded AVSubtitle data can be read from the AVSubtitleRect->pict field.
    /// </summary>
    AV_CODEC_PROP_BITMAP_SUB = 1 << 16,

    /// <summary>
    /// Subtitle codec is text based.
    /// Decoded AVSubtitle data can be read from the AVSubtitleRect->ass field.
    /// </summary>
    AV_CODEC_PROP_TEXT_SUB = 1 << 17,
}
