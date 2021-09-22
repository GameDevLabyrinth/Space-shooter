using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "GameSO/Game Event")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> _listeners = new List<GameEventListener>();

        public void RegisterListerner(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }

        public void Init()
        {
            //Debug.Log(this.name);
            for (int i = _listeners.Count - 1; i >= 0; i--)
            {
                _listeners[i].InitEvent();
            }
        }
    }
}
