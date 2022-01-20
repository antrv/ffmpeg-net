namespace Antrv.FFMpeg.Interop;

public struct AVPacketSideData
{
    public Ptr<byte> Data;
    public nuint Size;
    public AVPacketSideDataType Type;
}
