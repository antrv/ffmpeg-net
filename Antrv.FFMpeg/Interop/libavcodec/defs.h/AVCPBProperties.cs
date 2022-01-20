namespace Antrv.FFMpeg.Interop;

/// <summary>
/// This structure describes the bitrate properties of an encoded bitstream. It
/// roughly corresponds to a subset the VBV parameters for MPEG-2 or HRD
/// parameters for H.264/HEVC.
/// </summary>
public struct AVCPBProperties
{
    /// <summary>
    /// Maximum bitrate of the stream, in bits per second.
    /// Zero if unknown or unspecified.
    /// </summary>
    public long MaxBitrate;

    /// <summary>
    /// Minimum bitrate of the stream, in bits per second.
    /// Zero if unknown or unspecified.
    /// </summary>
    public long MinBitrate;

    /// <summary>
    /// Average bitrate of the stream, in bits per second.
    /// Zero if unknown or unspecified.
    /// </summary>
    public long AverageBitrate;

    /// <summary>
    /// The size of the buffer to which the ratecontrol is applied, in bits.
    /// Zero if unknown or unspecified.
    /// </summary>
    public long BufferSize;

    /// <summary>
    /// The delay between the time the packet this structure is associated with
    /// is received and the time when it should be decoded, in periods of a 27MHz clock.
    /// UINT64_MAX when unknown or unspecified.
    /// </summary>
    public ulong VbvDelay;
}