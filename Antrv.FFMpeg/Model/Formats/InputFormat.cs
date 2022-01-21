using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Formats;

/// <summary>
/// The description of an input container format.
/// </summary>
public class InputFormat: ContainerFormat
{
    internal InputFormat(ConstPtr<AVInputFormat> ptr)
        : base(ptr)
    {
        Ptr = ptr;
    }

    internal ConstPtr<AVInputFormat> Ptr { get; }
}
