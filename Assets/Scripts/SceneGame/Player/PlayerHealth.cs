using UnityEngine;
using UnityEngine.Events;

namespace GameDevLabirinth
{
    public sealed class PlayerHealth : ObjectHealth
    {
        [SerializeField]
        private UnityEvent<int> OnChangedHelth;

        protected override void OnEnable()
        {
            base.OnEnable();
            OnChangedHelth.Invoke(GetCurrentHealth());
        }

        public override void TakeDamage(int value)
        {
            base.TakeDamage(value);
            OnChangedHelth.Invoke(GetCurrentHealth());
        }

        public void PrintHealth()
        {
            Debug.Log(GetCurrentHealth());
        }
    }
}
