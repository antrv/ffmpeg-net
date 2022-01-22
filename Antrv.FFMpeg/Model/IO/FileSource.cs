using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Formats;
using Antrv.FFMpeg.Model.Guards;

namespace Antrv.FFMpeg.Model.IO;

internal sealed class FileSource: InputSource
{
    internal FileSource(string filePath, InputFormat? forceFormat)
        : base(OpenContextFromFile(filePath, forceFormat))
    {
    }

    private static InputSourceData OpenContextFromFile(string fileName,
        InputFormat? format)
    {
        using FormatContextGuard context = FormatContextGuard.New();
        using DictionaryGuard dictionary = DictionaryGuard.New();
        dictionary.Set("scan_all_pmts", "1");

        ConstPtr<AVInputFormat> inputFormat = format?.Ptr ?? default;
        LibAvFormat.avformat_open_input(ref context.Ptr, fileName, inputFormat, ref dictionary.Ptr)
            .ThrowOnError("Failed to open media file");

        LibAvFormat.avformat_find_stream_info(context.Ptr, default).ThrowOnError("Failed to open media file");

        ref AVFormatContext contextRef = ref context.Ptr.Ref;

        InputFormat? resultFormat = format ?? Global.InputFormats.GetByPtr(contextRef.InputFormat);
        if (resultFormat is null)
            throw new InvalidOperationException("Cannot find input format");

        //Global.InputFormats[contextRef.InputFormat.Ref.Name.ToString()];

        ImmutableList<InputStream>.Builder streams = ImmutableList.CreateBuilder<InputStream>();
        for (int i = 0, count = contextRef.StreamCount; i < count; i++)
            streams.Add(InputStream.Create(contextRef.Streams[i]));

        ImmutableList<InputStream> streamList = streams.ToImmutable();
        return new(context.MovePtr(), resultFormat, streamList);
    }
}
