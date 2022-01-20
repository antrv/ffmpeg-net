namespace Antrv.FFMpeg.Types;

public struct Array16<T>
    where T : unmanaged
{
    private Array4<Array4<T>> _value0;

    public int Count => 16;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0[0][0], Count);
    public ref T this[int index] => ref _value0[0][index];
}
