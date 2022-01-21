using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// The base class for decoders and encoders.
/// </summary>
public abstract class Coder
{
    private protected Coder(ConstPtr<AVCodec> ptr, bool isEncoder)
    {
        CodecPtr = ptr;
        CodecId = ptr.Ref.Id;
        MediaType = ptr.Ref.Type;
        Name = ptr.Ref.Name.ToString();
        LongName = ptr.Ref.LongName.ToString();
        IsEncoder = isEncoder;
    }

    public AVCodecID CodecId { get; }

    public AVMediaType MediaType { get; }

    public string Name { get; }

    public string LongName { get; }

    public bool IsEncoder { get; }

    public override string ToString() => Name + " - " + LongName;

    internal ConstPtr<AVCodec> CodecPtr { get; }
}
