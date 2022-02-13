using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class AudioEncoder: Encoder
{
    internal AudioEncoder(AudioCodec codec, ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
        Codec = codec;
        ChannelLayouts = ptr.Ref.ChannelLayouts.CreateList(x => x.Ref != AVChannelLayout.None);
        SampleFormats = ptr.Ref.SampleFormats.CreateList(x => x.Ref != AVSampleFormat.AV_SAMPLE_FMT_NONE);
        SampleRates = ptr.Ref.SupportedSamplerates.CreateList(x => x.Ref != 0);
    }

    public override AudioCodec Codec { get; }

    /// <summary>
    /// Supported channel layouts.
    /// </summary>
    public IReadOnlyList<AVChannelLayout> ChannelLayouts { get; }

    /// <summary>
    /// Supported sample formats.
    /// </summary>
    public IReadOnlyList<AVSampleFormat> SampleFormats { get; }

    /// <summary>
    /// Supported samplerates.
    /// </summary>
    public IReadOnlyList<int> SampleRates { get; }
}
