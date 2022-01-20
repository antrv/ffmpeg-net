namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVPacketFlags
{
    None = 0,

    /// <summary>
    /// The packet contains a keyframe.
    /// </summary>
    AV_PKT_FLAG_KEY = 0x0001,

    /// <summary>
    /// The packet content is corrupted.
    /// </summary>
    AV_PKT_FLAG_CORRUPT = 0x0002,

    /// <summary>
    /// Flag is used to discard packets which are required to maintain valid
    /// decoder state but are not required for output and should be dropped
    /// after decoding.
    /// </summary>
    AV_PKT_FLAG_DISCARD = 0x0004,

    /// <summary>
    /// The packet comes from a trusted source.
    /// Otherwise-unsafe constructs such as arbitrary pointers to data
    /// outside the packet may be followed.
    /// </summary>
    AV_PKT_FLAG_TRUSTED = 0x0008,

    /// <summary>
    /// Flag is used to indicate packets that contain frames that can
    /// be discarded by the decoder.  I.e. Non-reference frames.
    /// </summary>
    AV_PKT_FLAG_DISPOSABLE = 0x0010,
}
