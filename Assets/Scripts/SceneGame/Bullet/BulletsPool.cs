using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    public class BulletsPool : MonoBehaviour
    {
        private readonly List<GameObject> _bullets = new List<GameObject>();
        public void AddBullets(GameObject bulletPrefab, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var bullet = Instantiate(bulletPrefab, transform);
                bullet.SetActive(false);
                _bullets.Add(bullet);
            }
        }

        public GameObject GetBullet()
        {
            for (int i = 0; i < _bullets.Count; i++)
            {
                if (!_bullets[i].activeInHierarchy)
                    return _bullets[i];
            }

            return null;
        }
    }
}
