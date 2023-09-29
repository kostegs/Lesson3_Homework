using System;
using UnityEngine;

namespace Factory.Task1
{
    [Serializable]
    public class IconStorage
    {
        [SerializeField] private Icon _coinMainMenu;
        [SerializeField] private Icon _coinShop;
        [SerializeField] private Icon _energyMainMenu;
        [SerializeField] private Icon _energyShop;

        public Icon CoinMainMenu => _coinMainMenu;
        public Icon CoinShop => _coinShop;
        public Icon EnergyMainMenu => _energyMainMenu;
        public Icon EnergyShop => _energyShop;
    }
}
