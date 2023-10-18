using UnityEngine;

namespace Visitor
{
    public class Elf : Enemy
    {
        [SerializeField] public ElfConfig _config;

        public override EnemyConfig Config => _config;
    }
}
