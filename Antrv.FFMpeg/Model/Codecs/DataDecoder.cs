using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class DataDecoder: Decoder
{
    internal DataDecoder(ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
    }
}
