using System;
using UnityEngine;

namespace Visitor
{
    [CreateAssetMenu(fileName = "VisitorEnemyFactory", menuName = "Factory/VisitorEnemyFactory")]
    public class EnemyFactory : ScriptableObject
    {
        [SerializeField] private Human _humanPrefab;
        [SerializeField] private Ork _orkPrefab;
        [SerializeField] private Elf _elfPrefab;

        public Enemy Get(EnemyConfig enemyConfig)
        {
            switch (enemyConfig)
            {
                case ElfConfig:
                    return Instantiate(_elfPrefab);

                case HumanConfig: 
                    return Instantiate(_humanPrefab);

                case OrkConfig: 
                    return Instantiate(_orkPrefab);

                default:
                    throw new ArgumentException(nameof(enemyConfig));
            }
        }
    }
}
