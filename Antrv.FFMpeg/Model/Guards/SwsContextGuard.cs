using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Guards;

internal sealed class SwsContextGuard: ResourceGuard<SwsContext, SwsContextGuard>
{
    internal SwsContextGuard(Ptr<SwsContext> ptr)
        : base(ptr)
    {
    }

    internal SwsContextGuard(int sourceWidth, int sourceHeight, AVPixelFormat sourcePixelFormat, int destinationWidth,
        int destinationHeight, AVPixelFormat destinationPixelFormat, SwScaleFlags scaleFlags,
        Ptr<SwsFilter> sourceFilter = default, Ptr<SwsFilter> destinationFilter = default,
        ConstPtr<double> parameters = default)
        : base(LibSwScale.sws_getContext(sourceWidth, sourceHeight, sourcePixelFormat, destinationWidth,
            destinationHeight, destinationPixelFormat, scaleFlags, sourceFilter, destinationFilter, parameters))
    {
    }

    protected override void Release(Ptr<SwsContext> ptr) => LibSwScale.sws_freeContext(ptr);
}
