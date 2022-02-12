using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.IO;

namespace Antrv.FFMpeg.Model.Processing;

public readonly struct Packet
{
    internal Packet(IEncodedStream stream, Ptr<AVPacket> ptr)
    {
        Stream = stream;
        Ptr = ptr;
    }

    public IEncodedStream Stream { get; }
    public StreamParameters Parameters => Stream.Parameters;
    internal Ptr<AVPacket> Ptr { get; }

    /// <summary>
    /// Presentation timestamp of the packet in the stream time base units; the time at which
    /// the decompressed packet will be presented to the user.
    /// Can be null if it is not stored in the file.
    /// </summary>
    public long? Pts => TimeUtils.ToNullableTs(Ptr.Ref.Pts);

    /// <summary>
    /// Presentation timestamp of the packet; the time at which
    /// the decompressed packet will be presented to the user.
    /// Can be inaccurate if the stream time base is not an integer number.
    /// Can be null if it is not stored in the file.
    /// </summary>
    public TimeSpan? Pts2 => TimeUtils.ToTimeSpan(Pts, Stream.TimeBase);

    /// <summary>
    /// Decompression timestamp in the stream time base units;
    /// the time at which the packet is decompressed.
    /// Can be null if it is not stored in the file.
    /// </summary>
    public long? Dts => TimeUtils.ToNullableTs(Ptr.Ref.Dts);

    /// <summary>
    /// Decompression timestamp; the time at which the packet is decompressed.
    /// Can be inaccurate if the stream time base is not an integer number.
    /// Can be null if it is not stored in the file.
    /// </summary>
    public TimeSpan? Dts2 => TimeUtils.ToTimeSpan(Dts, Stream.TimeBase);

    /// <summary>
    /// Duration of this packet in the stream time base units, null if unknown.
    /// Equals next packet pts minus this packet pts in presentation order.
    /// </summary>
    public long? Duration => TimeUtils.ToNullableDuration(Ptr.Ref.Duration);

    /// <summary>
    /// Duration of this packet, null if unknown.
    /// Equals next packet pts minus this packet pts in presentation order.
    /// </summary>
    public TimeSpan? Duration2 => TimeUtils.ToTimeSpan(Duration, Stream.TimeBase);
}
