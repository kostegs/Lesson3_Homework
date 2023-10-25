using System;
using UnityEngine;

namespace Decorator
{
    public class RaceStatsProvider : IStatsProvider
    {
        private StatsProviderConfig _config;
        private IStatsProvider _baseStatsProvider;
        private RaceTypes _raceType;
        private ConfigFactory _configFactory;

        public RaceStatsProvider(RaceTypes raceType, StatsProviderConfig config, IStatsProvider baseStatsProvider)
        {
            _raceType = raceType;
            _config = config;
            _baseStatsProvider = baseStatsProvider;
            _configFactory = new ConfigFactory(_config);
        }

        public int GetDexterity()
        {
            int dexerity = _baseStatsProvider.GetDexterity();

            StatsConfig statsConfig = _configFactory.GetRaceConfig(_raceType);

            switch (statsConfig.DexterityMultiplicator)
            {
                case StatsProviderActions.Summ:
                    dexerity += statsConfig.Dexterity;
                    Debug.Log($"Применен расовый конфиг. Для расы {statsConfig.name} добавлена ловкость {statsConfig.Dexterity}");
                    break;
                case StatsProviderActions.Multiply:
                    dexerity *= statsConfig.Dexterity;
                    Debug.Log($"Применен расовый конфиг. Для расы {statsConfig.name} умножена ловкость на {statsConfig.Dexterity}");
                    break;
                default:
                    throw new ArgumentException(nameof(statsConfig.DexterityMultiplicator));
            }

            return dexerity;
        }

        public int GetIntellect()
        {
            int intellect = _baseStatsProvider.GetIntellect();

            StatsConfig statsConfig = _configFactory.GetRaceConfig(_raceType);

            switch (statsConfig.IntellectMultiplicator)
            {
                case StatsProviderActions.Summ:
                    intellect += statsConfig.Intellect;
                    Debug.Log($"Применен расовый конфиг. Для расы {statsConfig.name} добавлен интеллект {statsConfig.Intellect}");
                    break;
                case StatsProviderActions.Multiply:
                    intellect *= statsConfig.Intellect;
                    Debug.Log($"Применен расовый конфиг. Для расы {statsConfig.name} умножена интеллект на {statsConfig.Intellect}");
                    break;
                default:
                    throw new ArgumentException(nameof(statsConfig.IntellectMultiplicator));
            }

            return intellect;
        }

        public int GetPower()
        {
            int power = _baseStatsProvider.GetPower();

            StatsConfig statsConfig = _configFactory.GetRaceConfig(_raceType);

            switch (statsConfig.PowerMultiplicator)
            {
                case StatsProviderActions.Summ:
                    power += statsConfig.Power;
                    Debug.Log($"Применен расовый конфиг. Для расы {statsConfig.name} добавлена сила {statsConfig.Power}");
                    break;
                case StatsProviderActions.Multiply:
                    power *= statsConfig.Power;
                    Debug.Log($"Применен расовый конфиг. Для расы {statsConfig.name} умножена сила на {statsConfig.Power}");
                    break;
                default:
                    throw new ArgumentException(nameof(statsConfig.PowerMultiplicator));
            }

            return power;
        }        
    }
}
