using UnityEngine;

namespace GameDevLabirinth
{
    public class BackgroundController : MonoBehaviour
    {
        [SerializeField, AttentionField]
        private SpriteRenderer _sprite;

        private float _speed = .5f;
        private float _positionMinY;
        private Vector2 _restartPosition;

        private void Awake()
        {
            _restartPosition = transform.position = new Vector2(transform.position.x, new SafeAreaData().GetMin().y);
            _positionMinY = _sprite.bounds.size.y * 2 - _restartPosition.y; // ??? ?????? ??????? - ????????? ??????? ?? "?"
        }

        private void Update()
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
            if (transform.position.y <= -_positionMinY)
            {
                transform.position = _restartPosition;
            }
        }
    }
}
