using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Guards;

internal sealed class FrameGuard: ResourceGuard<AVFrame, FrameGuard>
{
    public FrameGuard()
        : base(LibAvUtil.av_frame_alloc())
    {
    }

    public void UnRef() => LibAvUtil.av_frame_unref(Ptr);

    protected override void Release(Ptr<AVFrame> ptr) => LibAvUtil.av_frame_free(ref ptr);
}
