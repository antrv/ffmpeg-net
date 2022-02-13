using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// Subtitle codec description.
/// </summary>
public sealed class SubtitleCodec: Codec
{
    internal SubtitleCodec(ConstPtr<AVCodecDescriptor> ptr, ConstPtr<AVCodec>[] coders)
        : base(ptr)
    {
        Decoders = GetCoderList(coders, false, c => new SubtitleDecoder(this, c));
        Encoders = GetCoderList(coders, true, c => new SubtitleEncoder(this, c));
    }

    /// <inheritdoc />
    public override IReadOnlyList<SubtitleDecoder> Decoders { get; }

    /// <inheritdoc />
    public override IReadOnlyList<SubtitleEncoder> Encoders { get; }
}
