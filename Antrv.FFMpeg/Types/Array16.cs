namespace Antrv.FFMpeg.Types;

public struct Array16<T>
    where T : unmanaged
{
    private Array4<Array4<T>> _value0;

    public int Size => 16;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0[0][0], Size);
    public ref T this[int index] => ref _value0[0][index];
}
