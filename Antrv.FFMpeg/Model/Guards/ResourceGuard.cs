namespace Antrv.FFMpeg.Model.Guards;

internal abstract class ResourceGuard<T, TGuard>: IDisposable
    where T: unmanaged
    where TGuard: ResourceGuard<T, TGuard>
{
    public Ptr<T> Ptr;

    private protected ResourceGuard() => Ptr = default;

    private protected ResourceGuard(Ptr<T> ptr) => Ptr = ptr;

    ~ResourceGuard()
    {
        ReleaseUnmanagedResources();
    }

    protected abstract void Release(Ptr<T> ptr);

    public TGuard MovePtr()
    {
        TGuard guard = (TGuard)MemberwiseClone();
        guard.Ptr = Ptr;
        Ptr = default;
        return guard;
    }

    private void ReleaseUnmanagedResources()
    {
        Ptr<T> ptr = Ptr;
        if (ptr)
        {
            Release(ptr);
            Ptr = default;
        }
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }
}
