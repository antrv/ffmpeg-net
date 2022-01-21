using System.Collections.Immutable;

namespace Antrv.FFMpeg.Model.Devices;

public sealed class InputDeviceTypeList: DeviceTypeList<InputDeviceType, AudioInputDeviceType, VideoInputDeviceType>
{
    internal InputDeviceTypeList()
        : base(Utils.EnumerateAudioInputDevices().ToImmutableList(),
            Utils.EnumerateVideoInputDevices().ToImmutableList())
    {
    }
}
