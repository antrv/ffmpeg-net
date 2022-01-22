using Antrv.FFMpeg.Model.Formats;

namespace Antrv.FFMpeg.Model.Devices;

public sealed class OutputDeviceList: ContainerFormatList<OutputDevice>
{
    internal OutputDeviceList()
        : base(Utils.EnumerateOutputDevices())
    {
    }
}
