namespace Antrv.FFMpeg.Interop;

public static partial class LibAvUtil
{
    /// <summary>
    /// Sets additional colors for extended debugging sessions.
    /// i.e. av_log(ctx, AV_LOG_DEBUG|AV_LOG_C(134), "Message in purple\n");
    /// Requires 256color terminal support. Uses outside debugging is not recommended.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static AVLogLevel AV_LOG_C(int x) => (AVLogLevel)(x << 8);

    /// <summary>
    /// Get the current log level
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName)]
    public static extern AVLogLevel av_log_get_level();

    /// <summary>
    /// Set the log level
    /// </summary>
    /// <param name="level"></param>
    [DllImport(LibraryName)]
    public static extern void av_log_set_level(AVLogLevel level);

    /// <summary>
    /// Set the logging callback.
    /// The callback must be thread safe, even if the application does not use
    /// threads itself as some codecs are multithreaded.
    /// </summary>
    /// <param name="callback">A logging function with a compatible signature.</param>
    [DllImport(LibraryName)]
    public static extern void av_log_set_callback(IntPtr callback); // TODO

    /// <summary>
    /// Default logging callback
    /// It prints the message to stderr, optionally colorizing it.
    /// </summary>
    /// <param name="avcl">A pointer to an arbitrary struct of which the first field is a pointer to an AVClass struct.</param>
    /// <param name="level">The importance level of the message expressed using a @ref lavu_log_constants "Logging Constant".</param>
    /// <param name="format">The format string (printf-compatible) that specifies how subsequent arguments are converted to output.</param>
    /// <param name="args">The arguments referenced by the format string.</param>
    [DllImport(LibraryName)]
    public static extern void av_log_default_callback(Ptr<AVClass> avcl, AVLogLevel level, Utf8StringPtr format,
        IntPtr args); // TODO

    // TODO
}
