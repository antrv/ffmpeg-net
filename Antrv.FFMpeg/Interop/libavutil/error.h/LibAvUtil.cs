namespace Antrv.FFMpeg.Interop;

partial class LibAvUtil
{
    public const int AV_ERROR_MAX_STRING_SIZE = 64;

    /// <summary>
    /// Put a description of the AVERROR code errnum in errbuf.
    /// In case of failure the global variable errno is set to indicate the
    /// error. Even in case of failure av_strerror() will print a generic
    /// error message indicating the errnum provided to errbuf.
    /// </summary>
    /// <param name="errNum">error code to describe</param>
    /// <param name="errBuf">buffer to which description is written</param>
    /// <param name="errBufSize">the size in bytes of errBuf</param>
    /// <returns>0 on success, a negative value if a description for errnum cannot be found</returns>
    [DllImport(LibraryName)]
    public static extern int av_strerror(int errNum, Ptr<byte> errBuf, nuint errBufSize);
}
