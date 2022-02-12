using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

public interface IRawStream: IStream, IObservable<DecodedPacket>
{
}


public interface IRawVideoStream: IRawStream, IObservable<VideoFrame>
{
    new VideoParameters Parameters { get; }
}
