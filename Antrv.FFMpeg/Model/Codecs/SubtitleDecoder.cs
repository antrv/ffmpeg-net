using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class SubtitleDecoder: Decoder
{
    internal SubtitleDecoder(ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
    }
}
