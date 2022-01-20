namespace Antrv.FFMpeg.Interop;

[Flags]
public enum AVWorkaroundBugs
{
    None = 0,

    /// <summary>
    /// autodetection
    /// </summary>
    FF_BUG_AUTODETECT = 1,
    FF_BUG_XVID_ILACE = 4,
    FF_BUG_UMP4 = 8,
    FF_BUG_NO_PADDING = 16,
    FF_BUG_AMV = 32,
    FF_BUG_QPEL_CHROMA = 64,
    FF_BUG_STD_QPEL = 128,
    FF_BUG_QPEL_CHROMA2 = 256,
    FF_BUG_DIRECT_BLOCKSIZE = 512,
    FF_BUG_EDGE = 1024,
    FF_BUG_HPEL_CHROMA = 2048,
    FF_BUG_DC_CLIP = 4096,

    /// <summary>
    /// Work around various bugs in Microsoft's broken decoders.
    /// </summary>
    FF_BUG_MS = 8192,
    FF_BUG_TRUNCATED = 16384,
    FF_BUG_IEDGE = 32768,

}
