namespace Antrv.FFMpeg.Interop;

[Flags]
public enum VorbisFlags
{
    None = 0,
    VORBIS_FLAG_HEADER = 0x00000001,
    VORBIS_FLAG_COMMENT = 0x00000002,
    VORBIS_FLAG_SETUP = 0x00000004,
}
