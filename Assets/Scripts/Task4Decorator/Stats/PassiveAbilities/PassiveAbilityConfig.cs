using UnityEngine;

namespace Decorator
{
    [CreateAssetMenu(fileName = "PassiveAbilityConfig", menuName = "DecoratorConfigs/PassiveAbilityConfig")]
    public class PassiveAbilityConfig : ScriptableObject
    {
        [SerializeField] private StatsConfig _powerBoost;
        [SerializeField] private StatsConfig _intellectBoost;
        [SerializeField] private StatsConfig _dexterityBoost;

        public StatsConfig PowerBoost => _powerBoost;
        public StatsConfig IntellectBoost => _intellectBoost;
        public StatsConfig DexterityBoost => _dexterityBoost;
    }
}
