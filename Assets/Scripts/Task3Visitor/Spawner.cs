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
        [SerializeField] private int _maxWeight;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();

        private Coroutine _spawn;
        private int _weight;
        private EnemyVisitor _enemyVisitor;

        public void Initialize() => _enemyVisitor = new EnemyVisitor();

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
                
                _enemyVisitor.Visit(config);

                if (_enemyVisitor.Weight + _weight > _maxWeight)
                {
                    Debug.Log($"{config.Name} has weight: {_enemyVisitor.Weight}. Total weight is {_enemyVisitor.Weight + _weight}. It's more than max weight. Spawn is unreachable");
                }
                else
                {
                    Enemy enemy = _enemyFactory.Get(config);
                    enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                    enemy.Died += OnEnemyDied;
                    _spawnedEnemies.Add(enemy);
                    _weight += _enemyVisitor.Weight;

                    Debug.Log($"{config.Name} is spawned. Current Weight: {_weight}");
                }                

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            Notified?.Invoke(enemy.Config);
            enemy.Died -= OnEnemyDied;
            _enemyVisitor.Visit(enemy.Config);
            _weight -= _enemyVisitor.Weight;
            _spawnedEnemies.Remove(enemy);
        }

        private class EnemyVisitor : IEnemyVisitor
        {
            public int Weight { get; private set; }

            public void Visit(OrkConfig orkConfig) => Weight = orkConfig.Weight;
            
            public void Visit(HumanConfig humanConfig) => Weight = humanConfig.Weight;
            
            public void Visit(ElfConfig elfConfig) => Weight = elfConfig.Weight;            

            public void Visit(EnemyConfig enemyConfig) => Visit((dynamic)enemyConfig);            
        }
    }
}
