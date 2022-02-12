using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Guards;

internal sealed class PacketGuard: ResourceGuard<AVPacket, PacketGuard>
{
    public PacketGuard()
        : base(LibAvCodec.av_packet_alloc())
    {
    }

    public PacketGuard(Ptr<AVPacket> ptr)
        : base(ptr)
    {
    }

    public void UnRef() => LibAvCodec.av_packet_unref(Ptr);

    protected override void Release(Ptr<AVPacket> ptr) => LibAvCodec.av_packet_free(ref ptr);
}
