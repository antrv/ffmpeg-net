using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public abstract class CodecParameters
{
    public AVMediaType MediaType { get; init; }
    public int Level { get; init; }
    public int Profile { get; init; }
    public uint CodecTag { get; init; }
    public long BitRate { get; init; }
}
