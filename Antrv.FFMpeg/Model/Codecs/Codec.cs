﻿using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// The description of a codec.
/// </summary>
public abstract class Codec
{
    private protected Codec(ConstPtr<AVCodecDescriptor> ptr)
    {
        CodecId = ptr.Ref.Id;
        MediaType = ptr.Ref.Type;
        Name = ptr.Ref.Name.ToString();
        LongName = ptr.Ref.LongName.ToString();
        MimeTypes = ptr.Ref.MimeTypes.CreateStringList();
        Properties = ptr.Ref.Properties;
        Profiles = ptr.Ref.Profiles.CreateProfileList();
    }

    /// <summary>
    /// For unknown codec
    /// </summary>
    private protected Codec()
    {
        CodecId = AVCodecID.AV_CODEC_ID_NONE;
        MediaType = AVMediaType.AVMEDIA_TYPE_UNKNOWN;
        Name = "unknown";
        LongName = "Unknown codec";
        MimeTypes = ImmutableList<string>.Empty;
        Properties = AVCodecProperties.None;
        Profiles = ImmutableList<Profile>.Empty;
    }

    public AVCodecID CodecId { get; }
    public AVMediaType MediaType { get; }
    public string Name { get; }
    public string LongName { get; }
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

    public override string ToString() => $"{MediaType} - {Name} - {LongName}";
}
