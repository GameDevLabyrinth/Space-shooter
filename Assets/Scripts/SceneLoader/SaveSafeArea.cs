using UnityEngine;

namespace GameDevLabirinth
{
    public class SaveSafeArea : MonoBehaviour
    {
        [SerializeField, AttentionField]
        private Camera _camera;

        private void Start()
        {
            SafeAreaData safeAreaData = new SafeAreaData();
            safeAreaData.SetMax(_camera.ScreenToWorldPoint(Screen.safeArea.max));
            safeAreaData.SetMin(_camera.ScreenToWorldPoint(Screen.safeArea.min));
        }
    }
}
