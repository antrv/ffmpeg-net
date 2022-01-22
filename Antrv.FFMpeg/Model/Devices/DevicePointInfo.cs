using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Devices;

public readonly struct DevicePointInfo
{
    internal DevicePointInfo(string name, string description, ImmutableList<AVMediaType> mediaTypes)
    {
        Name = name;
        Description = description;
        MediaTypes = mediaTypes;
    }

    public string Name { get; }

    public string Description { get; }

    public ImmutableList<AVMediaType> MediaTypes { get; }
}
