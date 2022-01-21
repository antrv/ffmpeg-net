using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Formats;

namespace Antrv.FFMpeg.Model.Devices;

public abstract class InputDeviceType: InputFormat
{
    internal InputDeviceType(ConstPtr<AVInputFormat> ptr)
        : base(ptr)
    {
        LibAvDevice.avdevice_list_input_sources(ptr, null, default, out Ptr<AVDeviceInfoList> deviceList);
        try
        {
            (Devices, DefaultDeviceIndex) = Utils.GetDeviceList(deviceList);
        }
        finally
        {
            LibAvDevice.avdevice_free_list_devices(ref deviceList);
        }
    }

    public int DefaultDeviceIndex { get; }

    public ImmutableList<DeviceInfo> Devices { get; }
}
