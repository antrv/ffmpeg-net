namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Message types used by avdevice_dev_to_app_control_message().
/// </summary>
public enum AVDevToAppMessageType
{
    /// <summary>
    /// Dummy message.
    /// </summary>
    AV_DEV_TO_APP_NONE = ('N' << 24) | ('O' << 16) | ('N' << 8) | 'E',

    /// <summary>
    /// Create window buffer message.
    ///
    /// Device requests to create a window buffer. Exact meaning is device-
    /// and application-dependent. Message is sent before rendering first
    /// frame and all one-shot initializations should be done here.
    /// Application is allowed to ignore preferred window buffer size.
    ///
    /// Application is obligated to inform about window buffer size with AV_APP_TO_DEV_WINDOW_SIZE message.
    ///
    /// data: AVDeviceRect: preferred size of the window buffer.
    ///       NULL: no preferred size of the window buffer.
    /// </summary>
    AV_DEV_TO_APP_CREATE_WINDOW_BUFFER = ('B' << 24) | ('C' << 16) | ('R' << 8) | 'E',

    /// <summary>
    /// Prepare window buffer message.
    ///
    /// Device requests to prepare a window buffer for rendering.
    /// Exact meaning is device- and application-dependent.
    /// Message is sent before rendering of each frame.
    ///
    /// data: NULL.
    /// </summary>
    AV_DEV_TO_APP_PREPARE_WINDOW_BUFFER = ('B' << 24) | ('P' << 16) | ('R' << 8) | 'E',

    /// <summary>
    /// Display window buffer message.
    ///
    /// Device requests to display a window buffer.
    /// Message is sent when new frame is ready to be displayed.
    /// Usually buffers need to be swapped in handler of this message.
    ///
    /// data: NULL.
    /// </summary>
    AV_DEV_TO_APP_DISPLAY_WINDOW_BUFFER = ('B' << 24) | ('D' << 16) | ('I' << 8) | 'S',

    /// <summary>
    /// Destroy window buffer message.
    ///
    /// Device requests to destroy a window buffer.
    /// Message is sent when device is about to be destroyed and window
    /// buffer is not required anymore.
    ///
    /// data: NULL.
    /// </summary>
    AV_DEV_TO_APP_DESTROY_WINDOW_BUFFER = ('B' << 24) | ('D' << 16) | ('E' << 8) | 'S',

    /// <summary>
    /// Buffer fullness status messages.
    ///
    /// Device signals buffer overflow/underflow.
    ///
    /// data: NULL.
    /// </summary>
    AV_DEV_TO_APP_BUFFER_OVERFLOW = ('B' << 24) | ('O' << 16) | ('F' << 8) | 'L',
    AV_DEV_TO_APP_BUFFER_UNDERFLOW = ('B' << 24) | ('U' << 16) | ('F' << 8) | 'L',

    /// <summary>
    /// Buffer readable/writable.
    ///
    /// Device informs that buffer is readable/writable.
    /// When possible, device informs how many bytes can be read/write.
    ///
    /// Device may not inform when number of bytes than can be read/write changes.
    ///
    /// data: int64_t: amount of bytes available to read/write.
    ///       NULL: amount of bytes available to read/write is not known.
    /// </summary>
    AV_DEV_TO_APP_BUFFER_READABLE = ('B' << 24) | ('R' << 16) | ('D' << 8) | ' ',
    AV_DEV_TO_APP_BUFFER_WRITABLE = ('B' << 24) | ('W' << 16) | ('R' << 8) | ' ',

    /// <summary>
    /// Mute state change message.
    ///
    /// Device informs that mute state has changed.
    ///
    /// data: int: 0 for not muted state, non-zero for muted state.
    /// </summary>
    AV_DEV_TO_APP_MUTE_STATE_CHANGED = ('C' << 24) | ('M' << 16) | ('U' << 8) | 'T',

    /// <summary>
    /// Volume level change message.
    ///
    /// Device informs that volume level has changed.
    ///
    /// data: double: new volume with range of 0.0 - 1.0.
    /// </summary>
    AV_DEV_TO_APP_VOLUME_LEVEL_CHANGED = ('C' << 24) | ('V' << 16) | ('O' << 8) | 'L',
}
