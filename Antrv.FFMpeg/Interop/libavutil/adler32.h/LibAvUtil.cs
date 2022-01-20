namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    /// <summary>
    /// Calculate the Adler32 checksum of a buffer.
    ///
    /// Passing the return value to a subsequent av_adler32_update() call
    /// allows the checksum of multiple buffers to be calculated as though
    /// they were concatenated.
    /// </summary>
    /// <param name="adler">initial checksum value</param>
    /// <param name="buf">pointer to input buffer</param>
    /// <param name="len">size of input buffer</param>
    /// <returns>updated checksum</returns>
    [DllImport(LibraryName)]
    public static extern AVAdler av_adler32_update(AVAdler adler, ConstPtr<byte> buf, nuint len);
}
