using UnityEngine;

namespace Visitor
{
    public abstract class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public int Score { get; private set; }
    }
}