using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

public interface IDecodedPacket
{
    public IRawStream Stream { get; }
    public StreamParameters Parameters { get; }
}
