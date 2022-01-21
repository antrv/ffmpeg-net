namespace Antrv.FFMpeg.Interop;

/// <summary>
/// List of devices.
/// </summary>
public struct AVDeviceInfoList
{
    /// <summary>
    /// list of autodetected devices
    /// </summary>
    public Ptr<Ptr<AVDeviceInfo>> Devices;

    /// <summary>
    /// number of autodetected devices
    /// </summary>
    public int DeviceCount;

    /// <summary>
    /// index of default device or -1 if no default
    /// </summary>
    public int DefaultDevice;
}
