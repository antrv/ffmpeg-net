namespace Antrv.FFMpeg.Types;

public struct Array4<T>
    where T : unmanaged
{
    private T _value0;
    private T _value1;
    private T _value2;
    private T _value3;

    public int Size => 4;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0, Size);
    public ref T this[int index] => ref Ptr.FromRef(ref _value0)[index];
}