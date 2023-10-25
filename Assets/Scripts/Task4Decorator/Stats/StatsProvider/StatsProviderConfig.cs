using UnityEngine;

namespace Decorator
{
    [CreateAssetMenu(fileName = "StatsProviderConfig", menuName = "DecoratorConfigs/StatsProviderConfig")]
    public class StatsProviderConfig : ScriptableObject
    {
        [SerializeField] RaceConfig _raceConfig;
        [SerializeField] SpecializationConfig _specializationConfig;
        [SerializeField] PassiveAbilityConfig _passiveAbilityConfig;
        [SerializeField] StatsConfig _baseConfig;

        public RaceConfig RaceConfig => _raceConfig;

        public SpecializationConfig SpecializationConfig => _specializationConfig;

        public PassiveAbilityConfig PassiveAbilityConfig => _passiveAbilityConfig;

        public StatsConfig BaseConfig => _baseConfig;
    }
}
