using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Formats;

public sealed class InputFormatList: ContainerFormatList<InputFormat>
{
    private readonly ImmutableDictionary<nint, InputFormat> _byPointers;

    internal InputFormatList()
        : base(Utils.EnumerateInputFormats())
    {
        _byPointers = this.ToImmutableDictionary(x => (nint)x.Ptr);
    }

    internal InputFormat? GetByPtr(ConstPtr<AVInputFormat> ptr) =>
        _byPointers.TryGetValue((nint)ptr, out var format) ? format : null;
}
