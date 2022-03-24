using UnityEngine;
using UnityEngine.Events;

namespace Terrehbyte.GameEvents
{
    public class GameEventListener : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField]
        private BaseGameEvent gameEvent;
        public BaseGameEvent GameEvent => gameEvent;
    
        [Space]
        public UnityEvent<object> OnGameEventRaised;
    
        private void HandleGameEventRaised(object args) => OnGameEventRaised.Invoke(args);

        //
        // Unity Messages
        //
    
        private void OnEnable()
        {
            gameEvent.BaseAddListener(HandleGameEventRaised);
        }

        private void OnDisable()
        {
            gameEvent.BaseRemoveListener(HandleGameEventRaised);
        }
    }
}
