using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevLabirinth
{
    public class EnemyWaves : MonoBehaviour
    {
        private LevelData _level;
        private int _indexWave;
        private int _indexEnemy;

        private List<GameObject> _enemies = new List<GameObject>();

        private void Awake()
        {
            int index = new LevelNameData().GetLevelIndex();
            _level = Resources.Load<LevelData>($"Levels/Level{index}");
        }

        public void Generate()
        {
            foreach (var wave in _level.Waves)
            {
                for (int i = 0; i < wave.CountInWave; i++)
                {
                    var enemy = Instantiate(wave.EnemyPrefab, transform);
                    enemy.SetActive(false);
                    _enemies.Add(enemy);
                }
            }
        }

        public void Activate()
        {
            StartCoroutine(EnemyActivate());
        }


        private IEnumerator EnemyActivate()
        {
            WaitForSeconds wait = new WaitForSeconds(0.5f);
            var count = _level.Waves[_indexWave].CountInWave;

            while (count > 0)
            {
                count--;
                _enemies[_indexEnemy].gameObject.SetActive(true);
                _indexEnemy++;
                yield return wait;
            }

            if (_indexWave < _level.Waves.Count - 1)
            {
                Invoke(nameof(Activate), _level.Waves[_indexWave].WaitAfterWave);
                _indexWave++;
            }
        }

    }
}
