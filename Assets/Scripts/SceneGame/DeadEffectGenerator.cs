using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    public class DeadEffectGenerator : MonoBehaviour
    {
        private const int EffectCount = 1;

        [SerializeField]
        private ParticleSystem _prefab;

        private List<GameObject> _effects = new List<GameObject>();

        private void Awake()
        {
            for (int i = 0; i < EffectCount; i++)
            {
                Create(_prefab);
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
            GameObject effect = Instantiate(prefab.gameObject, transform);
            _effects.Add(effect);
            return effect;
        }
    }
}
