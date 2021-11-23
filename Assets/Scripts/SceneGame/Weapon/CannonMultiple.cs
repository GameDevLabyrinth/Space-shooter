using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    public class CannonMultiple : CannonBase
    {
        [SerializeField]
        private List<Transform> _bulletsStart;

        public override void Shot()
        {
            foreach (var item in _bulletsStart)
            {
                BulletActivate(item);
            }
        }
    }
}
