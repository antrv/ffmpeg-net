namespace Antrv.FFMpeg.Interop;

partial class LibAvCodec
{
    /// <summary>
    /// Extract the bitstream ID and the frame size from AC-3 data.
    /// </summary>
    /// <param name="buf"></param>
    /// <param name="size"></param>
    /// <param name="bitstreamId"></param>
    /// <param name="frameSize"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern int av_ac3_parse_header(ConstPtr<byte> buf, nuint size, out byte bitstreamId,
        out ushort frameSize);
}
