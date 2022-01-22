using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Formats;

namespace Antrv.FFMpeg.Model.Devices;

public sealed class InputDevice: InputFormat
{
    internal InputDevice(ConstPtr<AVInputFormat> ptr)
        : base(ptr)
    {
        (Sources, DefaultDeviceIndex) = GetSources(ptr);
    }

    public int DefaultDeviceIndex { get; }

    public ImmutableList<DevicePointInfo> Sources { get; }

    private static (ImmutableList<DevicePointInfo>, int) GetSources(ConstPtr<AVInputFormat> ptr)
    {
        LibAvDevice.avdevice_list_input_sources(ptr, null, default, out Ptr<AVDeviceInfoList> deviceList);
        try
        {
            return Utils.GetDeviceList(deviceList);
        }
        finally
        {
            LibAvDevice.avdevice_free_list_devices(ref deviceList);
        }
    }
}
