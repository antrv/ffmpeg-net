using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Guards;
using Antrv.FFMpeg.Model.IO;
using SkiaSharp;

namespace Antrv.FFMpeg.Model.Processing;

public readonly struct VideoFrame: IFrame
{
    internal VideoFrame(IRawVideoStream stream, Ptr<AVFrame> ptr)
    {
        Stream = stream;
        Ptr = ptr;
    }

    public IRawVideoStream Stream { get; }
    public VideoParameters Parameters => Stream.Parameters;
    internal Ptr<AVFrame> Ptr { get; }

    Ptr<AVFrame> IFrame.Ptr => Ptr;
    IRawStream IDecodedPacket.Stream => Stream;
    StreamParameters IDecodedPacket.Parameters => Parameters;

    public SKBitmap ToBitmap()
    {
        VideoParameters parameters = Parameters;
        ref AVFrame frame = ref Ptr.Ref;

        SKImageInfo info = new SKImageInfo(parameters.Width, parameters.Height, SKColorType.Rgba8888,
            SKAlphaType.Premul);

        SKBitmap bitmap = new SKBitmap(info);
        Ptr<byte> bitmapPtr = (Ptr<byte>)bitmap.GetPixels();

        //if (parameters.PixelFormat != AVPixelFormat.AV_PIX_FMT_BGRA)
        {
            using SwsContextGuard context = new(parameters.Width, parameters.Height, parameters.PixelFormat,
                parameters.Width, parameters.Height, AVPixelFormat.AV_PIX_FMT_BGRA, SwScaleFlags.SWS_BICUBIC);

            Ptr<Ptr<byte>> bitmapDataPtr = new(ref bitmapPtr);
            int lineSize0 = 4 * parameters.Width;
            Ptr<int> bitmapLineSizePtr = new(ref lineSize0);

            ConstPtr<ConstPtr<byte>> frameData = new ConstPtr<Ptr<byte>>(ref frame.Data[0]).Cast<ConstPtr<byte>>();
            ConstPtr<int> frameLineSize = new(ref frame.LineSize[0]);

            LibSwScale.sws_scale(context.Ptr, frameData, frameLineSize, 0, parameters.Height,
                bitmapDataPtr, bitmapLineSizePtr).ThrowOnError("Failed to convert bitmap");
        }

        return bitmap;
    }
}
