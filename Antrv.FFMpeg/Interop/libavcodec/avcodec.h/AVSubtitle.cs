namespace Antrv.FFMpeg.Interop;

public struct AVSubtitle
{
    /// <summary>
    /// 0 = graphics
    /// </summary>
    public ushort Format;

    /// <summary>
    /// relative to packet pts, in ms
    /// </summary>
    public uint StartDisplayTime;

    /// <summary>
    /// relative to packet pts, in ms
    /// </summary>
    public uint EndDisplayTime;

    public uint NumRects;
    public Ptr<Ptr<AVSubtitleRect>> Rects;

    /// <summary>
    /// Same as packet pts, in AV_TIME_BASE
    /// </summary>
    public long Pts;
}
