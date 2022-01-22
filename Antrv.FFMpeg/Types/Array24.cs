namespace Antrv.FFMpeg.Types;

public struct Array24<T>
    where T : unmanaged
{
    private Array16<T> _value0;
    private Array8<T> _value1;

    public int Size => 24;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0[0], Size);
    public ref T this[int index] => ref _value0[index];
}
