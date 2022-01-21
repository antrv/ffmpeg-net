using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Codecs;

namespace Antrv.FFMpeg.Model.Formats;

public readonly struct CodecSupport
{
    internal CodecSupport(Codec codec, AVStandardCompliance standardCompliance)
    {
        Codec = codec;
        StandardCompliance = standardCompliance;
    }

    public Codec Codec { get; }

    public AVStandardCompliance StandardCompliance { get; }
}
