using Antrv.FFMpeg.Interop;
using SkiaSharp;

namespace Antrv.FFMpeg.Model.Guards;

internal sealed class FormatContextGuard: ResourceGuard<AVFormatContext, FormatContextGuard>
{
    public FormatContextGuard()
        : base(LibAvFormat.avformat_alloc_context())
    {
    }

    public FormatContextGuard(Ptr<AVFormatContext> ptr)
        : base(ptr)
    {
    }

    protected override void Release(Ptr<AVFormatContext> ptr)
    {
        LibAvFormat.avformat_close_input(ref ptr);
        
        if (ptr)
            LibAvFormat.avformat_free_context(ptr);
    }
}
