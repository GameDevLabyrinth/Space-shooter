using UnityEngine;

namespace GameDevLabirinth
{
    public class EnemyMove : MonoBehaviour
    {
        private const float Speed = 5f;

        private float _endPosition;

        private void Start()
        {
            _endPosition = new SafeAreaData().GetMin().y;
        }

        private void Update()
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime);
            if (transform.position.y < _endPosition)
                Destroy(gameObject);
        }

    }
}
