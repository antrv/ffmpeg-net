using Antrv.FFMpeg.Types;

namespace Antrv.FFMpeg.Interop;

public struct AVSubtitleRect
{
    /// <summary>
    /// top left corner  of pict, undefined when pict is not set
    /// </summary>
    public int X;
    /// <summary>
    /// top left corner  of pict, undefined when pict is not set
    /// </summary>
    public int Y;
    /// <summary>
    /// width            of pict, undefined when pict is not set
    /// </summary>
    public int W;
    /// <summary>
    /// height           of pict, undefined when pict is not set
    /// </summary>
    public int H;
    /// <summary>
    /// number of colors in pict, undefined when pict is not set
    /// </summary>
    public int NumberColors;

    /// <summary>
    /// data+linesize for the bitmap of this subtitle.
    /// Can be set for text/ass as well once they are rendered.
    /// </summary>
    public Array4<Ptr<byte>> Data;
    public Array4<int> LineSize;

    public AVSubtitleType Type;

    /// <summary>
    /// 0 terminated plain UTF-8 text
    /// </summary>
    public Utf8StringPtr Text;

    /// <summary>
    /// 0 terminated ASS/SSA compatible event line.
    /// The presentation of this is unaffected by the other values in this struct.
    /// </summary>
    public Utf8StringPtr Ass;

    public AVSubtitleFlags Flags;
}
