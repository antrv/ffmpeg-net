namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVHWAccelCodecCapabilities
{
    None = 0,

    /// <summary>
    /// HWAccel is experimental and is thus avoided in favor of non experimental codecs
    /// </summary>
    AV_HWACCEL_CODEC_CAP_EXPERIMENTAL = 0x0200,
}
