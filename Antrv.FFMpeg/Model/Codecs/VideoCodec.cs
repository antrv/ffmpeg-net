using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// Video codec description
/// </summary>
public sealed class VideoCodec: Codec
{
    internal VideoCodec(ConstPtr<AVCodecDescriptor> ptr, IReadOnlyList<VideoDecoder> decoders,
        IReadOnlyList<VideoEncoder> encoders)
        : base(ptr)
    {
        Decoders = decoders;
        Encoders = encoders;
    }

    /// <inheritdoc />
    public override IReadOnlyList<Decoder> Decoders { get; }

    /// <inheritdoc />
    public override IReadOnlyList<Encoder> Encoders { get; }
}
