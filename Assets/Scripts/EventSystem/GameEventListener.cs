using UnityEngine;
using UnityEngine.Events;

namespace GameDevLabirinth
{
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField, AttentionField]
        private GameEvent _gameEvent;

        [SerializeField]
        private UnityEvent Action;

        private void OnEnable()
        {
            _gameEvent.RegisterListerner(this);
        }

        private void OnDisable()
        {
            _gameEvent.UnregisterListener(this);
        }

        public void InitEvent()
        {
            Action.Invoke();
        }
    }
}
