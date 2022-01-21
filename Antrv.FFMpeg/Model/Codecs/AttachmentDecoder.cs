using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class AttachmentDecoder: Decoder
{
    internal AttachmentDecoder(ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
    }
}
