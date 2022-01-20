namespace Antrv.FFMpeg.Interop;

/// <summary>
/// Describe the class of an AVClass context structure. That is an
/// arbitrary struct of which the first field is a pointer to an
/// AVClass struct (e.g. AVCodecContext, AVFormatContext etc.).
/// </summary>
public struct AVClass
{
    /// <summary>
    /// The name of the class; usually it is the same name as the
    /// context structure type to which the AVClass is associated.
    /// </summary>
    public Utf8StringPtr ClassName;

    /// <summary>
    /// A pointer to a function which returns the name of a context
    /// instance ctx associated with the class.
    /// </summary>
    public IntPtr ItemName; // TODO

    /// <summary>
    /// a pointer to the first option specified in the class if any or NULL
    /// see av_set_default_options()
    /// </summary>
    public ConstPtr<AVOption> Option;

    /// <summary>
    /// LIBAVUTIL_VERSION with which this structure was created.
    /// This is used to allow fields to be added without requiring major
    /// version bumps everywhere.
    /// </summary>
    public int Version;

    /// <summary>
    /// Offset in the structure where log_level_offset is stored.
    /// 0 means there is no such variable
    /// </summary>
    public int LogLevelOffsetOffset;

    /// <summary>
    /// Offset in the structure where a pointer to the parent context for
    /// logging is stored. For example a decoder could pass its AVCodecContext
    /// to eval as such a parent context, which an av_log() implementation
    /// could then leverage to display the parent context.
    /// The offset can be NULL.
    /// </summary>
    public int ParentLogContextOffset;

    /// <summary>
    /// Category used for visualization (like color)
    /// This is only set if the category is equal for all objects using this class.
    /// available since version 51.56.100
    /// </summary>
    public AVClassCategory Category;

    /// <summary>
    /// Callback to return the category.
    /// available since version 51.59.100
    /// </summary>
    public IntPtr GetCategory; // TODO

    /// <summary>
    /// Callback to return the supported/allowed ranges.
    /// available since version (52.12)
    /// </summary>
    public IntPtr QueryRanges; // TODO

    /// <summary>
    /// Function to return next AVOptions-enabled child or NULL
    /// </summary>
    public IntPtr ChildNext; // TODO

    /// <summary>
    /// Iterate over the AVClasses corresponding to potential AVOptions-enabled children.
    /// </summary>
    public IntPtr child_class_iterate; // TODO
}
