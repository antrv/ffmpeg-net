using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// Audio codec description.
/// </summary>
public sealed class AudioCodec: Codec
{
    internal AudioCodec(ConstPtr<AVCodecDescriptor> ptr, IReadOnlyList<AudioDecoder> decoders,
        IReadOnlyList<AudioEncoder> encoders)
        : base(ptr)
    {
        Decoders = decoders;
        Encoders = encoders;
    }

    /// <inheritdoc />
    public override IReadOnlyList<AudioDecoder> Decoders { get; }

    /// <inheritdoc />
    public override IReadOnlyList<AudioEncoder> Encoders { get; }
}
