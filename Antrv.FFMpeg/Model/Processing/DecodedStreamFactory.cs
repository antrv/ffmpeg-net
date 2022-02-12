using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Processing;

internal static class DecodedStreamFactory
{
    internal static DecodedStream CreateDecodedStream(IEncodedStream stream)
    {
        switch (stream.MediaType)
        {
            case AVMediaType.Video:
                return new DecodedVideoStream(stream);

            default:
                throw new NotImplementedException();
        }
    }
}
