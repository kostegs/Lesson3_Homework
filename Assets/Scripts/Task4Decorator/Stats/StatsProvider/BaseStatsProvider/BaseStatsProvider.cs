using UnityEngine;

namespace Decorator
{
    public class BaseStatsProvider : IStatsProvider
    {
        private StatsProviderConfig _config;
        private ConfigFactory _configFactory;

        public BaseStatsProvider(StatsProviderConfig Config)
        {
            _config = Config;
            _configFactory = new ConfigFactory(_config);
        }  

        public int GetDexterity()
        {
            StatsConfig statsConfig = _configFactory.GetBaseConfig();
            int dexerity = statsConfig.Dexterity;

            Debug.Log($"�������� ������� ������. ��������� ��������� �������� {dexerity}");

            return dexerity;
        }

        public int GetIntellect()
        {
            StatsConfig statsConfig = _configFactory.GetBaseConfig();
            int intellect = statsConfig.Intellect;            

            Debug.Log($"�������� ������� ������. ��������� �������� ��������� {intellect}");

            return intellect;
        }

        public int GetPower()
        {
            StatsConfig statsConfig = _configFactory.GetBaseConfig();
            int power = statsConfig.Power;            

            Debug.Log($"�������� ������� ������. ��������� ��������� ���� {power}");

            return power;
        }
    }
}
