using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

internal sealed class DecodedVideoStream: DecodedStream<VideoParameters, VideoFrame>, IRawVideoStream
{
    internal DecodedVideoStream(IEncodedStream stream)
        : base(stream)
    {
    }

    private protected override VideoFrame CreateFrame(Ptr<AVFrame> ptr) => new(this, ptr);
}
