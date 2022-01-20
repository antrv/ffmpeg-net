using Antrv.FFMpeg.Types;

namespace Antrv.FFMpeg.Interop;

public struct AVCodecParser
{
    /// <summary>
    /// several codec IDs are permitted
    /// </summary>
    public Array7<int> CodecIds;

    public int PrivateDataSize;

    public IntPtr ParserInit;
    /// <summary>
    /// This callback never returns an error, a negative value means that
    /// the frame start was in a previous packet.
    /// </summary>
    public IntPtr ParserParse;
    public IntPtr ParserClose;
    public IntPtr Split; // avctx, buf, bufSize
}
