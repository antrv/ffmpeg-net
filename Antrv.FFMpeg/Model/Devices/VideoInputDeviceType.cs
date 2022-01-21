using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Devices;

public sealed class VideoInputDeviceType: InputDeviceType
{
    internal VideoInputDeviceType(ConstPtr<AVInputFormat> ptr)
        : base(ptr)
    {
    }
}
