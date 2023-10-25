using UnityEngine;

namespace Decorator
{
    [CreateAssetMenu(fileName = "SpecializationConfig", menuName = "DecoratorConfigs/SpecializationConfig")]
    public class SpecializationConfig : ScriptableObject
    {
        [SerializeField] private StatsConfig _thiefConfig;
        [SerializeField] private StatsConfig _wizardConfig;
        [SerializeField] private StatsConfig _barbarianConfig;

        public StatsConfig ThiefConfig => _thiefConfig;
        public StatsConfig WizardConfig => _wizardConfig;
        public StatsConfig BarbarianConfig => _barbarianConfig;
    }
}
