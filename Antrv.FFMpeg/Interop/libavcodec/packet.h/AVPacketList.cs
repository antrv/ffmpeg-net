namespace Antrv.FFMpeg.Interop;

[Obsolete]
public struct AVPacketList
{
    public AVPacket Pkt;
    public Ptr<AVPacketList> Next;
}
