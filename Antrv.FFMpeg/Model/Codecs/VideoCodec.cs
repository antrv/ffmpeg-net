using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// Video codec description
/// </summary>
public sealed class VideoCodec: Codec
{
    internal VideoCodec(ConstPtr<AVCodecDescriptor> ptr, ConstPtr<AVCodec>[] coders)
        : base(ptr)
    {
        Decoders = GetCoderList(coders, false, c => new VideoDecoder(this, c));
        Encoders = GetCoderList(coders, true, c => new VideoEncoder(this, c));
    }

    /// <inheritdoc />
    public override IReadOnlyList<Decoder> Decoders { get; }

    /// <inheritdoc />
    public override IReadOnlyList<Encoder> Encoders { get; }
}
