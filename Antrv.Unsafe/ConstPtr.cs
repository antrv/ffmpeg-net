using System.Runtime.CompilerServices;

namespace Antrv;

public readonly struct ConstPtr<T>: IEquatable<ConstPtr<T>>
    where T : unmanaged
{
    private readonly nint _ptr;

    public ConstPtr(nint ptr) => _ptr = ptr;
    public ConstPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe ConstPtr(T* ptr) => _ptr = (nint)ptr;
    public unsafe ConstPtr(ref T ptr) => _ptr = (nint)Unsafe.AsPointer(ref Unsafe.AsRef(ptr));
    public unsafe ConstPtr(Ptr<T> ptr) => _ptr = (nint)ptr.Pointer;

    public static explicit operator ConstPtr<T>(nint ptr) => new(ptr);
    public static explicit operator ConstPtr<T>(nuint ptr) => new(ptr);
    public static unsafe explicit operator ConstPtr<T>(T* ptr) => new(ptr);
    public static implicit operator ConstPtr<T>(Ptr<T> ptr) => new(ptr);
    public static explicit operator nint(ConstPtr<T> ptr) => ptr._ptr;
    public static explicit operator nuint(ConstPtr<T> ptr) => (nuint)ptr._ptr;
    public static unsafe explicit operator T*(ConstPtr<T> ptr) => (T*)ptr._ptr;

    public bool IsNull => _ptr == 0;
    public static ConstPtr<T> Null { get; } = default;

    public unsafe ref readonly T Ref => ref Unsafe.AsRef<T>((void*)_ptr);

    public unsafe T* Pointer => (T*)_ptr;

    public ConstPtr<TResult> Cast<TResult>()
        where TResult : unmanaged => new(_ptr);

    public unsafe ReadOnlySpan<T> AsReadOnlySpan(int length) => new((T*)_ptr, length);

    public unsafe ConstPtr<T> Add(int offset) => new((T*)_ptr + offset);
    public unsafe ConstPtr<T> Add(nint offset) => new((T*)_ptr + offset);
    public unsafe ConstPtr<T> Add(long offset) => new((T*)_ptr + offset);
    public unsafe ConstPtr<T> Subtract(int offset) => new((T*)_ptr - offset);
    public unsafe ConstPtr<T> Subtract(nint offset) => new((T*)_ptr - offset);
    public unsafe ConstPtr<T> Subtract(long offset) => new((T*)_ptr - offset);
    public unsafe long Offset(ConstPtr<T> ptr) => (T*)_ptr - (T*)ptr._ptr;

    public static bool operator ==(ConstPtr<T> left, ConstPtr<T> right) => left._ptr == right._ptr;
    public static bool operator !=(ConstPtr<T> left, ConstPtr<T> right) => left._ptr != right._ptr;

    public static bool operator !(ConstPtr<T> ptr) => ptr._ptr == 0;
    public static bool operator false(ConstPtr<T> ptr) => ptr._ptr == 0;
    public static bool operator true(ConstPtr<T> ptr) => ptr._ptr != 0;

    public static ConstPtr<T> operator ++(ConstPtr<T> ptr) => ptr.Add(1);
    public static ConstPtr<T> operator --(ConstPtr<T> ptr) => ptr.Subtract(1);
    public static ConstPtr<T> operator +(ConstPtr<T> ptr, int offset) => ptr.Add(offset);
    public static ConstPtr<T> operator +(ConstPtr<T> ptr, nint offset) => ptr.Add(offset);
    public static ConstPtr<T> operator +(ConstPtr<T> ptr, long offset) => ptr.Add(offset);
    public static ConstPtr<T> operator -(ConstPtr<T> ptr, int offset) => ptr.Subtract(offset);
    public static ConstPtr<T> operator -(ConstPtr<T> ptr, nint offset) => ptr.Subtract(offset);
    public static ConstPtr<T> operator -(ConstPtr<T> ptr, long offset) => ptr.Subtract(offset);

    public ref readonly T this[int index] => ref (this + index).Ref;

    public override int GetHashCode() => (int)_ptr;

    public override bool Equals(object? obj) => obj switch
    {
        null => _ptr == 0,
        ConstPtr<T> ptr => _ptr == ptr._ptr,
        nint ptr => _ptr == ptr,
        nuint ptr => _ptr == (nint)ptr,
        _ => false
    };

    public bool Equals(ConstPtr<T> other) => _ptr == other._ptr;
}
