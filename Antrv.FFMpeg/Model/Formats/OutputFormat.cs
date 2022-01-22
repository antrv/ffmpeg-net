using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Codecs;

namespace Antrv.FFMpeg.Model.Formats;

/// <summary>
/// The description of an output container format.
/// </summary>
public class OutputFormat: ContainerFormat
{
    internal OutputFormat(ConstPtr<AVOutputFormat> ptr)
        : base(ptr)
    {
        Ptr = ptr;
        DefaultVideoCodec = GetCodec<VideoCodec>(ptr.Ref.VideoCodec);
        DefaultAudioCodec = GetCodec<AudioCodec>(ptr.Ref.AudioCodec);
        DefaultSubtitleCodec = GetCodec<SubtitleCodec>(ptr.Ref.SubtitleCodec);
        SupportedCodecs = GetSupportedCodecList(ptr);
    }

    public VideoCodec? DefaultVideoCodec { get; }

    public AudioCodec? DefaultAudioCodec { get; }

    public SubtitleCodec? DefaultSubtitleCodec { get; }

    public ImmutableList<CodecSupport> SupportedCodecs { get; }

    internal ConstPtr<AVOutputFormat> Ptr { get; }

    private static TCodec? GetCodec<TCodec>(AVCodecID codecId)
        where TCodec: Codec
    {
        if (codecId == AVCodecID.AV_CODEC_ID_NONE)
            return null;

        return (TCodec)Global.Codecs[codecId];
    }

    private static ImmutableList<CodecSupport> GetSupportedCodecList(ConstPtr<AVOutputFormat> ptr) =>
        Global.Codecs.Select(c =>
        {
            for (AVStandardCompliance compliance = AVStandardCompliance.VeryStrict;
                 compliance >= AVStandardCompliance.Experimental;
                 --compliance)
            {
                if (LibAvFormat.avformat_query_codec(ptr, c.Id, compliance) == 1)
                {
                    return new CodecSupport(c, compliance);
                }
            }

            return new CodecSupport(c, AVStandardCompliance.Experimental - 1);
        }).Where(s => s.StandardCompliance >= AVStandardCompliance.Experimental).ToImmutableList();
}
