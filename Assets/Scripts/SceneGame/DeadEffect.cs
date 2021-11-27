using System;
using UnityEngine;

namespace GameDevLabirinth
{
    public class DeadEffect : MonoBehaviour
    {
        public static event Action<Transform> OnObjectDestroyed;

        public void Activate()
        {
            OnObjectDestroyed?.Invoke(transform);
        }
    }
}
