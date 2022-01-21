using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Devices;

public sealed class AudioOutputDeviceType: OutputDeviceType
{
    internal AudioOutputDeviceType(ConstPtr<AVOutputFormat> ptr)
        : base(ptr)
    {
    }
}
