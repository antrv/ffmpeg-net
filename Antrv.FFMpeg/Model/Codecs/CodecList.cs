using System.Collections;
using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

/// <summary>
/// Codec list.
/// </summary>
public sealed class CodecList: IReadOnlyList<Codec>
{
    private readonly ImmutableDictionary<AVCodecID, Codec> _dictionary;

    internal CodecList()
    {
        Codecs = GetCodecs();
        VideoCodecs = Codecs.OfType<VideoCodec>().ToImmutableList();
        AudioCodecs = Codecs.OfType<AudioCodec>().ToImmutableList();
        SubtitleCodecs = Codecs.OfType<SubtitleCodec>().ToImmutableList();
        AttachmentCodecs = Codecs.OfType<AttachmentCodec>().ToImmutableList();
        DataCodecs = Codecs.OfType<DataCodec>().ToImmutableList();

        _dictionary = Codecs.ToImmutableDictionary(c => c.Id);
        UnknownCodec = new UnknownCodec();
    }

    public IEnumerator<Codec> GetEnumerator() => Codecs.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Codecs.GetEnumerator();

    public int Count => Codecs.Count;

    public Codec this[int index] => Codecs[index];
    public Codec this[AVCodecID key] => _dictionary[key];

    public bool Contains(AVCodecID key) => _dictionary.ContainsKey(key);

    public bool TryGetCodec(AVCodecID key, out Codec? codec) => _dictionary.TryGetValue(key, out codec);

    /// <summary>
    /// List of all codecs
    /// </summary>
    public ImmutableList<Codec> Codecs { get; }

    /// <summary>
    /// List of video codecs
    /// </summary>
    public ImmutableList<VideoCodec> VideoCodecs { get; }

    /// <summary>
    /// List of audio codecs
    /// </summary>
    public ImmutableList<AudioCodec> AudioCodecs { get; }

    /// <summary>
    /// List of subtitle codecs
    /// </summary>
    public ImmutableList<SubtitleCodec> SubtitleCodecs { get; }

    /// <summary>
    /// List of attachment codecs
    /// </summary>
    public ImmutableList<AttachmentCodec> AttachmentCodecs { get; }

    /// <summary>
    /// List of data codecs
    /// </summary>
    public ImmutableList<DataCodec> DataCodecs { get; }

    /// <summary>
    /// Unknown codec
    /// </summary>
    public UnknownCodec UnknownCodec { get; }

    private static ImmutableList<Codec> GetCodecs()
    {
        Dictionary<AVCodecID, ConstPtr<AVCodec>[]> coders = Utils.EnumerateCodecs().GroupBy(p => p.Ref.Id)
            .ToDictionary(g => g.Key, g => g.ToArray());

        return Utils.EnumerateCodecDescriptors().Select(p => CreateCodec(p, coders)).ToImmutableList();
    }

    private static Codec CreateCodec(ConstPtr<AVCodecDescriptor> ptr,
        Dictionary<AVCodecID, ConstPtr<AVCodec>[]> coders)
    {
        if (!coders.TryGetValue(ptr.Ref.Id, out ConstPtr<AVCodec>[]? coderArray))
            coderArray = Array.Empty<ConstPtr<AVCodec>>();

        return ptr.Ref.Type switch
        {
            AVMediaType.Video => new VideoCodec(ptr, coderArray),
            AVMediaType.Audio => new AudioCodec(ptr, coderArray),
            AVMediaType.Subtitle => new SubtitleCodec(ptr, coderArray),
            AVMediaType.Attachment => new AttachmentCodec(ptr, coderArray),
            AVMediaType.Data => new DataCodec(ptr, coderArray),
            _ => throw new InvalidOperationException("Invalid codec type")
        };
    }
}
