using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Formats;
using Antrv.FFMpeg.Model.Guards;

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
        using DeviceListGuard guard = new() { Ptr = deviceList };
        return Utils.GetDeviceList(deviceList);
    }
}
