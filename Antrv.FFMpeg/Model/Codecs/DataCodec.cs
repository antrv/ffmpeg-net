using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// Data codec description.
/// </summary>
public sealed class DataCodec: Codec
{
    internal DataCodec(ConstPtr<AVCodecDescriptor> ptr, IReadOnlyList<DataDecoder> decoders,
        IReadOnlyList<DataEncoder> encoders)
        : base(ptr)
    {
        Decoders = decoders;
        Encoders = encoders;
    }

    /// <inheritdoc />
    public override IReadOnlyList<DataDecoder> Decoders { get; }

    /// <inheritdoc />
    public override IReadOnlyList<DataEncoder> Encoders { get; }
}
