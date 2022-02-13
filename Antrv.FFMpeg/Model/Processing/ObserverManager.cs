using System.Collections.Concurrent;

namespace Antrv.FFMpeg.Model.Processing;

internal sealed class ObserverManager<T>: IObservable<T>
{
    private readonly ConcurrentStack<Deleter> _stack = new();
    private readonly Action<IObserver<T>>? _onSubscribed;
    private readonly Action<IObserver<T>>? _onUnsubscribed;

    public ObserverManager()
    {
    }

    public ObserverManager(Action<IObserver<T>> onSubscribed, Action<IObserver<T>> onUnsubscribed)
    {
        _onSubscribed = onSubscribed;
        _onUnsubscribed = onUnsubscribed;
    }

    public void Clear() => _stack.Clear();

    public IDisposable Subscribe(IObserver<T> observer)
    {
        Deleter deleter = new(this, observer);
        _stack.Push(deleter);
        _onSubscribed?.Invoke(observer);
        return deleter;
    }

    public bool HasNoSubscribers => _stack.IsEmpty;

    public void Next(T value)
    {
        foreach (Deleter deleter in _stack)
            deleter.Observer?.OnNext(value);
    }

    public void Error(Exception exception)
    {
        foreach (Deleter deleter in _stack)
            deleter.Observer?.OnError(exception);
    }

    public void Completed()
    {
        foreach (Deleter deleter in _stack)
            deleter.Observer?.OnCompleted();
    }

    private sealed class Deleter: IDisposable
    {
        private readonly ObserverManager<T> _manager;
        public IObserver<T>? Observer;

        public Deleter(ObserverManager<T> manager, IObserver<T> observer) =>
            (_manager, Observer) = (manager, observer);

        public void Dispose()
        {
            IObserver<T>? observer = Observer;
            if (observer is not null && Interlocked.CompareExchange(ref Observer, null, observer) == observer)
            {
                _manager._onUnsubscribed?.Invoke(observer);
            }
        }
    }
}
