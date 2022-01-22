namespace Antrv.FFMpeg.Types;

public struct Array25<T>
    where T : unmanaged
{
    private Array24<T> _value0;
    private T _value1;

    public int Size => 25;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0[0], Size);
    public ref T this[int index] => ref _value0[index];
}
