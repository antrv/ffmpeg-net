using System.Collections.Immutable;

namespace Antrv.FFMpeg.Model.Devices;

public sealed class OutputDeviceTypeList: DeviceTypeList<OutputDeviceType, AudioOutputDeviceType, VideoOutputDeviceType>
{
    internal OutputDeviceTypeList(): base(Utils.EnumerateAudioOutputDevices().ToImmutableList(),
        Utils.EnumerateVideoOutputDevices().ToImmutableList())
    {
    }
}
