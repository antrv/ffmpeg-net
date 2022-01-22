namespace Antrv.FFMpeg.Types;

public struct Array2<T>
    where T : unmanaged
{
    private T _value0;
    private T _value1;

    public int Size => 2;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0, Size);
    public ref T this[int index] => ref Ptr.FromRef(ref _value0)[index];
}
