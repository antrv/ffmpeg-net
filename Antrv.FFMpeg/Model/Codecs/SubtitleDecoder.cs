using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class SubtitleDecoder: Decoder
{
    internal SubtitleDecoder(SubtitleCodec codec, ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
        Codec = codec;
    }

    public override SubtitleCodec Codec { get; }
}
