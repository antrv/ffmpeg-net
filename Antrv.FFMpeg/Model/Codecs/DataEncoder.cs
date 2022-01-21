using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class DataEncoder: Encoder
{
    internal DataEncoder(ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
    }
}
