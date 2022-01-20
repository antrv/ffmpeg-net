namespace MediaConverter.Bindings;

public enum AVLog
{
    /// <summary>
    /// Print no output.
    /// </summary>
    AV_LOG_QUIET = -8,

    /// <summary>
    /// Something went really wrong and we will crash now.
    /// </summary>
    AV_LOG_PANIC = 0,

    /// <summary>
    /// Something went wrong and recovery is not possible.
    /// For example, no header was found for a format which depends
    /// on headers or an illegal combination of parameters is used.
    /// </summary>
    AV_LOG_FATAL = 8,

    /// <summary>
    /// Something went wrong and cannot losslessly be recovered.
    /// However, not all future data is affected.
    /// </summary>
    AV_LOG_ERROR = 16,

    /// <summary>
    /// Something somehow does not look correct. This may or may not
    /// lead to problems. An example would be the use of '-vstrict -2'.
    /// </summary>
    AV_LOG_WARNING = 24,

    /// <summary>
    /// Standard information.
    /// </summary>
    AV_LOG_INFO = 32,

    /// <summary>
    /// Detailed information.
    /// </summary>
    AV_LOG_VERBOSE = 40,

    /// <summary>
    /// Stuff which is only useful for libav* developers.
    /// </summary>
    AV_LOG_DEBUG = 48,

    /// <summary>
    /// Extremely verbose debugging, useful for libav* development.
    /// </summary>
    AV_LOG_TRACE = 56,

    /// <summary>
    ///
    /// </summary>
    AV_LOG_MAX_OFFSET = AV_LOG_TRACE - AV_LOG_QUIET,
}