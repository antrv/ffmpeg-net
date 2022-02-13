using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Guards;
using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

public sealed class VideoFrameConverter: IDisposable
{
    private readonly SwsContextGuard _context;

    public VideoFrameConverter(VideoParameters sourceParameters, VideoParameters destinationParameters,
        SwScaleFlags flags)
    {
        _context = new SwsContextGuard(sourceParameters.Width, sourceParameters.Height, sourceParameters.PixelFormat,
            destinationParameters.Width, destinationParameters.Height, destinationParameters.PixelFormat, flags);
    }

    public VideoFrameConverter(VideoParameters sourceParameters, int dstWidth, int dstHeight,
        AVPixelFormat dstPixelFormat, SwScaleFlags flags)
    {
        _context = new SwsContextGuard(sourceParameters.Width, sourceParameters.Height, sourceParameters.PixelFormat,
            dstWidth, dstHeight, dstPixelFormat, flags);
    }

    public void Convert(Frame source, Ptr<Ptr<byte>> destination, Ptr<int> destinationLineSizes)
    {
        ref AVFrame frameRef = ref source.Ptr.Ref;
        ConstPtr<ConstPtr<byte>> frameData = new ConstPtr<Ptr<byte>>(ref frameRef.Data[0]).Cast<ConstPtr<byte>>();
        ConstPtr<int> frameLineSize = new(ref frameRef.LineSize[0]);

        LibSwScale.sws_scale(_context.Ptr, frameData, frameLineSize, 0, frameRef.Height,
            destination, destinationLineSizes).ThrowOnError("Failed to convert bitmap");
    }

    public void Dispose() => _context.Dispose();
}
