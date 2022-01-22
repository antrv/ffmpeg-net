using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

internal sealed class InputUnknownStream: InputStream
{
    internal InputUnknownStream(Ptr<AVStream> ptr)
        : base(ptr)
    {
    }
}
