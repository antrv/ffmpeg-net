using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Formats;
using System.Collections.Immutable;
using Antrv.FFMpeg.Model.Guards;
using Antrv.FFMpeg.Model.Devices;
using Antrv.FFMpeg.Model.Processing;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputSource: IInputSource, IDisposable
{
    private readonly FormatContextGuard _context;
    private readonly PacketGuard _packet;
    private readonly InputFormat _inputFormat;
    private readonly ImmutableList<InputStream> _streams;
    private readonly ImmutableDictionary<string, string> _metadata;
    private readonly ImmutableList<Chapter> _chapters;

    internal InputSource(InputSourceData data)
    {
        _packet = new();
        _context = data.Context;
        _inputFormat = data.Format;

        ImmutableList<InputStream> streams = CreateStreams(this, ref data.Context.Ptr.Ref);
        _streams = streams;

        ref var contextRef = ref data.Context.Ptr.Ref;
        _metadata = contextRef.Metadata.ToImmutableDictionary();
        _chapters = contextRef.Chapters.EnumerableChapters((int)contextRef.ChapterCount).Select(x => new Chapter
        {
            Id = x.Ref.Id,
            StartTime = x.Ref.Start,
            EndTime = x.Ref.End,
            TimeBase = x.Ref.TimeBase,
            Metadata = x.Ref.Metadata.ToImmutableDictionary()
        }).ToImmutableList();
    }

    /// <summary>
    /// Input format of the source.
    /// </summary>
    public InputFormat Format => _inputFormat;

    /// <summary>
    /// The list of media streams.
    /// </summary>
    public ImmutableList<InputStream> Streams => _streams;

    /// <summary>
    /// The metadata related to the input source.
    /// </summary>
    public ImmutableDictionary<string, string> Metadata => _metadata;

    /// <summary>
    /// The list of chapters.
    /// </summary>
    public ImmutableList<Chapter> Chapters => _chapters;

    /// <summary>
    /// Position of the first frame, deduced from the stream values.
    /// </summary>
    public TimeSpan StartTime => TimeSpan.FromTicks(_context.Ptr.Ref.StartTime * (TimeSpan.TicksPerSecond /
        LibAvUtil.AV_TIME_BASE));

    /// <summary>
    /// Seek input to the position.
    /// </summary>
    /// <param name="position"></param>
    public void Seek(TimeSpan position) => Seek(position, TimeSpan.Zero);

    /// <summary>
    /// Seek input to the position with the accuracy.
    /// The real position will be set withing interval [position - accuracy; position + accuracy].
    /// </summary>
    /// <param name="position"></param>
    /// <param name="accuracy"></param>
    public void Seek(TimeSpan position, TimeSpan accuracy)
    {
        if (position < TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(position), "Position must be non-negative");

        if (accuracy < TimeSpan.Zero)
            throw new ArgumentOutOfRangeException(nameof(position), "Accuracy must be non-negative");

        long ts = position.Ticks / (TimeSpan.TicksPerSecond / LibAvUtil.AV_TIME_BASE);
        long acc = accuracy.Ticks / (TimeSpan.TicksPerSecond / LibAvUtil.AV_TIME_BASE);
        LibAvFormat.avformat_seek_file(_context.Ptr, -1, Math.Max(ts - acc, 0), ts, ts + acc, AVIOSeekFlags.None)
            .ThrowOnError("Error seeking");
    }

    public void Dispose() => _context.Dispose();

    public static InputSource OpenDevice(InputDevice device, string source,
        ImmutableDictionary<string, string>? options) =>
        new(OpenContextFromDevice(device, source, options));

    public static InputSource OpenFile(string filePath, InputFormat? forceFormat = null) =>
        new(OpenContextFromFile(filePath, forceFormat));

    PushResult IInputSource.Push()
    {
        int error = LibAvFormat.av_read_frame(_context.Ptr, _packet.Ptr);
        if (error < 0)
        {
            if (error == (int)AVError.AVERROR_EOF)
            {
                foreach (InputStream stream in _streams)
                    stream.Completed();

                return PushResult.EndOfData;
            }

            try
            {
                error.ThrowOnError("Failed to read packet");
            }
            catch (Exception exception)
            {
                foreach (InputStream stream in _streams)
                    stream.Error(exception);
            }

            return PushResult.Error;
        }

        int streamIndex = _packet.Ptr.Ref.StreamIndex;
        try
        {
            InputStream stream = _streams[streamIndex];
            Packet packet = new(stream, _packet.Ptr);
            stream.Next(packet);
        }
        finally
        {
            _packet.UnRef();
        }

        return PushResult.Success;
    }

    private static InputSourceData OpenContextFromFile(string fileName,
        InputFormat? format)
    {
        using FormatContextGuard context = new();
        using DictionaryGuard dictionary = new();
        dictionary.Set("scan_all_pmts", "1");

        ConstPtr<AVInputFormat> inputFormat = format?.Ptr ?? default;
        LibAvFormat.avformat_open_input(ref context.Ptr, fileName, inputFormat, ref dictionary.Ptr)
            .ThrowOnError("Failed to open media file");

        LibAvFormat.avformat_find_stream_info(context.Ptr, default).ThrowOnError("Failed to open media file");

        InputFormat? resultFormat = format ?? Global.InputFormats.GetByPtr(context.Ptr.Ref.InputFormat);
        if (resultFormat is null)
            throw new InvalidOperationException("Cannot find input format");

        return new(context.MovePtr(), resultFormat);
    }

    private static InputSourceData OpenContextFromDevice(InputDevice device, string source,
        ImmutableDictionary<string, string>? options)
    {
        using FormatContextGuard context = new();
        using DictionaryGuard dictionary = new();

        if (options is not null)
        {
            foreach ((string key, string value) in options)
                dictionary.Set(key, value);
        }

        ConstPtr<AVInputFormat> inputFormat = device.Ptr;
        LibAvFormat.avformat_open_input(ref context.Ptr, source, inputFormat, ref dictionary.Ptr)
            .ThrowOnError("Failed to open device");

        return new(context.MovePtr(), device);
    }

    private static ImmutableList<InputStream> CreateStreams(InputSource source, ref AVFormatContext contextRef)
    {
        ImmutableList<InputStream>.Builder streams = ImmutableList.CreateBuilder<InputStream>();
        for (int i = 0, count = contextRef.StreamCount; i < count; i++)
            streams.Add(new InputStream(source, contextRef.Streams[i]));

        return streams.ToImmutable();
    }
}
