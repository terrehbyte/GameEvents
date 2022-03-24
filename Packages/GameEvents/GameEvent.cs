using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Terrehbyte.GameEvents
{
    public class GameEvent<T> : BaseGameEvent, IGameEvent<T>
    {
        protected readonly Dictionary<UnityAction<object>, UnityAction<T>> baseListeners = new Dictionary<UnityAction<object>, UnityAction<T>>();
        protected readonly UnityEvent<T> _listeners = new UnityEvent<T>();
        protected UnityEvent<T> Listeners
        {
            get
            {
                if(IsObsolete) { Debug.LogWarning($"The '{name}' event is obsolete and will be removed in the future.", this); }
                return _listeners;
            }
        }
    
        //
        // BaseGameEvent
        //
        
        public override Type ArgumentType => typeof(T);

        public override void BaseRaise(object data)
        {
            if (data is T arg)
            {
                Raise(arg);
            }
            else
            {
                throw new ArgumentException($"The data type '{data.GetType()}' is not compatible with the event type '{typeof(T)}'.");
            }
        }
        
        public override void BaseAddListener(UnityAction<object> listener)
        {
            baseListeners[listener] = (T data) => listener(data);
            Listeners.AddListener(baseListeners[listener]);
        }
        
        public override void BaseRemoveListener(UnityAction<object> listener)
        {
            Listeners.RemoveListener(baseListeners[listener]);
            baseListeners.Remove(listener);
        }
        
        //
        // GameEvent<T> methods
        //
        
        public void Raise(T data)
        {
            Listeners.Invoke(data);
        }
        
        public UnityAction<T> AddListener(UnityAction<T> callback)
        {
            Listeners.AddListener(callback);
            return callback;
        }

        public void RemoveListener(UnityAction<T> callback)
        {
            Listeners?.RemoveListener(callback);
        }
    }

    public static class GameEventExtensions
    {
        public static void AddListenerIfValid<T>(this GameEvent<T> gEvent, UnityAction<T> callback)
        {
            if(gEvent == null) { return; }
            gEvent.AddListener(callback);
        }

        public static void RemoveListenerIfValid<T>(this GameEvent<T> gEvent, UnityAction<T> callback)
        {
            if (gEvent == null) { return; }
            gEvent.RemoveListener(callback);
        }

        public static void RaiseIfValid<T>(this GameEvent<T> gEvent, T customData)
        {
            if (gEvent == null) { return; }
            gEvent.Raise(customData);
        }
    }
}