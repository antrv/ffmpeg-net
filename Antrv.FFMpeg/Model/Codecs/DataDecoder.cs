using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class DataDecoder: Decoder
{
    internal DataDecoder(DataCodec codec, ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
        Codec = codec;
    }

    public override DataCodec Codec { get; }
}
