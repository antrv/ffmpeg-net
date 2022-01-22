using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Guards;

internal sealed class FormatContextGuard: ResourceGuard<AVFormatContext, FormatContextGuard>
{
    private FormatContextGuard(Ptr<AVFormatContext> ptr)
        : base(ptr)
    {
    }

    public static FormatContextGuard New() => new(LibAvFormat.avformat_alloc_context());

    protected override void Release(Ptr<AVFormatContext> ptr) => LibAvFormat.avformat_free_context(ptr);
}
