namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    public const int AV_AAC_ADTS_HEADER_SIZE = 7;

    /// <summary>
    /// Extract the number of samples and frames from AAC data.
    /// </summary>
    /// <param name="buf">pointer to AAC data buffer</param>
    /// <param name="samples">Pointer to where number of samples is written</param>
    /// <param name="frames">Pointer to where number of frames is written</param>
    /// <returns>Returns 0 on success, error code on failure.</returns>
    [DllImport(LibraryName)]
    public static extern int av_adts_header_parse(ConstPtr<byte> buf, out uint samples, out byte frames);
}
