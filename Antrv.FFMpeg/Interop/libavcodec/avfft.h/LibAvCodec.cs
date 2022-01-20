namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// Set up a complex FFT.
    /// </summary>
    /// <param name="nBits">log2 of the length of the input array</param>
    /// <param name="inverse">if 0 perform the forward transform, if 1 perform the inverse</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<FFTContext> av_fft_init(int nBits, int inverse);

    /// <summary>
    /// Do the permutation needed BEFORE calling ff_fft_calc().
    /// </summary>
    /// <param name="s"></param>
    /// <param name="z"></param>
    [DllImport(LibraryName)]
    public static extern void av_fft_permute(Ptr<FFTContext> s, Ptr<FFTComplex> z);

    /// <summary>
    /// Do a complex FFT with the parameters defined in av_fft_init(). The
    /// input data must be permuted before. No 1.0/sqrt(n) normalization is done.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="z"></param>
    [DllImport(LibraryName)]
    public static extern void av_fft_calc(Ptr<FFTContext> s, Ptr<FFTComplex> z);

    [DllImport(LibraryName)]
    public static extern void av_fft_end(Ptr<FFTContext> s);


    [DllImport(LibraryName)]
    public static extern Ptr<FFTContext> av_mdct_init(int nBits, int inverse, double scale);

    [DllImport(LibraryName)]
    public static extern void av_imdct_calc(Ptr<FFTContext> s, Ptr<float> output, ConstPtr<float> input);

    [DllImport(LibraryName)]
    public static extern void av_imdct_half(Ptr<FFTContext> s, Ptr<float> output, ConstPtr<float> input);

    [DllImport(LibraryName)]
    public static extern void av_mdct_calc(Ptr<FFTContext> s, Ptr<float> output, ConstPtr<float> input);

    [DllImport(LibraryName)]
    public static extern void av_mdct_end(Ptr<FFTContext> s);

    /// <summary>
    /// Set up a real FFT.
    /// </summary>
    /// <param name="nBits">log2 of the length of the input array</param>
    /// <param name="trans">the type of transform</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<RDFTContext> av_rdft_init(int nBits, RDFTransformType trans);

    [DllImport(LibraryName)]
    public static extern void av_rdft_calc(Ptr<RDFTContext> s, Ptr<float> data);

    [DllImport(LibraryName)]
    public static extern void av_rdft_end(Ptr<RDFTContext> s);

    /// <summary>
    /// Set up DCT.
    /// Note: the first element of the input of DST-I is ignored
    /// </summary>
    /// <param name="nBits">
    /// size of the input array:
    /// (1 &lt;&lt; nBits)     for DCT-II, DCT-III and DST-I
    /// (1 &lt;&lt; nBits) + 1 for DCT-I
    /// </param>
    /// <param name="type">the type of transform</param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Ptr<DCTContext> av_dct_init(int nBits, DCTTransformType type);
    [DllImport(LibraryName)]
    public static extern void av_dct_calc(Ptr<DCTContext> s, Ptr<float> data);
    [DllImport(LibraryName)]
    public static extern void av_dct_end(Ptr<DCTContext> s);
}
