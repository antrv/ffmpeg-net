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

    internal Ptr<AVFrame> Ptr { get; }
}
