using System.Collections;
using UnityEngine;

namespace GameDevLabirinth
{
    public abstract class PlayerCannonBase : MonoBehaviour
    {
        [SerializeField, AttentionField]
        private GameObject _bulletPrefab;

        [SerializeField, Range(1, 20)]
        private int _bulletsCount;

        private WaitForSeconds _wait;
        protected BulletsPool _bulletsPool;

        public void Activate()
        {
            _wait = new WaitForSeconds(.5f);
            StartCoroutine(Timer());
        }

        private void Start()
        {
            _bulletsPool = FindObjectOfType<BulletsPool>();
            _bulletsPool.AddBullets(_bulletPrefab, _bulletsCount);
        }

        private IEnumerator Timer()
        {
            while (true)
            {
                GetBullet();
                yield return _wait;
            }
        }

        protected abstract void GetBullet();
    }
}
