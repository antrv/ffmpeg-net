using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class SubtitleEncoder: Encoder
{
    internal SubtitleEncoder(ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
    }
}
