namespace Antrv.FFMpeg.Types;

public struct Array14<T>
    where T : unmanaged
{
    private Array10<T> _value0;
    private Array4<T> _value1;

    public int Count => 14;
    public Span<T> AsSpan() => MemoryMarshal.CreateSpan(ref _value0[0], Count);
    public ref T this[int index] => ref _value0[index];
}
