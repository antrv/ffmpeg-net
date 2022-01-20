namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// The spec limits the number of wavelet decompositions to 4 for both
    /// level 1 (VC-2) and 128 (long-gop default).
    /// 5 decompositions is the maximum before >16-bit buffers are needed.
    /// Schroedinger allows this for DD 9,7 and 13,7 wavelets only, limiting
    /// the others to 4 decompositions (or 3 for the fidelity filter).
    /// 
    /// We use this instead of MAX_DECOMPOSITIONS to save some memory.
    /// </summary>
    public const int MAX_DWT_LEVELS = 5;

    /// <summary>
    /// Parse a Dirac sequence header.
    /// </summary>
    /// <param name="dsh">this function will allocate and fill an AVDiracSeqHeader struct
    /// and write it into this pointer. The caller must free it with av_free().</param>
    /// <param name="buffer">the data buffer</param>
    /// <param name="bufferSize">the size of the data buffer in bytes</param>
    /// <param name="logCtx">if non-NULL, this function will log errors here</param>
    /// <returns>0 on success, a negative AVERROR code on failure</returns>
    [DllImport(LibraryName)]
    public static extern int av_dirac_parse_sequence_header(out Ptr<AVDiracSeqHeader> dsh, ConstPtr<byte> buffer,
        nuint bufferSize, IntPtr logCtx);
}
