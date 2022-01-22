namespace Antrv.FFMpeg.Types;

public struct Array9<T>
    where T : unmanaged
{
    private T _value0;
    private T _value1;
    private T _value2;
    private T _value3;
    private T _value4;
    private T _value5;
    private T _value6;
    private T _value7;
    private T _value8;

    public int Size => 9;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0, Size);
    public ref T this[int index] => ref Ptr.FromRef(ref _value0)[index];
}
