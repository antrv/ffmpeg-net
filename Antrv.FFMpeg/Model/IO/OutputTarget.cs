using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Formats;
using Antrv.FFMpeg.Model.Guards;

namespace Antrv.FFMpeg.Model.IO;

public abstract class OutputTarget: IDisposable
{
    private readonly FormatContextGuard _context;

    private protected OutputTarget(FormatContextGuard context)
    {
        _context = context;
    }

    public void Dispose() => _context.Dispose();

    public static OutputTarget OpenFile(string filePath, OutputFormat? outputFormat = null) =>
        new FileTarget(filePath, outputFormat);
}

internal sealed class FileTarget: OutputTarget
{
    private readonly string _filePath;

    internal FileTarget(string filePath, OutputFormat? format)
        : base(CreateContext(filePath, format))
    {
        _filePath = filePath;
    }

    private static FormatContextGuard CreateContext(string filePath, OutputFormat? format)
    {
        ConstPtr<AVOutputFormat> outputFormat = format?.Ptr ?? default;

        LibAvFormat.avformat_alloc_output_context2(out Ptr<AVFormatContext> ptr, outputFormat, null, filePath)
            .ThrowOnError("Failed to open file");

        if (!ptr)
            throw new InvalidOperationException("Failed to allocate context");

        return new FormatContextGuard(ptr);
    }
}
