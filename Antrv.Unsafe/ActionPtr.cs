namespace Antrv;

/// <summary>
/// The structure represents pointer to a function with void return type.
/// </summary>
public readonly struct ActionPtr<T1>: IEquatable<ActionPtr<T1>>
    where T1 : unmanaged
{
    private readonly nint _ptr;

    public ActionPtr(nint ptr) => _ptr = ptr;
    public ActionPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe ActionPtr(delegate*<T1, void> ptr) => _ptr = (nint)ptr;

    public static explicit operator ActionPtr<T1>(nint ptr) => new(ptr);
    public static explicit operator ActionPtr<T1>(nuint ptr) => new(ptr);

    public static unsafe explicit operator ActionPtr<T1>(delegate*<T1, void> ptr) => new(ptr);

    public static explicit operator nint(ActionPtr<T1> ptr) => ptr._ptr;
    public static explicit operator nuint(ActionPtr<T1> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<T1, void>(ActionPtr<T1> ptr) => (delegate*<T1, void>)ptr._ptr;

    public bool IsNull => _ptr == 0;
    public static ActionPtr<T1> Null { get; } = default;

    public unsafe delegate*<T1, void> Pointer => (delegate*<T1, void>)_ptr;

    public static bool operator ==(ActionPtr<T1> left, ActionPtr<T1> right) =>
        left._ptr == right._ptr;

    public static bool operator !=(ActionPtr<T1> left, ActionPtr<T1> right) =>
        left._ptr != right._ptr;

    public static bool operator !(ActionPtr<T1> ptr) => ptr._ptr == 0;
    public static bool operator false(ActionPtr<T1> ptr) => ptr._ptr == 0;
    public static bool operator true(ActionPtr<T1> ptr) => ptr._ptr != 0;

    public override int GetHashCode() => (int)_ptr;

    public override bool Equals(object? obj) => obj switch
    {
        null => _ptr == 0,
        ActionPtr<T1> ptr => _ptr == ptr._ptr,
        nint ptr => _ptr == ptr,
        nuint ptr => _ptr == (nint)ptr,
        _ => false
    };

    public bool Equals(ActionPtr<T1> other) => _ptr == other._ptr;

    public unsafe void Call(T1 arg1) => ((delegate*<T1, void>)_ptr)(arg1);
}

/// <summary>
/// The structure represents pointer to a function with void return type.
/// </summary>
public readonly struct ActionPtr<T1, T2, T3>: IEquatable<ActionPtr<T1, T2, T3>>
    where T1 : unmanaged
    where T2 : unmanaged
    where T3 : unmanaged
{
    private readonly nint _ptr;

    public ActionPtr(nint ptr) => _ptr = ptr;
    public ActionPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe ActionPtr(delegate*<T1, T2, T3, void> ptr) => _ptr = (nint)ptr;

    public static explicit operator ActionPtr<T1, T2, T3>(nint ptr) => new(ptr);
    public static explicit operator ActionPtr<T1, T2, T3>(nuint ptr) => new(ptr);

    public static unsafe explicit operator ActionPtr<T1, T2, T3>(
        delegate*<T1, T2, T3, void> ptr) => new(ptr);

    public static explicit operator nint(ActionPtr<T1, T2, T3> ptr) => ptr._ptr;
    public static explicit operator nuint(ActionPtr<T1, T2, T3> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<T1, T2, T3, void>(ActionPtr<T1, T2, T3> ptr) =>
        (delegate*<T1, T2, T3, void>)ptr._ptr;

    public bool IsNull => _ptr == 0;
    public static ActionPtr<T1, T2, T3> Null { get; } = default;

    public unsafe delegate*<T1, T2, T3, void> Pointer => (delegate*<T1, T2, T3, void>)_ptr;

    public static bool operator ==(ActionPtr<T1, T2, T3> left, ActionPtr<T1, T2, T3> right) =>
        left._ptr == right._ptr;

    public static bool operator !=(ActionPtr<T1, T2, T3> left, ActionPtr<T1, T2, T3> right) =>
        left._ptr != right._ptr;

    public static bool operator !(ActionPtr<T1, T2, T3> ptr) => ptr._ptr == 0;
    public static bool operator false(ActionPtr<T1, T2, T3> ptr) => ptr._ptr == 0;
    public static bool operator true(ActionPtr<T1, T2, T3> ptr) => ptr._ptr != 0;

    public override int GetHashCode() => (int)_ptr;

    public override bool Equals(object? obj) => obj switch
    {
        null => _ptr == 0,
        ActionPtr<T1, T2, T3> ptr => _ptr == ptr._ptr,
        nint ptr => _ptr == ptr,
        nuint ptr => _ptr == (nint)ptr,
        _ => false
    };

    public bool Equals(ActionPtr<T1, T2, T3> other) => _ptr == other._ptr;

    public unsafe void Call(T1 arg1, T2 arg2, T3 arg3) => ((delegate*<T1, T2, T3, void>)_ptr)(arg1, arg2, arg3);
}


/// <summary>
/// The structure represents pointer to a function with void return type.
/// </summary>
public readonly struct ActionPtr<T1, T2, T3, T4, T5, T6> : IEquatable<ActionPtr<T1, T2, T3, T4, T5, T6>>
    where T1 : unmanaged
    where T2 : unmanaged
    where T3 : unmanaged
    where T4 : unmanaged
    where T5 : unmanaged
    where T6 : unmanaged
{
    private readonly nint _ptr;

    public ActionPtr(nint ptr) => _ptr = ptr;
    public ActionPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe ActionPtr(delegate*<T1, T2, T3, T4, T5, T6, void> ptr) => _ptr = (nint)ptr;

    public static explicit operator ActionPtr<T1, T2, T3, T4, T5, T6>(nint ptr) => new(ptr);
    public static explicit operator ActionPtr<T1, T2, T3, T4, T5, T6>(nuint ptr) => new(ptr);

    public static unsafe explicit operator ActionPtr<T1, T2, T3, T4, T5, T6>(
        delegate*<T1, T2, T3, T4, T5, T6, void> ptr) => new(ptr);

    public static explicit operator nint(ActionPtr<T1, T2, T3, T4, T5, T6> ptr) => ptr._ptr;
    public static explicit operator nuint(ActionPtr<T1, T2, T3, T4, T5, T6> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<T1, T2, T3, T4, T5, T6, void
        >(ActionPtr<T1, T2, T3, T4, T5, T6> ptr) => (delegate*<T1, T2, T3, T4, T5, T6, void>)ptr._ptr;

    public bool IsNull => _ptr == 0;
    public static ActionPtr<T1, T2, T3, T4, T5, T6> Null { get; } = default;

    public unsafe delegate*<T1, T2, T3, T4, T5, T6, void> Pointer => (delegate*<T1, T2, T3, T4, T5, T6, void>)_ptr;

    public static bool operator ==(ActionPtr<T1, T2, T3, T4, T5, T6> left, ActionPtr<T1, T2, T3, T4, T5, T6> right) =>
        left._ptr == right._ptr;

    public static bool operator !=(ActionPtr<T1, T2, T3, T4, T5, T6> left, ActionPtr<T1, T2, T3, T4, T5, T6> right) =>
        left._ptr != right._ptr;

    public static bool operator !(ActionPtr<T1, T2, T3, T4, T5, T6> ptr) => ptr._ptr == 0;
    public static bool operator false(ActionPtr<T1, T2, T3, T4, T5, T6> ptr) => ptr._ptr == 0;
    public static bool operator true(ActionPtr<T1, T2, T3, T4, T5, T6> ptr) => ptr._ptr != 0;

    public override int GetHashCode() => (int)_ptr;

    public override bool Equals(object? obj) => obj switch
    {
        null => _ptr == 0,
        ActionPtr<T1, T2, T3, T4, T5, T6> ptr => _ptr == ptr._ptr,
        nint ptr => _ptr == ptr,
        nuint ptr => _ptr == (nint)ptr,
        _ => false
    };

    public bool Equals(ActionPtr<T1, T2, T3, T4, T5, T6> other) => _ptr == other._ptr;

    public unsafe void Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) =>
        ((delegate*<T1, T2, T3, T4, T5, T6, void>)_ptr)(arg1, arg2, arg3, arg4, arg5, arg6);
}
