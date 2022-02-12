using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

public interface IStream
{
    AVMediaType MediaType { get; }
    AVRational TimeBase { get; }
    StreamParameters Parameters { get; }
}
