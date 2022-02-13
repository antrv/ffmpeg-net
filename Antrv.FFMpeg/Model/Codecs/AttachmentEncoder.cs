using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class AttachmentEncoder: Encoder
{
    internal AttachmentEncoder(AttachmentCodec codec, ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
        Codec = codec;
    }

    public override AttachmentCodec Codec { get; }
}
