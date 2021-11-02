using UnityEngine;

namespace GameDevLabirinth
{
    public class PlayerCannonSingle : PlayerCannonBase
    {
        [SerializeField, AttentionField]
        private Transform _bulletStartPosition;

        protected override void GetBullet()
        {
            var bullet = _bulletsPool.GetBullet();
            if (bullet == null)
                Debug.Log("!");
            else
            {
                bullet.transform.position = _bulletStartPosition.position;
                bullet.transform.Rotate(transform.rotation.eulerAngles);
                bullet.SetActive(true);
            }
        }
    }
}
