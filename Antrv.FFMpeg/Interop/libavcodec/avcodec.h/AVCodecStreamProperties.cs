namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVCodecStreamProperties
{
    None = 0,
    FF_CODEC_PROPERTY_LOSSLESS = 0x00000001,
    FF_CODEC_PROPERTY_CLOSED_CAPTIONS = 0x00000002,
    FF_CODEC_PROPERTY_FILM_GRAIN = 0x00000004,
}
