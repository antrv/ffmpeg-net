using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Guards;

internal sealed class CodecParametersGuard: ResourceGuard<AVCodecParameters, CodecParametersGuard>
{
    public CodecParametersGuard()
        : base(LibAvCodec.avcodec_parameters_alloc())
    {
    }

    public CodecParametersGuard(Ptr<AVCodecParameters> ptr)
        : base(ptr)
    {
    }

    protected override void Release(Ptr<AVCodecParameters> ptr) => LibAvCodec.avcodec_parameters_free(ref ptr);
}
