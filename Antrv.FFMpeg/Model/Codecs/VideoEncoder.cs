using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Codecs;

public sealed class VideoEncoder: Encoder
{
    internal VideoEncoder(VideoCodec codec, ConstPtr<AVCodec> ptr)
        : base(ptr)
    {
        Codec = codec;
        FrameRates = ptr.Ref.SupportedFramerates.CreateList(x => x.Ref.Numerator != 0 || x.Ref.Denominator != 0);
        PixelFormats = ptr.Ref.PixelFormats.CreateList(x => x.Ref != AVPixelFormat.AV_PIX_FMT_NONE);
    }

    public override VideoCodec Codec { get; }

    /// <summary>
    /// The list of supported framerates.
    /// </summary>
    public IReadOnlyList<AVRational> FrameRates { get; }

    /// <summary>
    /// The list of supported pixel formats.
    /// </summary>
    public IReadOnlyList<AVPixelFormat> PixelFormats { get; }
}
