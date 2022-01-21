using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public abstract class Encoder: Coder
{
    private protected Encoder(ConstPtr<AVCodec> ptr)
        : base(ptr, true)
    {
    }
}
