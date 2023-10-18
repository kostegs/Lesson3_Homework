using UnityEngine;

namespace Visitor
{
    public class Human : Enemy
    {
        [SerializeField] public HumanConfig _config;

        public override EnemyConfig Config => _config;
    }
}
