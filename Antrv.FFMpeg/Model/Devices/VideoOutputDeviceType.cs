using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Devices;

public sealed class VideoOutputDeviceType: OutputDeviceType
{
    internal VideoOutputDeviceType(ConstPtr<AVOutputFormat> ptr)
        : base(ptr)
    {
    }
}
