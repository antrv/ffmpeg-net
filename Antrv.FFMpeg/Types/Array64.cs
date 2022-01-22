namespace Antrv.FFMpeg.Types;

public struct Array64<T>
    where T : unmanaged
{
    private Array8<Array8<T>> _value0;

    public int Size => 64;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0[0][0], Size);
    public ref T this[int index] => ref _value0[0][index];
}
