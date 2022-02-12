using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Processing;

public sealed class CodecParameters
{
    internal CodecParameters(Ptr<AVCodecParameters> ptr)
    {
        Ptr = ptr;
    }

    internal Ptr<AVCodecParameters> Ptr { get; }
}
