using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// Attachment codec description.
/// </summary>
public sealed class AttachmentCodec: Codec
{
    internal AttachmentCodec(ConstPtr<AVCodecDescriptor> ptr, ConstPtr<AVCodec>[] coders)
        : base(ptr)
    {
        Decoders = GetCoderList(coders, false, c => new AttachmentDecoder(this, c));
        Encoders = GetCoderList(coders, true, c => new AttachmentEncoder(this, c));
    }

    /// <inheritdoc />
    public override IReadOnlyList<AttachmentDecoder> Decoders { get; }

    /// <inheritdoc />
    public override IReadOnlyList<AttachmentEncoder> Encoders { get; }
}
