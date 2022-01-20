namespace Antrv.FFMpeg.Types;

public struct Array8<T>
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

    public int Count => 8;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0, Count);
    public ref T this[int index] => ref Ptr.FromRef(ref _value0)[index];
}