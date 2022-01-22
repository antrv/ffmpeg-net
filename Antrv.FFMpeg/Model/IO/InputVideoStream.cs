using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputVideoStream: InputStream<VideoParameters>
{
    internal InputVideoStream(Ptr<AVStream> ptr)
        : base(ptr, CreateParameters(ptr))
    {
    }

    private static VideoParameters CreateParameters(Ptr<AVStream> ptr)
    {
        ref AVCodecParameters parRef = ref ptr.Ref.CodecParameters.Ref;

        return new()
        {
            MediaType = AVMediaType.AVMEDIA_TYPE_VIDEO,
            Width = parRef.Width,
            Height = parRef.Height,
            BitRate = parRef.BitRate,
            Profile = parRef.Profile,
            Level = parRef.Level,
            FieldOrder = parRef.FieldOrder,
            CodecTag = parRef.CodecTag,
            ChromaLocation = parRef.ChromaLocation,
            PixelFormat = (AVPixelFormat)parRef.Format,
            ColorPrimaries = parRef.ColorPrimaries,
            ColorRange = parRef.ColorRange,
            ColorSpace = parRef.ColorSpace,
            ColorTransferCharacteristic = parRef.ColorTrc,
            VideoDelay = parRef.VideoDelay
        };
    }
}
