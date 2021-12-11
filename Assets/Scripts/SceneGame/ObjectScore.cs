using System;
using UnityEngine;

namespace GameDevLabirinth
{
    public class ObjectScore : MonoBehaviour
    {
        public static event Action<int> OnChanged;

        [SerializeField, Range(10, 1000)]
        private int _score = 10;

        public void Activate()
        {
            OnChanged?.Invoke(_score);
        }
    }
}
