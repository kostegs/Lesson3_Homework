using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Visitor
{
    public class Spawner : MonoBehaviour, IEnemyDeathNotifier
    {
        public event Action<EnemyConfig> Notified;

        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private List<EnemyConfig> _objectsForSpawn;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();

        private Coroutine _spawn;        

        public void StartWork()
        {
            StopWork();

            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        public void KillRandomEnemy()
        {
            if (_spawnedEnemies.Count <= 0)
                return;

            _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Kill();
        }

        public IEnumerator Spawn()
        {
            while (true)
            {
                EnemyConfig config = _objectsForSpawn[UnityEngine.Random.Range(0, _objectsForSpawn.Count)];
                Enemy enemy = _enemyFactory.Get(config); 
                enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                enemy.Died += OnEnemyDied;
                _spawnedEnemies.Add(enemy); 

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            Notified?.Invoke(enemy.Config);
            enemy.Died -= OnEnemyDied;
            _spawnedEnemies.Remove(enemy);
        }
    }
}
