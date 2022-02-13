using System.Collections.Immutable;
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
        ShortName = ptr.Ref.Name.ToString();
        Name = ptr.Ref.LongName.ToString();
        IsEncoder = isEncoder;
        Profiles = ptr.Ref.Profiles.CreateProfileList();
    }

    public abstract Codec Codec { get; }

    public AVCodecID CodecId { get; }

    public AVMediaType MediaType { get; }

    public string ShortName { get; }

    public string Name { get; }

    public bool IsEncoder { get; }

    public override string ToString() => ShortName + " - " + Name;

    public ImmutableList<Profile> Profiles { get; }

    internal ConstPtr<AVCodec> CodecPtr { get; }
}
