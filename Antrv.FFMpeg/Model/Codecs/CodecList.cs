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
        (Codecs, VideoCodecs, AudioCodecs, SubtitleCodecs, AttachmentCodecs, DataCodecs) = BuildCodecLists();
        _dictionary = Codecs.ToImmutableDictionary(c => c.CodecId);
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

    private static (ImmutableList<Codec>, ImmutableList<VideoCodec>, ImmutableList<AudioCodec>,
        ImmutableList<SubtitleCodec>, ImmutableList<AttachmentCodec>, ImmutableList<DataCodec>) BuildCodecLists()
    {
        List<VideoDecoder> videoDecoders = new();
        List<VideoEncoder> videoEncoders = new();
        List<AudioDecoder> audioDecoders = new();
        List<AudioEncoder> audioEncoders = new();
        List<SubtitleDecoder> subtitleDecoders = new();
        List<SubtitleEncoder> subtitleEncoders = new();
        List<AttachmentDecoder> attachmentDecoders = new();
        List<AttachmentEncoder> attachmentEncoders = new();
        List<DataDecoder> dataDecoders = new();
        List<DataEncoder> dataEncoders = new();

        foreach (ConstPtr<AVCodec> ptr in Utils.EnumerateCodecs())
        {
            bool isEncoder = LibAvCodec.av_codec_is_encoder(ptr) != 0;
            switch (ptr.Ref.Type)
            {
                case AVMediaType.AVMEDIA_TYPE_VIDEO:
                    if (isEncoder)
                        videoEncoders.Add(new VideoEncoder(ptr));
                    else
                        videoDecoders.Add(new VideoDecoder(ptr));
                    break;

                case AVMediaType.AVMEDIA_TYPE_AUDIO:
                    if (isEncoder)
                        audioEncoders.Add(new AudioEncoder(ptr));
                    else
                        audioDecoders.Add(new AudioDecoder(ptr));
                    break;

                case AVMediaType.AVMEDIA_TYPE_SUBTITLE:
                    if (isEncoder)
                        subtitleEncoders.Add(new SubtitleEncoder(ptr));
                    else
                        subtitleDecoders.Add(new SubtitleDecoder(ptr));
                    break;

                case AVMediaType.AVMEDIA_TYPE_ATTACHMENT:
                    if (isEncoder)
                        attachmentEncoders.Add(new AttachmentEncoder(ptr));
                    else
                        attachmentDecoders.Add(new AttachmentDecoder(ptr));
                    break;

                case AVMediaType.AVMEDIA_TYPE_DATA:
                    if (isEncoder)
                        dataEncoders.Add(new DataEncoder(ptr));
                    else
                        dataDecoders.Add(new DataDecoder(ptr));
                    break;
            }
        }

        ImmutableList<Codec>.Builder codecs = ImmutableList.CreateBuilder<Codec>();
        ImmutableList<VideoCodec>.Builder videoCodecs = ImmutableList.CreateBuilder<VideoCodec>();
        ImmutableList<AudioCodec>.Builder audioCodecs = ImmutableList.CreateBuilder<AudioCodec>();
        ImmutableList<SubtitleCodec>.Builder subtitleCodecs = ImmutableList.CreateBuilder<SubtitleCodec>();
        ImmutableList<AttachmentCodec>.Builder attachmentCodecs = ImmutableList.CreateBuilder<AttachmentCodec>();
        ImmutableList<DataCodec>.Builder dataCodecs = ImmutableList.CreateBuilder<DataCodec>();
        foreach (ConstPtr<AVCodecDescriptor> ptr in Utils.EnumerateCodecDescriptors())
        {
            switch (ptr.Ref.Type)
            {
                case AVMediaType.AVMEDIA_TYPE_VIDEO:
                    codecs.Add(new VideoCodec(ptr,
                        videoDecoders.Where(x => x.CodecId == ptr.Ref.Id).ToImmutableList(),
                        videoEncoders.Where(x => x.CodecId == ptr.Ref.Id).ToImmutableList()));
                    break;

                case AVMediaType.AVMEDIA_TYPE_AUDIO:
                    codecs.Add(new AudioCodec(ptr,
                        audioDecoders.Where(x => x.CodecId == ptr.Ref.Id).ToImmutableList(),
                        audioEncoders.Where(x => x.CodecId == ptr.Ref.Id).ToImmutableList()));
                    break;

                case AVMediaType.AVMEDIA_TYPE_SUBTITLE:
                    codecs.Add(new SubtitleCodec(ptr,
                        subtitleDecoders.Where(x => x.CodecId == ptr.Ref.Id).ToImmutableList(),
                        subtitleEncoders.Where(x => x.CodecId == ptr.Ref.Id).ToImmutableList()));
                    break;

                case AVMediaType.AVMEDIA_TYPE_ATTACHMENT:
                    codecs.Add(new AttachmentCodec(ptr,
                        attachmentDecoders.Where(x => x.CodecId == ptr.Ref.Id).ToImmutableList(),
                        attachmentEncoders.Where(x => x.CodecId == ptr.Ref.Id).ToImmutableList()));
                    break;

                case AVMediaType.AVMEDIA_TYPE_DATA:
                    codecs.Add(new DataCodec(ptr, dataDecoders.Where(x => x.CodecId == ptr.Ref.Id).ToImmutableList(),
                        dataEncoders.Where(x => x.CodecId == ptr.Ref.Id).ToImmutableList()));
                    break;
            }
        }

        return (codecs.ToImmutable(), videoCodecs.ToImmutable(), audioCodecs.ToImmutable(),
            subtitleCodecs.ToImmutable(), attachmentCodecs.ToImmutable(), dataCodecs.ToImmutable());
    }
}
