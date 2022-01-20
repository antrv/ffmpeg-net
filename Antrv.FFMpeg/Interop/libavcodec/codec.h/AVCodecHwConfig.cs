namespace Antrv.FFMpeg.Interop;

public struct AVCodecHwConfig
{
    /// <summary>
    /// For decoders, a hardware pixel format which that decoder may be
    /// able to decode to if suitable hardware is available.
    ///
    /// For encoders, a pixel format which the encoder may be able to
    /// accept.  If set to AV_PIX_FMT_NONE, this applies to all pixel
    /// formats supported by the codec.
    /// </summary>
    public AVPixelFormat PixelFormat;

    /// <summary>
    /// Bit set of AV_CODEC_HW_CONFIG_METHOD_* flags, describing the possible
    /// setup methods which can be used with this configuration.
    /// </summary>
    public AVCodecHwConfigMethods Methods;

    /// <summary>
    /// The device type associated with the configuration.
    ///
    /// Must be set for AV_CODEC_HW_CONFIG_METHOD_HW_DEVICE_CTX and
    /// AV_CODEC_HW_CONFIG_METHOD_HW_FRAMES_CTX, otherwise unused.
    /// </summary>
    public AVHWDeviceType DeviceType;
}
