using UnityEngine;

namespace GameDevLabirinth
{
    public class CannonSingle : CannonBase
    {
        [SerializeField, AttentionField]
        private Transform _bulletStartPosition;

        public override void Shot()
        {
            BulletActivate(_bulletStartPosition);
        }
    }
}
