using System.Windows;
using System.Windows.Media.Imaging;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;
using Antrv.FFMpeg.Model.Processing;

namespace Antrv.FFMpeg;

public static class Extensions
{
    public static void CopyTo(this Frame frame, WriteableBitmap writeableBitmap)
    {
        if (frame.MediaType != AVMediaType.Video)
            throw new InvalidOperationException("Frame must contain video data");

        VideoParameters parameters = (VideoParameters)frame.Parameters;

        int width = (int)writeableBitmap.Width;
        int height = (int)writeableBitmap.Height;

        VideoParameters destinationParameters = new VideoParameters
        {
            Width = width,
            Height = height,
            PixelFormat = AVPixelFormat.AV_PIX_FMT_BGRA, // TODO: convert pixel format from WriteableBitmap
        };

        using VideoFrameConverter converter = new VideoFrameConverter(parameters, destinationParameters,
            SwScaleFlags.SWS_BICUBIC);

        converter.Convert(frame, writeableBitmap);
    }

    public static void Convert(this VideoFrameConverter converter, Frame frame, WriteableBitmap writeableBitmap)
    {
        writeableBitmap.Lock();
        try
        {
            Ptr<byte> bitmapPtr = (Ptr<byte>)writeableBitmap.BackBuffer;
            Ptr<Ptr<byte>> bitmapDataPtr = new(ref bitmapPtr);
            int lineSize0 = writeableBitmap.BackBufferStride;
            Ptr<int> bitmapLineSizePtr = new(ref lineSize0);
            converter.Convert(frame, bitmapDataPtr, bitmapLineSizePtr);
        }
        finally
        {
            writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, (int)writeableBitmap.Width, (int)writeableBitmap.Height));
            writeableBitmap.Unlock();
        }
    }
}
