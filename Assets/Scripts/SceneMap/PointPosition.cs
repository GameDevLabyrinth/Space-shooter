using UnityEngine;

namespace GameDevLabirinth
{
    public class PointPosition
    {
        private Vector2 _position;
        private float _offsetY;

        public PointPosition()
        {
            SafeAreaData safeArea = new SafeAreaData();
            _position = safeArea.GetMin();
            _offsetY = _position.x / 2;
        }

        public Vector2 GetNextPosition()
        {
            _position.x = _offsetY;
            _position.y += Mathf.Abs(_offsetY);
            _offsetY = -_offsetY;

            return _position;
        }
    }
}
