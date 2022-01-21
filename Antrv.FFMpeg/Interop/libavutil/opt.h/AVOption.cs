namespace Antrv.FFMpeg.Interop;

public struct AVOption
{
    public Utf8StringPtr Name;

    /// <summary>
    /// English help text
    /// </summary>
    public Utf8StringPtr Help;

    /// <summary>
    /// The offset relative to the context structure where the option
    /// value is stored. It should be 0 for named constants.
    /// </summary>
    public int Offset;

    public AVOptionType Type;

    /// <summary>
    /// the default value for scalar options
    /// </summary>
    public AVOptionDefaultValue DefaultValue;

    /// <summary>
    /// minimum valid value for the option
    /// </summary>
    public double Min;

    /// <summary>
    /// maximum valid value for the option
    /// </summary>
    public double Max;

    public AVOptionFlags Flags;

    /// <summary>
    /// The logical unit to which the option belongs. Non-constant
    /// options and corresponding named constants share the same
    /// unit. May be NULL.
    /// </summary>
    public Utf8StringPtr Unit; // const char *
}
