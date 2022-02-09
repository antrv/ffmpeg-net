using Antrv.FFMpeg.Model.Formats;
using Antrv.FFMpeg.Model.Guards;

namespace Antrv.FFMpeg.Model.IO;

internal readonly struct InputSourceData
{
    internal InputSourceData(FormatContextGuard context, InputFormat format)
    {
        Context = context;
        Format = format;
    }

    internal readonly FormatContextGuard Context;
    internal readonly InputFormat Format;
}
