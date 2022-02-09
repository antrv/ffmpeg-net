using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputAudioStream: InputStream<AudioParameters>
{
    internal InputAudioStream(Ptr<AVStream> ptr)
        : base(ptr, CreateParameters(ptr))
    {
    }

    private static AudioParameters CreateParameters(Ptr<AVStream> ptr)
    {
        ref AVCodecParameters parRef = ref ptr.Ref.CodecParameters.Ref;

        return new()
        {
            MediaType = AVMediaType.Audio,
            SampleFormat = (AVSampleFormat)parRef.Format,
            SampleRate = parRef.SampleRate,
            CodecTag = parRef.CodecTag,
            BitRate = parRef.BitRate,
            ChannelLayout = parRef.ChannelLayout,
            Channels = parRef.Channels,
            BitsPerSample = parRef.BitsPerCodedSample,
            BitsPerRawSample = parRef.BitsPerRawSample,
            BlockAlign = parRef.BlockAlign,
            FrameSize = parRef.FrameSize,
            InitialPadding = parRef.InitialPadding,
            Level = parRef.Level,
            Profile = parRef.Profile,
            SeekPreroll = parRef.SeekPreroll,
            TrailingPadding = parRef.TrailingPadding,
        };
    }
}
