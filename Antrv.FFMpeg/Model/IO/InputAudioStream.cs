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
        return new AudioParameters();
    }
}
