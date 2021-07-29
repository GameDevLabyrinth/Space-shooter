using UnityEngine;

namespace GameDevLabirinth
{
    public class BorderVerticalPosition : MonoBehaviour
    {
        [SerializeField, AttentionField]
        private Camera _camera;

        [SerializeField]
        private bool _isUp;

        private void Start()
        {
            SetPosition();
        }

        private void SetPosition()
        {
            Vector2 safeAreaPosition = _isUp ? Screen.safeArea.max : Screen.safeArea.min;
            float positionY = _camera.ScreenToWorldPoint(safeAreaPosition).y;
            transform.position = new Vector2(transform.position.x, positionY);
        }
    }
}
