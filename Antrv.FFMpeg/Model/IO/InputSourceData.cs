using System.Collections.Immutable;
using Antrv.FFMpeg.Model.Formats;
using Antrv.FFMpeg.Model.Guards;

namespace Antrv.FFMpeg.Model.IO;

internal readonly struct InputSourceData
{
    internal InputSourceData(FormatContextGuard context, InputFormat format, ImmutableList<InputStream> streams)
    {
        Context = context;
        Format = format;
        Streams = streams;
    }

    internal readonly FormatContextGuard Context;
    internal readonly InputFormat Format;
    internal readonly ImmutableList<InputStream> Streams;
}
