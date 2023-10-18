using UnityEngine;

namespace Visitor
{
    public abstract class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Score { get; private set; }
        [field: SerializeField] public int Weight { get; private set; }
    }
}