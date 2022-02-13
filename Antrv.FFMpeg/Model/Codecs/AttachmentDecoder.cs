using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class AttachmentDecoder: Decoder
{
    internal AttachmentDecoder(AttachmentCodec codec, ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
        Codec = codec;
    }

    public override AttachmentCodec Codec { get; }
}
