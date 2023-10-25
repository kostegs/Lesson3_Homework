using UnityEngine;

namespace Decorator
{
    [CreateAssetMenu(fileName = "RacesConfig", menuName = "DecoratorConfigs/RacesConfig")]
    public class RaceConfig : ScriptableObject
    {
        [SerializeField] private StatsConfig _orkConfig;
        [SerializeField] private StatsConfig _elfConfig;
        [SerializeField] private StatsConfig _humanConfig;

        public StatsConfig OrkConfig => _orkConfig;
        public StatsConfig ElfConfig => _elfConfig;
        public StatsConfig HumanConfig => _humanConfig;
    }
}
