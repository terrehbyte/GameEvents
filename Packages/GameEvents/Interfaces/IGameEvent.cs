using System;
using UnityEngine.Events;

namespace Terrehbyte.GameEvents
{
    public interface IGameEvent
    {
        void Raise(object data);
        UnityAction<object> AddListener(UnityAction<object> callback);
        void RemoveListener(UnityAction<object> callback);
    }

    public interface IGameEvent<T>
    {
        void Raise(T data);
        UnityAction<T> AddListener(UnityAction<T> callback);
        void RemoveListener(UnityAction<T> callback);
    }
}