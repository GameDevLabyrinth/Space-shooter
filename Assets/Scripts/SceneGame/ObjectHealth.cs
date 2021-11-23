using UnityEngine;
using UnityEngine.Events;

namespace GameDevLabirinth
{
    public class ObjectHealth : MonoBehaviour, IDamageable
    {
        [SerializeField, Range(100, 1000)]
        private int _maxHealth = 200;

        [SerializeField]
        private UnityEvent OnEndedHelth;

        private int _currentHealth;

        protected virtual void OnEnable()
        {
            _currentHealth = _maxHealth;
        }

        protected int GetCurrentHealth()
        {
            return _currentHealth;
        }

        public virtual void TakeDamage(int value)
        {
            _currentHealth -= value;

            if (_currentHealth <= 0)
                //Destroy(gameObject); 
                OnEndedHelth.Invoke();
        }
    }
}
