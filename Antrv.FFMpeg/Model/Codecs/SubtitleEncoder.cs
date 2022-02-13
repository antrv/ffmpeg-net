using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class SubtitleEncoder: Encoder
{
    internal SubtitleEncoder(SubtitleCodec codec, ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
        Codec = codec;
    }

    public override SubtitleCodec Codec { get; }
}
