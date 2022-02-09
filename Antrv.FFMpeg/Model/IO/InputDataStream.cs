using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputDataStream: InputStream<DataParameters>
{
    internal InputDataStream(Ptr<AVStream> ptr)
        : base(ptr, CreateParameters(ptr))
    {
    }

    private static DataParameters CreateParameters(Ptr<AVStream> ptr)
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
