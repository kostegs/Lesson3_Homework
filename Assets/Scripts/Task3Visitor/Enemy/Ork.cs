using UnityEngine;

namespace Visitor
{
    public class Ork : Enemy
    {
        [SerializeField] public OrkConfig _config;

        public override EnemyConfig Config => _config;
    }
}
