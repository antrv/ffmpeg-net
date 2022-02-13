using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

internal static class StreamParametersFactory
{
    internal static StreamParameters CreateStreamParameters(in AVStream stream, in AVCodecParameters pars)
    {
        switch (pars.CodecType)
        {
            case AVMediaType.Video:
                return CreateVideoParameters(stream, pars);

            case AVMediaType.Audio:
                return CreateAudioParameters(pars);

            case AVMediaType.Subtitle:
                return CreateSubtitleParameters(pars);

            case AVMediaType.Attachment:
                return CreateAttachmentParameters(pars);

            case AVMediaType.Data:
                return CreateDataParameters(pars);

            default:
                return CreateUnknownStreamParameters(pars);
        }
    }

    private static VideoParameters CreateVideoParameters(in AVStream stream, in AVCodecParameters pars) =>
        new()
        {
            MediaType = AVMediaType.Video,
            BitRate = pars.BitRate,
            Profile = pars.Profile,
            Level = pars.Level,
            CodecTag = pars.CodecTag,
            Width = pars.Width,
            Height = pars.Height,
            FrameRate = stream.AvgFrameRate,
            SampleAspectRatio = pars.SampleAspectRatio,
            FieldOrder = pars.FieldOrder,
            ChromaLocation = pars.ChromaLocation,
            PixelFormat = (AVPixelFormat)pars.Format,
            ColorPrimaries = pars.ColorPrimaries,
            ColorRange = pars.ColorRange,
            ColorSpace = pars.ColorSpace,
            ColorTransferCharacteristic = pars.ColorTrc,
            VideoDelay = pars.VideoDelay
        };

    private static AudioParameters CreateAudioParameters(in AVCodecParameters pars) =>
        new()
        {
            MediaType = AVMediaType.Audio,
            SampleFormat = (AVSampleFormat)pars.Format,
            SampleRate = pars.SampleRate,
            CodecTag = pars.CodecTag,
            BitRate = pars.BitRate,
            ChannelLayout = pars.ChannelLayout,
            Channels = pars.Channels,
            BitsPerSample = pars.BitsPerCodedSample,
            BitsPerRawSample = pars.BitsPerRawSample,
            BlockAlign = pars.BlockAlign,
            FrameSize = pars.FrameSize,
            InitialPadding = pars.InitialPadding,
            Level = pars.Level,
            Profile = pars.Profile,
            SeekPreroll = pars.SeekPreroll,
            TrailingPadding = pars.TrailingPadding,
        };

    private static SubtitleParameters CreateSubtitleParameters(in AVCodecParameters pars) =>
        new()
        {
            MediaType = AVMediaType.Audio,
            CodecTag = pars.CodecTag,
            BitRate = pars.BitRate,
            Level = pars.Level,
            Profile = pars.Profile,
        };

    private static AttachmentParameters CreateAttachmentParameters(in AVCodecParameters pars) =>
        new()
        {
            MediaType = AVMediaType.Audio,
            CodecTag = pars.CodecTag,
            BitRate = pars.BitRate,
            Level = pars.Level,
            Profile = pars.Profile,
        };

    private static DataParameters CreateDataParameters(in AVCodecParameters pars) =>
        new()
        {
            MediaType = AVMediaType.Audio,
            CodecTag = pars.CodecTag,
            BitRate = pars.BitRate,
            Level = pars.Level,
            Profile = pars.Profile,
        };

    private static UnknownStreamParameters CreateUnknownStreamParameters(in AVCodecParameters pars) =>
        new()
        {
            MediaType = AVMediaType.Audio,
            CodecTag = pars.CodecTag,
            BitRate = pars.BitRate,
            Level = pars.Level,
            Profile = pars.Profile,
        };

    private sealed class UnknownStreamParameters: StreamParameters
    {
    }
}
