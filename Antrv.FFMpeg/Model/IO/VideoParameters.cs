using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class VideoParameters: CodecParameters
{
    public int Width { get; init; }
    public int Height { get; init; }
    public AVPixelFormat PixelFormat { get; init; }
    public AVChromaLocation ChromaLocation { get; init; }
    public AVColorPrimaries ColorPrimaries { get; init; }
    public AVColorRange ColorRange { get; init; }
    public AVColorSpace ColorSpace { get; init; }
    public AVColorTransferCharacteristic ColorTransferCharacteristic { get; init; }
    public AVFieldOrder FieldOrder { get; init; }
    public int VideoDelay { get; init; }
}
