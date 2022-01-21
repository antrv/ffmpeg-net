using System.Collections.Immutable;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// The descriptor for the unknown codec.
/// </summary>
public sealed class UnknownCodec: Codec
{
    internal UnknownCodec()
    {
        Decoders = ImmutableList<Decoder>.Empty;
        Encoders = ImmutableList<Encoder>.Empty;
    }

    /// <inheritdoc />
    public override IReadOnlyList<Decoder> Decoders { get; }

    /// <inheritdoc />
    public override IReadOnlyList<Encoder> Encoders { get; }
}
