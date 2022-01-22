using System.Runtime.InteropServices;

namespace Antrv;

public readonly struct Utf8StringPtr: IEquatable<Utf8StringPtr>
{
    private readonly nint _ptr;

    public Utf8StringPtr(nint ptr) => _ptr = ptr;
    public unsafe Utf8StringPtr(Ptr<byte> ptr) => _ptr = (nint)ptr.Pointer;
    public unsafe Utf8StringPtr(ConstPtr<byte> ptr) => _ptr = (nint)ptr.Pointer;

    public static explicit operator Utf8StringPtr(nint ptr) => new(ptr);
    public static explicit operator Utf8StringPtr(Ptr<byte> ptr) => new(ptr);
    public static explicit operator Utf8StringPtr(ConstPtr<byte> ptr) => new(ptr);
    public static explicit operator nint(Utf8StringPtr ptr) => ptr._ptr;
    public static explicit operator Ptr<byte>(Utf8StringPtr ptr) => new(ptr._ptr);
    public static explicit operator ConstPtr<byte>(Utf8StringPtr ptr) => new(ptr._ptr);
    public static explicit operator string?(Utf8StringPtr ptr) => Marshal.PtrToStringUTF8(ptr._ptr);

    public bool IsNull => _ptr == 0;
    public static Utf8StringPtr Null { get; } = default;

    public static bool operator ==(Utf8StringPtr left, Utf8StringPtr right) => left._ptr == right._ptr;
    public static bool operator !=(Utf8StringPtr left, Utf8StringPtr right) => left._ptr != right._ptr;

    public static bool operator !(Utf8StringPtr ptr) => ptr._ptr == 0;
    public static bool operator false(Utf8StringPtr ptr) => ptr._ptr == 0;
    public static bool operator true(Utf8StringPtr ptr) => ptr._ptr != 0;

    public override int GetHashCode() => (int)_ptr;

    public override bool Equals(object? obj) => obj switch
    {
        null => _ptr == 0,
        Utf8StringPtr ptr => _ptr == ptr._ptr,
        nint ptr => _ptr == ptr,
        _ => false
    };

    public bool Equals(Utf8StringPtr other) => _ptr == other._ptr;

    public override string ToString() => Marshal.PtrToStringUTF8(_ptr) ?? string.Empty;
}
