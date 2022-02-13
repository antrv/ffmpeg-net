using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// Data codec description.
/// </summary>
public sealed class DataCodec: Codec
{
    internal DataCodec(ConstPtr<AVCodecDescriptor> ptr, ConstPtr<AVCodec>[] coders)
        : base(ptr)
    {
        Decoders = GetCoderList(coders, false, c => new DataDecoder(this, c));
        Encoders = GetCoderList(coders, true, c => new DataEncoder(this, c));
    }

    /// <inheritdoc />
    public override IReadOnlyList<DataDecoder> Decoders { get; }

    /// <inheritdoc />
    public override IReadOnlyList<DataEncoder> Encoders { get; }
}
