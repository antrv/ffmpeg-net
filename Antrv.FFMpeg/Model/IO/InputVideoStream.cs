using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputVideoStream: InputStream<VideoParameters>
{
    internal InputVideoStream(Ptr<AVStream> ptr)
        : base(ptr)
    {
    }
}
