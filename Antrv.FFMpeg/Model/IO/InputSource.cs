﻿using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Formats;
using System.Collections.Immutable;
using Antrv.FFMpeg.Model.Guards;

namespace Antrv.FFMpeg.Model.IO;

public abstract class InputSource: IDisposable
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

    private protected InputSource(InputSourceData data)
    {
        _context = data.Context;
        _inputFormat = data.Format;
        _streams = data.Streams;

        ImmutableList<InputStream> streams = data.Streams;

        _videoStreams = streams.Where(s => s.MediaType == AVMediaType.AVMEDIA_TYPE_VIDEO)
            .Cast<InputVideoStream>().ToImmutableList();

        _audioStreams = streams.Where(s => s.MediaType == AVMediaType.AVMEDIA_TYPE_AUDIO)
            .Cast<InputAudioStream>().ToImmutableList();

        _subtitleStreams = streams.Where(s => s.MediaType == AVMediaType.AVMEDIA_TYPE_SUBTITLE)
            .Cast<InputSubtitleStream>().ToImmutableList();

        _attachmentStreams = streams.Where(s => s.MediaType == AVMediaType.AVMEDIA_TYPE_ATTACHMENT)
            .Cast<InputAttachmentStream>().ToImmutableList();

        _dataStreams = streams.Where(s => s.MediaType == AVMediaType.AVMEDIA_TYPE_DATA)
            .Cast<InputDataStream>().ToImmutableList();

        _metadata = data.Context.Ptr.Ref.Metadata.ToImmutableDictionary();
    }

    public InputFormat Format => _inputFormat;
    public ImmutableList<InputStream> Streams => _streams;
    public ImmutableList<InputVideoStream> VideoStreams => _videoStreams;
    public ImmutableList<InputAudioStream> AudioStreams => _audioStreams;
    public ImmutableList<InputSubtitleStream> SubtitleStreams => _subtitleStreams;
    public ImmutableList<InputAttachmentStream> AttachmentStreams => _attachmentStreams;
    public ImmutableList<InputDataStream> DataStreams => _dataStreams;

    public ImmutableDictionary<string, string> Metadata => _metadata;

    public void Dispose() => _context.Dispose();

    public static InputSource OpenFile(string filePath, InputFormat? forceFormat = null) =>
        new FileSource(filePath, forceFormat);
}
