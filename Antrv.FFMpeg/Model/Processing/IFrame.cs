using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Processing;

internal interface IFrame: IDecodedPacket
{
    Ptr<AVFrame> Ptr { get; }
}

