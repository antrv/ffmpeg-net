using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputAttachmentStream: InputStream<AttachmentParameters>
{
    internal InputAttachmentStream(Ptr<AVStream> ptr)
        : base(ptr, CreateParameters(ptr))
    {
    }

    private static AttachmentParameters CreateParameters(Ptr<AVStream> ptr) => new();
}
