using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class AudioParameters: CodecParameters
{
    public AVSampleFormat SampleFormat { get; init; }
    public int SampleRate { get; init; }
    public AVChannelLayout ChannelLayout { get; init; }
    public int Channels { get; init; }
    public int BitsPerSample { get; init; }

    // TODO: are these properties below needed here?
    public int BitsPerRawSample { get; init; }
    public int BlockAlign { get; init; }
    public int FrameSize { get; init; }
    public int InitialPadding { get; init; }
    public int SeekPreroll { get; init; }
    public int TrailingPadding { get; init; }
}
