using Antrv.FFMpeg.Model.Codecs;

namespace Antrv.FFMpeg.Model.Processing;

public interface IEncodedStream: IStream, IObservable<Packet>
{
    Codec Codec { get; }
    CodecParameters CodecParameters { get; }
}