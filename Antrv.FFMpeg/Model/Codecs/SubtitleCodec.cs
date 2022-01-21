using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// Subtitle codec description.
/// </summary>
public sealed class SubtitleCodec: Codec
{
    internal SubtitleCodec(ConstPtr<AVCodecDescriptor> ptr, IReadOnlyList<SubtitleDecoder> decoders,
        IReadOnlyList<SubtitleEncoder> encoders)
        : base(ptr)
    {
        Decoders = decoders;
        Encoders = encoders;
    }

    /// <inheritdoc />
    public override IReadOnlyList<SubtitleDecoder> Decoders { get; }

    /// <inheritdoc />
    public override IReadOnlyList<SubtitleEncoder> Encoders { get; }
}
