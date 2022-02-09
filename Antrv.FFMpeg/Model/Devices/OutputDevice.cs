using System.Collections.Immutable;
using Antrv.FFMpeg.Interop;
using Antrv.FFMpeg.Model.Formats;
using Antrv.FFMpeg.Model.Guards;

namespace Antrv.FFMpeg.Model.Devices;

public sealed class OutputDevice: OutputFormat
{
    internal OutputDevice(ConstPtr<AVOutputFormat> ptr)
        : base(ptr)
    {
        (Sinks, DefaultDeviceIndex) = GetSinks(ptr);
    }

    public int DefaultDeviceIndex { get; }

    public ImmutableList<DevicePointInfo> Sinks { get; }

    private static (ImmutableList<DevicePointInfo>, int) GetSinks(ConstPtr<AVOutputFormat> ptr)
    {
        LibAvDevice.avdevice_list_output_sinks(ptr, null, default, out Ptr<AVDeviceInfoList> deviceList);
        using DeviceListGuard guard = new() { Ptr = deviceList };
        return Utils.GetDeviceList(deviceList);
    }
}
