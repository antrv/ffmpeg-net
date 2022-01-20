namespace Antrv.FFMpeg.Interop;

/// <summary>
/// AVDCT context.
/// Note: function pointers can be NULL if the specific features have been disabled at build time.
/// </summary>
public struct AVDCT
{
    public ConstPtr<AVClass> Class;

    public ActionPtr<Ptr<short>> idct; /* align 16 */

    /// <summary>
    /// IDCT input permutation.
    /// Several optimized IDCTs need a permutated input (relative to the
    /// normal order of the reference IDCT).
    /// This permutation must be performed before the idct_put/add.
    /// Note, normally this can be merged with the zigzag/alternate scan.
    /// An example to avoid confusion:
    /// - (->decode coeffs -> zigzag reorder -> dequant -> reference IDCT -> ...)
    /// - (x -> reference DCT -> reference IDCT -> x)
    /// - (x -> reference DCT -> simple_mmx_perm = idct_permutation
    /// -> simple_idct_mmx -> x)
    /// - (-> decode coeffs -> zigzag reorder -> simple_mmx_perm -> dequant
    /// -> simple_idct_mmx -> ...)
    /// </summary>
    public Array64<byte> idct_permutation;

    public ActionPtr<Ptr<short>> fdct; /* align 16 */

    /**
     * DCT algorithm.
     * must use AVOptions to set this field.
     */
    public AVDCTAlgorithm DctAlgo;

    /**
     * IDCT algorithm.
     * must use AVOptions to set this field.
     */
    public AVIDCTAlgorithm IdctAlgo;

    public ActionPtr<Ptr<short>, ConstPtr<byte>, nint> GetPixels; // block (align 16), pixels (align 8), lineSize

    public int BitsPerSample;

    public ActionPtr<Ptr<short>, ConstPtr<byte>, nint> GetPixelsUnaligned; // block (align 16), pixels, lineSize
}
