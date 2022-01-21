using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Devices;

public sealed class AudioInputDeviceType: InputDeviceType
{
    internal AudioInputDeviceType(ConstPtr<AVInputFormat> ptr)
        : base(ptr)
    {
    }
}
