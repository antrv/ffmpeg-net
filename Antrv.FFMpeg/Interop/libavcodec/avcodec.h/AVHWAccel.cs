namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Nothing in this structure should be accessed by the user. At some
/// point in future it will not be externally visible at all.
/// </summary>
public struct AVHWAccel
{
    /// <summary>
    /// Name of the hardware accelerated codec.
    /// The name is globally unique among encoders and among decoders (but an
    /// encoder and a decoder can share the same name).
    /// </summary>
    public Utf8StringPtr Name;

    /// <summary>
    /// Type of codec implemented by the hardware accelerator.
    /// </summary>
    public AVMediaType Type;

    /// <summary>
    /// Codec implemented by the hardware accelerator.
    /// </summary>
    public AVCodecID Id;

    /// <summary>
    /// Supported pixel format.
    /// Only hardware accelerated formats are supported here.
    /// </summary>
    public AVPixelFormat PixFmt;

    /// <summary>
    /// Hardware accelerated codec capabilities.
    /// </summary>
    public AVHWAccelCodecCapabilities Capabilities;

    // No fields below this line are part of the public API. They
    // may not be used outside of libavcodec and can be changed and
    // removed at will.
    // New public fields should be added right above.
}
