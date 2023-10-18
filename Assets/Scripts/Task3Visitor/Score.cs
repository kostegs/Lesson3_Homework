using System;
using UnityEngine;

namespace Visitor
{
    public class Score
    {
        private IEnemyDeathNotifier _enemyDeathNotifier;
        private EnemyVisitor _enemyVisitor;

        public Score(IEnemyDeathNotifier enemyDeathNotifier)
        {
            _enemyDeathNotifier = enemyDeathNotifier;
            _enemyDeathNotifier.Notified += OnEnemyKilled;

            _enemyVisitor = new EnemyVisitor();
        }

        ~Score() => _enemyDeathNotifier.Notified -= OnEnemyKilled;

        public int Value => _enemyVisitor.Score;

        public void OnEnemyKilled(EnemyConfig enemyConfig)
        {
            _enemyVisitor.Visit(enemyConfig);
            Debug.Log($"—чет: {Value}");
        }
        
        private class EnemyVisitor : IEnemyVisitor
        {
            public int Score { get; private set; }

            public void Visit(OrkConfig orkConfig) => Score += orkConfig.Score;

            public void Visit(HumanConfig humanConfig) => Score += humanConfig.Score;
            
            public void Visit(ElfConfig elfConfig) => Score += elfConfig.Score;

            public void Visit(EnemyConfig enemyConfig) => Visit((dynamic)enemyConfig);                 
            
        }
    }
}
