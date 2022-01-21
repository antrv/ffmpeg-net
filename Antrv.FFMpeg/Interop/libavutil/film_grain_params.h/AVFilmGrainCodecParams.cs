namespace Antrv.FFMpeg.Interop;

[StructLayout(LayoutKind.Explicit)]
public struct AVFilmGrainCodecParams
{
    [FieldOffset(0)]
    public AVFilmGrainAomParams AomParams;

    [FieldOffset(0)]
    public AVFilmGrainH274Params H274Params;
}
