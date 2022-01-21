using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public abstract class Decoder: Coder
{
    private protected Decoder(ConstPtr<AVCodec> ptr)
        : base(ptr, false)
    {
    }
}
