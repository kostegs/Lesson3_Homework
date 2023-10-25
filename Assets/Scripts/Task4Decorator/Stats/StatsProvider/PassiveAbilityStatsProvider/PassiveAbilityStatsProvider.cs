using System;
using UnityEngine;

namespace Decorator
{
    public class PassiveAbilityStatsProvider : IStatsProvider
    {
        private StatsProviderConfig _config;
        private IStatsProvider _baseStatsProvider;
        private PassiveAbilityTypes _passiveAbilityType;
        private ConfigFactory _configFactory;

        public PassiveAbilityStatsProvider(PassiveAbilityTypes passiveAbilityType, StatsProviderConfig config, IStatsProvider baseStatsProvider)
        {
            _config = config;
            _baseStatsProvider = baseStatsProvider;
            _passiveAbilityType = passiveAbilityType;
            _configFactory = new ConfigFactory(_config);
        }

        public int GetDexterity()
        {
            int dexerity = _baseStatsProvider.GetDexterity();

            StatsConfig statsConfig = _configFactory.GetPassiveAbilityConfig(_passiveAbilityType);

            switch (statsConfig.DexterityMultiplicator)
            {
                case StatsProviderActions.Summ:
                    dexerity += statsConfig.Dexterity;
                    Debug.Log($"Применен конфиг пассивки. Для пассивки {statsConfig.name} добавлена ловкость {statsConfig.Dexterity}");
                    break;
                case StatsProviderActions.Multiply:
                    dexerity *= statsConfig.Dexterity;
                    Debug.Log($"Применен конфиг пассивки. Для пассивки {statsConfig.name} умножена ловкость на {statsConfig.Dexterity}");
                    break;
                default:
                    throw new ArgumentException(nameof(statsConfig.DexterityMultiplicator));
            }

            return dexerity;
        }

        public int GetIntellect()
        {
            int intellect = _baseStatsProvider.GetIntellect();

            StatsConfig statsConfig = _configFactory.GetPassiveAbilityConfig(_passiveAbilityType);

            switch (statsConfig.IntellectMultiplicator)
            {
                case StatsProviderActions.Summ:
                    intellect += statsConfig.Intellect;
                    Debug.Log($"Применен конфиг пассивки. Для пассивки {statsConfig.name} добавлен интеллект {statsConfig.Intellect}");
                    break;
                case StatsProviderActions.Multiply:
                    intellect *= statsConfig.Intellect;
                    Debug.Log($"Применен конфиг пассивки. Для пассивки {statsConfig.name} умножен интеллект на {statsConfig.Intellect}");
                    break;
                default:
                    throw new ArgumentException(nameof(statsConfig.IntellectMultiplicator));
            }

            return intellect;
        }

        public int GetPower()
        {
            int power = _baseStatsProvider.GetPower();

            StatsConfig statsConfig = _configFactory.GetPassiveAbilityConfig(_passiveAbilityType);

            switch (statsConfig.PowerMultiplicator)
            {
                case StatsProviderActions.Summ:
                    power += statsConfig.Power;
                    Debug.Log($"Применен конфиг пассивки. Для пассивки {statsConfig.name} добавлена сила {statsConfig.Power}");
                    break;
                case StatsProviderActions.Multiply:
                    power *= statsConfig.Power;
                    Debug.Log($"Применен конфиг пассивки. Для пассивки {statsConfig.name} умножена сила на {statsConfig.Power}");
                    break;
                default:
                    throw new ArgumentException(nameof(statsConfig.PowerMultiplicator));
            }

            return power;
        }
    }
}
