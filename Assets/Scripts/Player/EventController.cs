using System;

public class EventController
{
    public event Action BaseEvent;
    public void AddListener(Action listener) => BaseEvent += listener;
    public void RemoveListener(Action listener) => BaseEvent -= listener;
    public void InvokeEvent() => BaseEvent?.Invoke();
}

public class EventController<T>
{
    public event Action<T> BaseEventT;
    public void AddListener(Action<T> listener) => BaseEventT += listener;
    public void RemoveListener(Action<T> listener) => BaseEventT -= listener;
    public void InvokeEvent(T typename) => BaseEventT?.Invoke(typename);
}
