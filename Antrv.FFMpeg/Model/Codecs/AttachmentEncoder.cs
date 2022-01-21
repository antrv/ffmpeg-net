using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class AttachmentEncoder: Encoder
{
    internal AttachmentEncoder(ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
    }
}
