using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    public class DeadEffectGenerator : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _prefab;

        private List<GameObject> _effects = new List<GameObject>();

        private void Awake()
        {
            for (int i = 0; i < 5; i++)
            {
                _effects.Add(Create(_prefab));
            }
        }

        private void OnDisable()
        {
            DeadEffect.OnObjectDestroyed -= DeadEffect_OnObjectDestroyed;
        }
        private void OnEnable()
        {
            DeadEffect.OnObjectDestroyed += DeadEffect_OnObjectDestroyed;
        }

        private void DeadEffect_OnObjectDestroyed(Transform obj)
        {
            GameObject effect = GetFreeEffect();
            effect.transform.position = obj.position;
            effect.SetActive(true);
        }

        private GameObject GetFreeEffect()
        {
            foreach (var item in _effects)
            {
                if (item.activeInHierarchy != true)
                    return item;
            }

            return Create(_prefab);
        }

        private GameObject Create(ParticleSystem prefab)
        {
            return Instantiate(prefab.gameObject, transform);
        }
    }
}
