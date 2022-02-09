using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputSubtitleStream: InputStream<SubtitleParameters>
{
    internal InputSubtitleStream(Ptr<AVStream> ptr)
        : base(ptr, CreateParameters(ptr))
    {
    }

    private static SubtitleParameters CreateParameters(Ptr<AVStream> ptr)
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
