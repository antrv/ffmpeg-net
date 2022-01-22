using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputDataStream: InputStream<DataParameters>
{
    internal InputDataStream(Ptr<AVStream> ptr)
        : base(ptr, CreateParameters(ptr))
    {
    }

    private static DataParameters CreateParameters(Ptr<AVStream> ptr) => new();
}
