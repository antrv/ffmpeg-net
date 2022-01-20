namespace Antrv.FFMpeg.Types;

public struct Array10<T>
    where T : unmanaged
{
    private Array8<T> _value0;
    private Array2<T> _value1;

    public int Count => 10;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0[0], Count);
    public ref T this[int index] => ref _value0[index];
}
