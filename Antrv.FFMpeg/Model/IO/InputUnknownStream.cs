using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

internal sealed class InputUnknownStream: InputStream
{
    internal InputUnknownStream(Ptr<AVStream> ptr)
        : base(ptr)
    {
        Parameters = CreateParameters(ptr);
    }

    public override StreamParameters Parameters { get; }

    private static StreamParameters CreateParameters(Ptr<AVStream> ptr)
    {
        ref AVCodecParameters parRef = ref ptr.Ref.CodecParameters.Ref;

        return new UnknownStreamParameters
        {
            MediaType = AVMediaType.Unknown,
            BitRate = parRef.BitRate,
            CodecTag = parRef.CodecTag,
            Profile = parRef.Profile,
            Level = parRef.Level
        };
    }

    private sealed class UnknownStreamParameters: StreamParameters
    {
    }
}
