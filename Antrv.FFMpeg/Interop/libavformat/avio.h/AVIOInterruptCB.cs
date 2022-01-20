namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Callback for checking whether to abort blocking functions.
/// AVERROR_EXIT is returned in this case by the interrupted
/// function. During blocking operations, callback is called with
/// opaque as parameter. If the callback returns 1, the
/// blocking operation will be aborted.
///
/// No members can be added to this struct without a major bump, if
/// new elements have been added after this struct in AVFormatContext
/// or AVIOContext.
/// </summary>
public struct AVIOInterruptCB
{
    public IntPtr Callback; // int (* callback) (void*)
    public IntPtr Opaque;
}
