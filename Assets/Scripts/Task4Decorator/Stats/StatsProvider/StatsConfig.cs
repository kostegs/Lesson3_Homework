using UnityEngine;

namespace Decorator
{
    [CreateAssetMenu(fileName = "StatsConfig", menuName = "DecoratorConfigs/StatsConfig")]
    public class StatsConfig : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private int _power;
        [SerializeField] private StatsProviderActions _powerMultiplicator;
        [SerializeField] private int _intellect;
        [SerializeField] private StatsProviderActions _intellectMultiplicator;
        [SerializeField] private int _dexterity;
        [SerializeField] private StatsProviderActions _dexterityMultiplicator;

        public string Name => _name;
        public int Power => _power;
        public int Intellect => _intellect;
        public int Dexterity => _dexterity;
        public StatsProviderActions PowerMultiplicator => _powerMultiplicator;
        public StatsProviderActions IntellectMultiplicator => _intellectMultiplicator;
        public StatsProviderActions DexterityMultiplicator => _dexterityMultiplicator;
    }
}
