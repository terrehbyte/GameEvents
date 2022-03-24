using UnityEngine;

namespace Terrehbyte.GameEvents
{
    [CreateAssetMenu(menuName = "Game Event / GameEvent<System.Object>")]
    public class GameEventObject : GameEvent<object>, IGameEvent
    {
        public void RaiseBool(bool value) => Listeners.Invoke(value);
        public void RaiseInt(int value) => Listeners.Invoke(value);
        public void RaiseFloat(float value) => Listeners.Invoke( value);
        public void RaiseString(string value) => Listeners.Invoke(value);
    
        public void RaiseUnityObject(UnityEngine.Object value) => Listeners.Invoke(value);
    }
}
