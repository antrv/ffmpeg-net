using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Formats;

/// <summary>
/// The description of an output container format.
/// </summary>
public sealed class OutputFormat: ContainerFormat
{
    internal OutputFormat(ConstPtr<AVOutputFormat> ptr)
        : base(ptr)
    {
        Ptr = ptr;
    }

    internal ConstPtr<AVOutputFormat> Ptr { get; }
}
