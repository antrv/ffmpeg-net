namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Message types used by avdevice_app_to_dev_control_message().
/// </summary>
public enum AVAppToDevMessageType
{
    /// <summary>
    /// Dummy message.
    /// </summary>
    AV_APP_TO_DEV_NONE = ('N' << 24) | ('O' << 16) | ('N' << 8) | 'E',

    /// <summary>
    /// Window size change message.
    ///
    /// Message is sent to the device every time the application changes the size
    /// of the window device renders to.
    /// Message should also be sent right after window is created.
    ///
    /// data: AVDeviceRect: new window size.
    /// </summary>
    AV_APP_TO_DEV_WINDOW_SIZE = ('G' << 24) | ('E' << 16) | ('O' << 8) | 'M',

    /// <summary>
    /// Repaint request message.
    ///
    /// Message is sent to the device when window has to be repainted.
    /// data: AVDeviceRect: area required to be repainted.
    ///       NULL: whole area is required to be repainted.
    /// </summary>
    AV_APP_TO_DEV_WINDOW_REPAINT = ('R' << 24) | ('E' << 16) | ('P' << 8) | 'A',

    /// <summary>
    /// Request pause/play.
    ///
    /// Application requests pause/unpause playback.
    /// Mostly usable with devices that have internal buffer.
    /// By default devices are not paused.
    ///
    /// data: NULL
    /// </summary>
    AV_APP_TO_DEV_PAUSE = ('P' << 24) | ('A' << 16) | ('U' << 8) | ' ',
    AV_APP_TO_DEV_PLAY = ('P' << 24) | ('L' << 16) | ('A' << 8) | 'Y',
    AV_APP_TO_DEV_TOGGLE_PAUSE = ('P' << 24) | ('A' << 16) | ('U' << 8) | 'T',

    /// <summary>
    /// Volume control message.
    ///
    /// Set volume level. It may be device-dependent if volume
    /// is changed per stream or system wide. Per stream volume
    /// change is expected when possible.
    ///
    /// data: double: new volume with range of 0.0 - 1.0.
    /// </summary>
    AV_APP_TO_DEV_SET_VOLUME = ('S' << 24) | ('V' << 16) | ('O' << 8) | 'L',

    /// <summary>
    /// Mute control messages.
    ///
    /// Change mute state. It may be device-dependent if mute status
    /// is changed per stream or system wide. Per stream mute status
    /// change is expected when possible.
    ///
    /// data: NULL.
    /// </summary>
    AV_APP_TO_DEV_MUTE = (' ' << 24) | ('M' << 16) | ('U' << 8) | 'T',
    AV_APP_TO_DEV_UNMUTE = ('U' << 24) | ('M' << 16) | ('U' << 8) | 'T',
    AV_APP_TO_DEV_TOGGLE_MUTE = ('T' << 24) | ('M' << 16) | ('U' << 8) | 'T',

    /// <summary>
    /// Get volume/mute messages.
    ///
    /// Force the device to send AV_DEV_TO_APP_VOLUME_LEVEL_CHANGED or
    /// AV_DEV_TO_APP_MUTE_STATE_CHANGED command respectively.
    ///
    /// data: NULL.
    /// </summary>
    AV_APP_TO_DEV_GET_VOLUME = ('G' << 24) | ('V' << 16) | ('O' << 8) | 'L',
    AV_APP_TO_DEV_GET_MUTE = ('G' << 24) | ('M' << 16) | ('U' << 8) | 'T',
}
