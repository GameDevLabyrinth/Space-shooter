using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    public class PlayerCannonMultiple : PlayerCannonBase
    {
        [SerializeField]
        private List<Transform> _bulletsStart;

        protected override void GetBullet()
        {
            foreach (var item in _bulletsStart)
            {
                var bullet = _bulletsPool.GetBullet();
                if (bullet == null)
                    Debug.Log("!");
                else
                {
                    bullet.transform.position = item.position;
                    bullet.transform.Rotate(transform.rotation.eulerAngles);
                    bullet.SetActive(true);
                }
            }
        }
    }
}
