using System.Formats.Asn1;

namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// Allocates a AVDCT context.
    /// This needs to be initialized with avcodec_dct_init() after optionally
    /// configuring it with AVOptions.
    ///
    /// To free it use av_free()
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<AVDCT> avcodec_dct_alloc();

    [DllImport(LibraryName)]
    public static extern int avcodec_dct_init(Ptr<AVDCT> ctx);

    [DllImport(LibraryName)]
    public static extern ConstPtr<AVClass> avcodec_dct_get_class();
}
