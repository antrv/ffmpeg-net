namespace Antrv.FFMpeg.Types;

public struct Array256<T>
    where T : unmanaged
{
    private Array16<Array16<T>> _value0;

    public int Size => 256;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0[0][0], Size);
    public ref T this[int index] => ref _value0[0][index];
}
