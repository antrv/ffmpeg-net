namespace Antrv.FFMpeg.Interop;

[StructLayout(LayoutKind.Explicit)]
public struct AVOptionDefaultValue
{
    [FieldOffset(0)]
    public long Long;

    [FieldOffset(0)]
    public double Double;

    [FieldOffset(0)]
    public Utf8StringPtr String;

    [FieldOffset(0)]
    public AVRational Rational;
}
