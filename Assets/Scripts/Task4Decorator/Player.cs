using UnityEngine;

namespace Decorator
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private RaceTypes _race;
        [SerializeField] private PassiveAbilityTypes _passiveAbility;
        [SerializeField] private SpecializationTypes _specialization;

        private int _dexerity, _intellect, _power;
        private StatsProviderConfig _config;

        public void Initialize(StatsProviderConfig config) => _config = config;

        [ContextMenu("ChangeStats")]
        public void ChangeCharacteristics()
        {
            IStatsProvider baseStatsProvider = new BaseStatsProvider(_config);
            IStatsProvider raceStatsProvider = new RaceStatsProvider(_race, _config, baseStatsProvider);
            IStatsProvider specializationStatsProvider = new SpecializationStatsProvider(_specialization, _config, raceStatsProvider);
            IStatsProvider passiveAbilityStatsProvider = new PassiveAbilityStatsProvider(_passiveAbility, _config, specializationStatsProvider);

            _dexerity = Mathf.Clamp(passiveAbilityStatsProvider.GetDexterity(), 1, int.MaxValue);
            _intellect = Mathf.Clamp(passiveAbilityStatsProvider.GetIntellect(), 1, int.MaxValue);
            _power = Mathf.Clamp(passiveAbilityStatsProvider.GetPower(), 1, int.MaxValue);

            Debug.Log("Конечные показатели:");
            Debug.Log($"Ловкость: {_dexerity}");
            Debug.Log($"Интеллект: {_intellect}");
            Debug.Log($"Сила: {_power}");
        }
    }
}
