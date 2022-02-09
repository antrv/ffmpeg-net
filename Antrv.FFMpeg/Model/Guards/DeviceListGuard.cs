using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Guards;

internal struct DeviceListGuard: IDisposable
{
    public Ptr<AVDeviceInfoList> Ptr;

    public void Dispose()
    {
        if (Ptr)
        {
            LibAvDevice.avdevice_free_list_devices(ref Ptr);
        }
    }
}
