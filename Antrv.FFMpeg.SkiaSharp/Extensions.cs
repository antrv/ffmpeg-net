using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;
using Antrv.FFMpeg.Model.Processing;
using SkiaSharp;

namespace Antrv.FFMpeg;

public static class Extensions
{
    public static SKBitmap ToBitmap(this Frame frame)
    {
        if (frame.MediaType != AVMediaType.Video)
            throw new InvalidOperationException("Frame must contain video data");

        VideoParameters parameters = (VideoParameters)frame.Parameters;
        VideoParameters destinationParameters =  new VideoParameters
        {
            Width = parameters.Width,
            Height = parameters.Height,
            PixelFormat = AVPixelFormat.AV_PIX_FMT_BGRA,
        };

        using VideoFrameConverter converter = new VideoFrameConverter(parameters, destinationParameters,
            SwScaleFlags.SWS_BICUBIC);

        SKImageInfo info = new SKImageInfo(parameters.Width, parameters.Height, SKColorType.Rgba8888,
            SKAlphaType.Premul);

        SKBitmap bitmap = new SKBitmap(info);
        Ptr<byte> bitmapPtr = (Ptr<byte>)bitmap.GetPixels();
        Ptr<Ptr<byte>> bitmapDataPtr = new(ref bitmapPtr);
        int lineSize0 = info.RowBytes;
        Ptr<int> bitmapLineSizePtr = new(ref lineSize0);

        converter.Convert(frame, bitmapDataPtr, bitmapLineSizePtr);

        return bitmap;
    }
}
