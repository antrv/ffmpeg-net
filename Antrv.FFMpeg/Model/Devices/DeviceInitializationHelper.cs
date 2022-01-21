using Antrv.FFMpeg.Interop;

namespace Antrv.FFMpeg.Model.Devices;

internal static class DeviceInitializationHelper
{
    private static int _isInitialized = 0;

    internal static void Initialize()
    {
        if (Interlocked.CompareExchange(ref _isInitialized, 1, 0) == 0)
        {
            LibAvDevice.avdevice_register_all();
        }
    }
}
