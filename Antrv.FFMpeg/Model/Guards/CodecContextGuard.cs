using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Guards;

internal sealed class CodecContextGuard: ResourceGuard<AVCodecContext, CodecContextGuard>
{
    public CodecContextGuard(ConstPtr<AVCodec> codec)
        : base(LibAvCodec.avcodec_alloc_context3(codec))
    {
    }

    public CodecContextGuard(Ptr<AVCodecContext> ptr)
        : base(ptr)
    {
    }

    protected override void Release(Ptr<AVCodecContext> ptr) => LibAvCodec.avcodec_free_context(ref ptr);
}
