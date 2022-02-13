using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// Audio codec description.
/// </summary>
public sealed class AudioCodec: Codec
{
    internal AudioCodec(ConstPtr<AVCodecDescriptor> ptr, ConstPtr<AVCodec>[] coders)
        : base(ptr)
    {
        Decoders = GetCoderList(coders, false, c => new AudioDecoder(this, c));
        Encoders = GetCoderList(coders, true, c => new AudioEncoder(this, c));
    }

    /// <inheritdoc />
    public override IReadOnlyList<AudioDecoder> Decoders { get; }

    /// <inheritdoc />
    public override IReadOnlyList<AudioEncoder> Encoders { get; }
}
