using System;

namespace Decorator
{
    public class ConfigFactory
    {
        private StatsProviderConfig _config;

        public ConfigFactory(StatsProviderConfig config) => _config = config;

        public StatsConfig GetBaseConfig() => _config.BaseConfig;

        public StatsConfig GetRaceConfig(RaceTypes raceType)
        {
            switch (raceType)
            {
                case RaceTypes.Elf:
                    return _config.RaceConfig.ElfConfig;
                case RaceTypes.Human:
                    return _config.RaceConfig.HumanConfig;
                case RaceTypes.Ork:
                    return _config.RaceConfig.OrkConfig;
                default:
                    throw new ArgumentException(nameof(raceType));
            }
        }

        public StatsConfig GetSpecializationConfig(SpecializationTypes specializationType)
        {
            switch (specializationType)
            {
                case SpecializationTypes.Wizard:
                    return _config.SpecializationConfig.WizardConfig;
                case SpecializationTypes.Barbarian:
                    return _config.SpecializationConfig.BarbarianConfig;
                case SpecializationTypes.Thief:
                    return _config.SpecializationConfig.ThiefConfig;
                default:
                    throw new ArgumentException(nameof(specializationType));
            }
        }

        public StatsConfig GetPassiveAbilityConfig(PassiveAbilityTypes passiveAbilityType)
        {
            switch (passiveAbilityType)
            {
                case PassiveAbilityTypes.IntellectBoost:
                    return _config.PassiveAbilityConfig.IntellectBoost;
                case PassiveAbilityTypes.DexerityBoost:
                    return _config.PassiveAbilityConfig.DexterityBoost;
                case PassiveAbilityTypes.PowerBoost:
                    return _config.PassiveAbilityConfig.PowerBoost;
                default:
                    throw new ArgumentException(nameof(passiveAbilityType));
            }
        }
    }
}
