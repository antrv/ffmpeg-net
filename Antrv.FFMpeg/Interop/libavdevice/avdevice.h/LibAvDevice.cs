namespace Antrv.FFMpeg.Interop;

partial class LibAvDevice
{
    /// <summary>
    /// Return the LIBAVDEVICE_VERSION_INT constant.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern uint avdevice_version();

    /// <summary>
    /// Return the libavdevice build-time configuration.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr avdevice_configuration();

    /// <summary>
    /// Return the libavdevice license.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern Utf8StringPtr avdevice_license();

    /// <summary>
    /// Initialize libavdevice and register all the input and output devices.
    /// </summary>
    [DllImport(LibraryName)]
    public static extern void avdevice_register_all();

    /// <summary>
    /// Audio input devices iterator.
    ///
    /// If d is NULL, returns the first registered input audio/video device,
    /// if d is non-NULL, returns the next registered input audio/video device after d
    /// or NULL if d is the last one.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVInputFormat> av_input_audio_device_next(ConstPtr<AVInputFormat> d);

    /// <summary>
    /// Video input devices iterator.
    ///
    /// If d is NULL, returns the first registered input audio/video device,
    /// if d is non-NULL, returns the next registered input audio/video device after d
    /// or NULL if d is the last one.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVInputFormat> av_input_video_device_next(ConstPtr<AVInputFormat> d);

    /// <summary>
    /// Audio output devices iterator.
    ///
    /// If d is NULL, returns the first registered output audio/video device,
    /// if d is non-NULL, returns the next registered output audio/video device after d
    /// or NULL if d is the last one.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVOutputFormat> av_output_audio_device_next(ConstPtr<AVOutputFormat> d);

    /// <summary>
    /// Video output devices iterator.
    ///
    /// If d is NULL, returns the first registered output audio/video device,
    /// if d is non-NULL, returns the next registered output audio/video device after d
    /// or NULL if d is the last one.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern ConstPtr<AVOutputFormat> av_output_video_device_next(ConstPtr<AVOutputFormat> d);

    /// <summary>
    /// Send control message from application to device.
    /// </summary>
    /// <param name="s">device context.</param>
    /// <param name="type">message type.</param>
    /// <param name="data">message data. Exact type depends on message type.</param>
    /// <param name="dataSize">size of message data.</param>
    /// <returns>>= 0 on success, negative on error.
    /// AVERROR(ENOSYS) when device doesn't implement handler of the message.</returns>
    [DllImport(LibraryName)]
    public static extern int avdevice_app_to_dev_control_message(Ptr<AVFormatContext> s, AVAppToDevMessageType type,
        IntPtr data, nuint dataSize);

    /// <summary>
    /// Send control message from device to application.
    /// </summary>
    /// <param name="s">device context.</param>
    /// <param name="type">message type.</param>
    /// <param name="data">message data. Can be NULL.</param>
    /// <param name="dataSize">size of message data.</param>
    /// <returns>>= 0 on success, negative on error.
    /// AVERROR(ENOSYS) when application doesn't implement handler of the message.</returns>
    [DllImport(LibraryName)]
    public static extern int avdevice_dev_to_app_control_message(Ptr<AVFormatContext> s, AVDevToAppMessageType type,
        IntPtr data, nuint dataSize);

    /// <summary>
    /// List devices.
    ///
    /// Returns available device names and their parameters.
    ///
    /// Some devices may accept system-dependent device names that cannot be
    /// autodetected. The list returned by this function cannot be assumed to be always completed.
    /// </summary>
    /// <param name="s">device context.</param>
    /// <param name="deviceList">list of autodetected devices.</param>
    /// <returns>count of autodetected devices, negative on error.</returns>
    [DllImport(LibraryName)]
    public static extern int avdevice_list_devices(Ptr<AVFormatContext> s, out Ptr<AVDeviceInfoList> deviceList);

    /// <summary>
    /// Convenient function to free result of avdevice_list_devices().
    /// </summary>
    /// <param name="deviceList">device list to be freed.</param>
    [DllImport(LibraryName)]
    public static extern void avdevice_free_list_devices(ref Ptr<AVDeviceInfoList> deviceList);

    /// <summary>
    /// List devices.
    ///
    /// Returns available device names and their parameters.
    /// These are convenient wrappers for avdevice_list_devices().
    /// Device context is allocated and deallocated internally.
    ///
    /// Device argument takes precedence over device_name when both are set.
    /// </summary>
    /// <param name="device">device format. May be NULL if device name is set.</param>
    /// <param name="deviceName">device name. May be NULL if device format is set.</param>
    /// <param name="deviceOptions">An AVDictionary filled with device-private options. May be NULL.
    /// The same options must be passed later to avformat_write_header() for output
    /// devices or avformat_open_input() for input devices, or at any other place
    /// that affects device-private options.</param>
    /// <param name="deviceList">list of autodetected devices</param>
    /// <returns>count of autodetected devices, negative on error.</returns>
    [DllImport(LibraryName)]
    public static extern int avdevice_list_input_sources(ConstPtr<AVInputFormat> device,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? deviceName, Ptr<AVDictionary> deviceOptions,
        out Ptr<AVDeviceInfoList> deviceList);

    /// <summary>
    /// List devices.
    ///
    /// Returns available device names and their parameters.
    /// These are convenient wrappers for avdevice_list_devices().
    /// Device context is allocated and deallocated internally.
    ///
    /// Device argument takes precedence over device_name when both are set.
    /// </summary>
    /// <param name="device">device format. May be NULL if device name is set.</param>
    /// <param name="deviceName">device name. May be NULL if device format is set.</param>
    /// <param name="deviceOptions">An AVDictionary filled with device-private options. May be NULL.
    /// The same options must be passed later to avformat_write_header() for output
    /// devices or avformat_open_input() for input devices, or at any other place
    /// that affects device-private options.</param>
    /// <param name="deviceList">list of autodetected devices</param>
    /// <returns>count of autodetected devices, negative on error.</returns>
    [DllImport(LibraryName)]
    public static extern int avdevice_list_output_sinks(ConstPtr<AVOutputFormat> device,
        [MarshalAs(UnmanagedType.LPUTF8Str)] string? deviceName, Ptr<AVDictionary> deviceOptions,
        out Ptr<AVDeviceInfoList> deviceList);

}
