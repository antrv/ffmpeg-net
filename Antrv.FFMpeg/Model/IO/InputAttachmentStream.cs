using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputAttachmentStream: InputStream<AttachmentParameters>
{
    internal InputAttachmentStream(Ptr<AVStream> ptr)
        : base(ptr, CreateParameters(ptr))
    {
    }

    private static AttachmentParameters CreateParameters(Ptr<AVStream> ptr)
    {
        ref AVCodecParameters parRef = ref ptr.Ref.CodecParameters.Ref;

        return new()
        {
            MediaType = AVMediaType.Subtitle,
            BitRate = parRef.BitRate,
            CodecTag = parRef.CodecTag,
            Profile = parRef.Profile,
            Level = parRef.Level
        };
    }
}
