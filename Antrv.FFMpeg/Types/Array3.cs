namespace Antrv.FFMpeg.Types;

public struct Array3<T>
    where T : unmanaged
{
    private T _value0;
    private T _value1;
    private T _value2;

    public int Size => 3;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0, Size);
    public ref T this[int index] => ref Ptr.FromRef(ref _value0)[index];
}
