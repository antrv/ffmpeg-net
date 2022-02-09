using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Formats;
using System.Collections.Immutable;
using Antrv.FFMpeg.Model.Guards;
using Antrv.FFMpeg.Model.Devices;

namespace Antrv.FFMpeg.Model.IO;

public sealed class InputSource: IDisposable
{
    private readonly FormatContextGuard _context;
    private readonly InputFormat _inputFormat;
    private readonly ImmutableList<InputStream> _streams;
    private readonly ImmutableList<InputVideoStream> _videoStreams;
    private readonly ImmutableList<InputAudioStream> _audioStreams;
    private readonly ImmutableList<InputSubtitleStream> _subtitleStreams;
    private readonly ImmutableList<InputAttachmentStream> _attachmentStreams;
    private readonly ImmutableList<InputDataStream> _dataStreams;
    private readonly ImmutableDictionary<string, string> _metadata;
    private readonly ImmutableList<Chapter> _chapters;

    internal InputSource(InputSourceData data)
    {
        _context = data.Context;
        _inputFormat = data.Format;

        ImmutableList<InputStream> streams = CreateStreams(ref data.Context.Ptr.Ref);
        _streams = streams;

        _videoStreams = streams.Where(s => s.MediaType == AVMediaType.Video)
            .Cast<InputVideoStream>().ToImmutableList();

        _audioStreams = streams.Where(s => s.MediaType == AVMediaType.Audio)
            .Cast<InputAudioStream>().ToImmutableList();

        _subtitleStreams = streams.Where(s => s.MediaType == AVMediaType.Subtitle)
            .Cast<InputSubtitleStream>().ToImmutableList();

        _attachmentStreams = streams.Where(s => s.MediaType == AVMediaType.Attachment)
            .Cast<InputAttachmentStream>().ToImmutableList();

        _dataStreams = streams.Where(s => s.MediaType == AVMediaType.Data)
            .Cast<InputDataStream>().ToImmutableList();

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

    public InputFormat Format => _inputFormat;
    public ImmutableList<InputStream> Streams => _streams;
    public ImmutableList<InputVideoStream> VideoStreams => _videoStreams;
    public ImmutableList<InputAudioStream> AudioStreams => _audioStreams;
    public ImmutableList<InputSubtitleStream> SubtitleStreams => _subtitleStreams;
    public ImmutableList<InputAttachmentStream> AttachmentStreams => _attachmentStreams;
    public ImmutableList<InputDataStream> DataStreams => _dataStreams;

    public ImmutableDictionary<string, string> Metadata => _metadata;
    public ImmutableList<Chapter> Chapters => _chapters;

    public void Dispose() => _context.Dispose();

    public static InputSource OpenDevice(InputDevice device, string source,
        ImmutableDictionary<string, string>? options) =>
        new(OpenContextFromDevice(device, source, options));

    public static InputSource OpenFile(string filePath, InputFormat? forceFormat = null) =>
        new(OpenContextFromFile(filePath, forceFormat));

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

    private static ImmutableList<InputStream> CreateStreams(ref AVFormatContext contextRef)
    {
        ImmutableList<InputStream>.Builder streams = ImmutableList.CreateBuilder<InputStream>();
        for (int i = 0, count = contextRef.StreamCount; i < count; i++)
            streams.Add(InputStream.Create(contextRef.Streams[i]));

        return streams.ToImmutable();
    }
}
