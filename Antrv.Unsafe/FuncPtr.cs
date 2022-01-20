namespace Antrv;

/// <summary>
/// The structure represents pointer to a unmanaged function.
/// </summary>
public readonly struct FuncPtr<T1, T2, TResult>: IEquatable<FuncPtr<T1, T2, TResult>>
    where T1 : unmanaged
    where T2 : unmanaged
    where TResult : unmanaged
{
    private readonly nint _ptr;

    public FuncPtr(nint ptr) => _ptr = ptr;
    public FuncPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe FuncPtr(delegate*<T1, T2, TResult, void> ptr) => _ptr = (nint)ptr;

    public static explicit operator FuncPtr<T1, T2, TResult>(nint ptr) => new(ptr);
    public static explicit operator FuncPtr<T1, T2, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator FuncPtr<T1, T2, TResult>(
        delegate*<T1, T2, TResult, void> ptr) => new(ptr);

    public static explicit operator nint(FuncPtr<T1, T2, TResult> ptr) => ptr._ptr;
    public static explicit operator nuint(FuncPtr<T1, T2, TResult> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<T1, T2, TResult, void
        >(FuncPtr<T1, T2, TResult> ptr) => (delegate*<T1, T2, TResult, void>)ptr._ptr;

    public bool IsNull => _ptr == 0;
    public static FuncPtr<T1, T2, TResult> Null { get; } = default;

    public unsafe delegate*<T1, T2, TResult, void> Pointer => (delegate*<T1, T2, TResult, void>)_ptr;

    public static bool operator ==(FuncPtr<T1, T2, TResult> left, FuncPtr<T1, T2, TResult> right) =>
        left._ptr == right._ptr;

    public static bool operator !=(FuncPtr<T1, T2, TResult> left, FuncPtr<T1, T2, TResult> right) =>
        left._ptr != right._ptr;

    public static bool operator !(FuncPtr<T1, T2, TResult> ptr) => ptr._ptr == 0;
    public static bool operator false(FuncPtr<T1, T2, TResult> ptr) => ptr._ptr == 0;
    public static bool operator true(FuncPtr<T1, T2, TResult> ptr) => ptr._ptr != 0;

    public override int GetHashCode() => (int)_ptr;

    public override bool Equals(object? obj) => obj switch
    {
        null => _ptr == 0,
        FuncPtr<T1, T2, TResult> ptr => _ptr == ptr._ptr,
        nint ptr => _ptr == ptr,
        nuint ptr => _ptr == (nint)ptr,
        _ => false
    };

    public bool Equals(FuncPtr<T1, T2, TResult> other) => _ptr == other._ptr;

    public unsafe TResult Call(T1 arg1, T2 arg2) => ((delegate*<T1, T2, TResult>)_ptr)(arg1, arg2);
}

/// <summary>
/// The structure represents pointer to a unmanaged function.
/// </summary>
public readonly struct FuncPtr<T1, T2, T3, TResult>: IEquatable<FuncPtr<T1, T2, T3, TResult>>
    where T1 : unmanaged
    where T2 : unmanaged
    where T3 : unmanaged
    where TResult : unmanaged
{
    private readonly nint _ptr;

    public FuncPtr(nint ptr) => _ptr = ptr;
    public FuncPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe FuncPtr(delegate*<T1, T2, T3, TResult, void> ptr) => _ptr = (nint)ptr;

    public static explicit operator FuncPtr<T1, T2, T3, TResult>(nint ptr) => new(ptr);
    public static explicit operator FuncPtr<T1, T2, T3, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator FuncPtr<T1, T2, T3, TResult>(
        delegate*<T1, T2, T3, TResult, void> ptr) => new(ptr);

    public static explicit operator nint(FuncPtr<T1, T2, T3, TResult> ptr) => ptr._ptr;
    public static explicit operator nuint(FuncPtr<T1, T2, T3, TResult> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<T1, T2, T3, TResult, void>(FuncPtr<T1, T2, T3, TResult> ptr) =>
        (delegate*<T1, T2, T3, TResult, void>)ptr._ptr;

    public bool IsNull => _ptr == 0;
    public static FuncPtr<T1, T2, T3, TResult> Null { get; } = default;

    public unsafe delegate*<T1, T2, T3, TResult, void> Pointer => (delegate*<T1, T2, T3, TResult, void>)_ptr;

    public static bool operator ==(FuncPtr<T1, T2, T3, TResult> left, FuncPtr<T1, T2, T3, TResult> right) =>
        left._ptr == right._ptr;

    public static bool operator !=(FuncPtr<T1, T2, T3, TResult> left, FuncPtr<T1, T2, T3, TResult> right) =>
        left._ptr != right._ptr;

    public static bool operator !(FuncPtr<T1, T2, T3, TResult> ptr) => ptr._ptr == 0;
    public static bool operator false(FuncPtr<T1, T2, T3, TResult> ptr) => ptr._ptr == 0;
    public static bool operator true(FuncPtr<T1, T2, T3, TResult> ptr) => ptr._ptr != 0;

    public override int GetHashCode() => (int)_ptr;

    public override bool Equals(object? obj) => obj switch
    {
        null => _ptr == 0,
        FuncPtr<T1, T2, T3, TResult> ptr => _ptr == ptr._ptr,
        nint ptr => _ptr == ptr,
        nuint ptr => _ptr == (nint)ptr,
        _ => false
    };

    public bool Equals(FuncPtr<T1, T2, T3, TResult> other) => _ptr == other._ptr;

    public unsafe TResult Call(T1 arg1, T2 arg2, T3 arg3) => ((delegate*<T1, T2, T3, TResult>)_ptr)(arg1, arg2, arg3);
}

/// <summary>
/// The structure represents pointer to a unmanaged function.
/// </summary>
public readonly struct FuncPtr<T1, T2, T3, T4, TResult>: IEquatable<FuncPtr<T1, T2, T3, T4, TResult>>
    where T1 : unmanaged
    where T2 : unmanaged
    where T3 : unmanaged
    where T4 : unmanaged
    where TResult : unmanaged
{
    private readonly nint _ptr;

    public FuncPtr(nint ptr) => _ptr = ptr;
    public FuncPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe FuncPtr(delegate*<T1, T2, T3, T4, TResult, void> ptr) => _ptr = (nint)ptr;

    public static explicit operator FuncPtr<T1, T2, T3, T4, TResult>(nint ptr) => new(ptr);
    public static explicit operator FuncPtr<T1, T2, T3, T4, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator FuncPtr<T1, T2, T3, T4, TResult>(
        delegate*<T1, T2, T3, T4, TResult, void> ptr) => new(ptr);

    public static explicit operator nint(FuncPtr<T1, T2, T3, T4, TResult> ptr) => ptr._ptr;
    public static explicit operator nuint(FuncPtr<T1, T2, T3, T4, TResult> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<T1, T2, T3, T4, TResult, void>(FuncPtr<T1, T2, T3, T4, TResult> ptr) =>
        (delegate*<T1, T2, T3, T4, TResult, void>)ptr._ptr;

    public bool IsNull => _ptr == 0;
    public static FuncPtr<T1, T2, T3, T4, TResult> Null { get; } = default;

    public unsafe delegate*<T1, T2, T3, T4, TResult, void> Pointer => (delegate*<T1, T2, T3, T4, TResult, void>)_ptr;

    public static bool operator ==(FuncPtr<T1, T2, T3, T4, TResult> left, FuncPtr<T1, T2, T3, T4, TResult> right) =>
        left._ptr == right._ptr;

    public static bool operator !=(FuncPtr<T1, T2, T3, T4, TResult> left, FuncPtr<T1, T2, T3, T4, TResult> right) =>
        left._ptr != right._ptr;

    public static bool operator !(FuncPtr<T1, T2, T3, T4, TResult> ptr) => ptr._ptr == 0;
    public static bool operator false(FuncPtr<T1, T2, T3, T4, TResult> ptr) => ptr._ptr == 0;
    public static bool operator true(FuncPtr<T1, T2, T3, T4, TResult> ptr) => ptr._ptr != 0;

    public override int GetHashCode() => (int)_ptr;

    public override bool Equals(object? obj) => obj switch
    {
        null => _ptr == 0,
        FuncPtr<T1, T2, T3, T4, TResult> ptr => _ptr == ptr._ptr,
        nint ptr => _ptr == ptr,
        nuint ptr => _ptr == (nint)ptr,
        _ => false
    };

    public bool Equals(FuncPtr<T1, T2, T3, T4, TResult> other) => _ptr == other._ptr;

    public unsafe TResult Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4) =>
        ((delegate*<T1, T2, T3, T4, TResult>)_ptr)(arg1, arg2, arg3, arg4);
}

/// <summary>
/// The structure represents pointer to a unmanaged function.
/// </summary>
public readonly struct FuncPtr<T1, T2, T3, T4, T5, TResult>: IEquatable<FuncPtr<T1, T2, T3, T4, T5, TResult>>
    where T1 : unmanaged
    where T2 : unmanaged
    where T3 : unmanaged
    where T4 : unmanaged
    where T5 : unmanaged
    where TResult : unmanaged
{
    private readonly nint _ptr;

    public FuncPtr(nint ptr) => _ptr = ptr;
    public FuncPtr(nuint ptr) => _ptr = (nint)ptr;
    public unsafe FuncPtr(delegate*<T1, T2, T3, T4, T5, TResult, void> ptr) => _ptr = (nint)ptr;

    public static explicit operator FuncPtr<T1, T2, T3, T4, T5, TResult>(nint ptr) => new(ptr);
    public static explicit operator FuncPtr<T1, T2, T3, T4, T5, TResult>(nuint ptr) => new(ptr);

    public static unsafe explicit operator FuncPtr<T1, T2, T3, T4, T5, TResult>(
        delegate*<T1, T2, T3, T4, T5, TResult, void> ptr) => new(ptr);

    public static explicit operator nint(FuncPtr<T1, T2, T3, T4, T5, TResult> ptr) => ptr._ptr;
    public static explicit operator nuint(FuncPtr<T1, T2, T3, T4, T5, TResult> ptr) => (nuint)ptr._ptr;

    public static unsafe explicit operator delegate*<T1, T2, T3, T4, T5, TResult, void>(FuncPtr<T1, T2, T3, T4, T5, TResult> ptr) =>
        (delegate*<T1, T2, T3, T4, T5, TResult, void>)ptr._ptr;

    public bool IsNull => _ptr == 0;
    public static FuncPtr<T1, T2, T3, T4, T5, TResult> Null { get; } = default;

    public unsafe delegate*<T1, T2, T3, T4, T5, TResult, void> Pointer => (delegate*<T1, T2, T3, T4, T5, TResult, void>)_ptr;

    public static bool operator ==(FuncPtr<T1, T2, T3, T4, T5, TResult> left, FuncPtr<T1, T2, T3, T4, T5, TResult> right) =>
        left._ptr == right._ptr;

    public static bool operator !=(FuncPtr<T1, T2, T3, T4, T5, TResult> left, FuncPtr<T1, T2, T3, T4, T5, TResult> right) =>
        left._ptr != right._ptr;

    public static bool operator !(FuncPtr<T1, T2, T3, T4, T5, TResult> ptr) => ptr._ptr == 0;
    public static bool operator false(FuncPtr<T1, T2, T3, T4, T5, TResult> ptr) => ptr._ptr == 0;
    public static bool operator true(FuncPtr<T1, T2, T3, T4, T5, TResult> ptr) => ptr._ptr != 0;

    public override int GetHashCode() => (int)_ptr;

    public override bool Equals(object? obj) => obj switch
    {
        null => _ptr == 0,
        FuncPtr<T1, T2, T3, T4, T5, TResult> ptr => _ptr == ptr._ptr,
        nint ptr => _ptr == ptr,
        nuint ptr => _ptr == (nint)ptr,
        _ => false
    };

    public bool Equals(FuncPtr<T1, T2, T3, T4, T5, TResult> other) => _ptr == other._ptr;

    public unsafe TResult Call(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) =>
        ((delegate*<T1, T2, T3, T4, T5, TResult>)_ptr)(arg1, arg2, arg3, arg4, arg5);
}
