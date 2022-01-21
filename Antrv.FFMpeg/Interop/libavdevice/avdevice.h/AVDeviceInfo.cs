namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Structure describes basic parameters of the device.
/// </summary>
public struct AVDeviceInfo
{
    /// <summary>
    /// device name, format depends on device
    /// </summary>
    public Utf8StringPtr DeviceName;

    /// <summary>
    /// human friendly name
    /// </summary>
    public Utf8StringPtr DeviceDescription;

    /// <summary>
    /// array indicating what media types(s), if any, a device can provide. If null, cannot provide any
    /// </summary>
    public Ptr<AVMediaType> MediaTypes;

    /// <summary>
    /// length of media_types array, 0 if device cannot provide any media types
    /// </summary>
    public int MediaTypeCount;
}
