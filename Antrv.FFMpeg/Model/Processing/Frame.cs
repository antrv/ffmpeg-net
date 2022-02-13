using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

/// <summary>
/// Represents a decoded media data: a video frame, an audio fragment, etc.
/// </summary>
public readonly struct Frame
{
    public Frame(IRawStream stream, Ptr<AVFrame> ptr)
    {
        Stream = stream;
        Ptr = ptr;
    }

    public IRawStream Stream { get; }
    public AVMediaType MediaType => Stream.MediaType;
    public StreamParameters Parameters => Stream.Parameters;
    public AVRational TimeBase => Stream.TimeBase;

    internal Ptr<AVFrame> Ptr { get; }

    /// <summary>
    /// Presentation timestamp in TimeBase units (time when frame should be shown to user).
    /// </summary>
    public long Pts => Ptr.Ref.Pts;

    /// <summary>
    /// Presentation timestamp (time when frame should be shown to user).
    /// Can be inaccurate if Timebase is not an integer value.
    /// </summary>
    public TimeSpan Pts2 => TimeUtils.ToTimeSpan(Pts, TimeBase);
}
