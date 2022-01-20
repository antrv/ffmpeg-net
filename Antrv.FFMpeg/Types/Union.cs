namespace Antrv.FFMpeg.Types;

[StructLayout(LayoutKind.Explicit)]
public struct Union<T1, T2>
    where T1: unmanaged
    where T2: unmanaged
{
    [FieldOffset(0)]
    public T1 Value1;

    [FieldOffset(0)]
    public T2 Value2;
}

[StructLayout(LayoutKind.Explicit)]
public struct Union<T1, T2, T3, T4>
    where T1: unmanaged
    where T2: unmanaged
    where T3: unmanaged
    where T4: unmanaged
{
    [FieldOffset(0)]
    public T1 Value1;

    [FieldOffset(0)]
    public T2 Value2;

    [FieldOffset(0)]
    public T3 Value3;

    [FieldOffset(0)]
    public T4 Value4;
}
