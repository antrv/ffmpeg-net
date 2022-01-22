using Antrv.FFMpeg.Model.Formats;

namespace Antrv.FFMpeg.Model.Devices;

public sealed class InputDeviceList: ContainerFormatList<InputDevice>
{
    internal InputDeviceList()
        : base(Utils.EnumerateInputDevices())
    {
    }
}
