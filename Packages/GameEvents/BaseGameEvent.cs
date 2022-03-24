using System;
using UnityEngine;
using UnityEngine.Events;

namespace Terrehbyte.GameEvents
{
    public abstract class BaseGameEvent : ScriptableObject
    {
        [field: SerializeField]
        public bool IsObsolete { get; private set; }
        
        public virtual Type ArgumentType => typeof(object); 
        
        public abstract void BaseRaise(object data);
        public abstract void BaseAddListener(UnityAction<object> listener);
        public abstract void BaseRemoveListener(UnityAction<object> listener);
    }
}