using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// The description of a codec.
/// </summary>
public abstract class Codec
{
    private protected Codec(ConstPtr<AVCodecDescriptor> ptr)
    {
        Id = ptr.Ref.Id;
        MediaType = ptr.Ref.Type;
        ShortName = ptr.Ref.Name.ToString();
        Name = ptr.Ref.LongName.ToString();
        MimeTypes = ptr.Ref.MimeTypes.CreateStringList();
        Properties = ptr.Ref.Properties;
        Profiles = ptr.Ref.Profiles.CreateProfileList();
    }

    /// <summary>
    /// For unknown codec
    /// </summary>
    private protected Codec()
    {
        Id = AVCodecID.AV_CODEC_ID_NONE;
        MediaType = AVMediaType.Unknown;
        ShortName = "unknown";
        Name = "Unknown codec";
        MimeTypes = ImmutableList<string>.Empty;
        Properties = AVCodecProperties.None;
        Profiles = ImmutableList<Profile>.Empty;
    }

    public AVCodecID Id { get; }
    public AVMediaType MediaType { get; }
    public string ShortName { get; }
    public string Name { get; }
    public ImmutableList<string> MimeTypes { get; }
    public AVCodecProperties Properties { get; }
    public ImmutableList<Profile> Profiles { get; }

    /// <summary>
    /// The list of decoders for the codec.
    /// </summary>
    public abstract IReadOnlyList<Decoder> Decoders { get; }

    /// <summary>
    /// The list of encoders for the codec.
    /// </summary>
    public abstract IReadOnlyList<Encoder> Encoders { get; }

    public override string ToString() => $"{MediaType} - {ShortName} - {Name}";

    private protected static ImmutableList<T> GetCoderList<T>(ConstPtr<AVCodec>[] coders, bool encoders,
        Func<ConstPtr<AVCodec>, T> func) => coders.Where(c => (LibAvCodec.av_codec_is_encoder(c) != 0) == encoders)
        .Select(func).ToImmutableList();
}
