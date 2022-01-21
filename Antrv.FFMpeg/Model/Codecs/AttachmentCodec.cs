using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// Attachment codec description.
/// </summary>
public sealed class AttachmentCodec: Codec
{
    internal AttachmentCodec(ConstPtr<AVCodecDescriptor> ptr, IReadOnlyList<AttachmentDecoder> decoders,
        IReadOnlyList<AttachmentEncoder> encoders)
        : base(ptr)
    {
        Decoders = decoders;
        Encoders = encoders;
    }

    /// <inheritdoc />
    public override IReadOnlyList<AttachmentDecoder> Decoders { get; }

    /// <inheritdoc />
    public override IReadOnlyList<AttachmentEncoder> Encoders { get; }
}
