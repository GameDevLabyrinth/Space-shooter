using UnityEngine;

namespace GameDevLabirinth
{
    public class StartEvents : MonoBehaviour
    {
        [SerializeField]
        private GameEvent _startScene;

        [SerializeField]
        private GameEvent _gameplay;

        private void Start()
        {
            _startScene.Init();
            _gameplay.Init();
        }

    }
}
