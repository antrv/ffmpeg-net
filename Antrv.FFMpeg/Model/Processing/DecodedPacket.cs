using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

public readonly struct DecodedPacket: IFrame
{
    internal DecodedPacket(IRawStream stream, Ptr<AVFrame> ptr)
    {
        Stream = stream;
        Ptr = ptr;
    }

    public IRawStream Stream { get; }
    internal Ptr<AVFrame> Ptr { get; }

    Ptr<AVFrame> IFrame.Ptr => Ptr;
    IRawStream IDecodedPacket.Stream => Stream;
    StreamParameters IDecodedPacket.Parameters => Stream.Parameters;
}
