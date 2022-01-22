using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputSubtitleStream: InputStream<SubtitleParameters>
{
    internal InputSubtitleStream(Ptr<AVStream> ptr)
        : base(ptr, CreateParameters(ptr))
    {
    }

    private static SubtitleParameters CreateParameters(Ptr<AVStream> ptr) => new();
}
