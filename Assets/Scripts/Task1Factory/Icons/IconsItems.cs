namespace Factory.Task1
{
    public class IconsItems
    {
        private Icon _coinIcon;
        private Icon _energyIcon;

        public IconsItems(Icon coinIcon, Icon energyIcon)
        {
            _coinIcon = coinIcon;
            _energyIcon = energyIcon;
        }

        public Icon CoinIcon => _coinIcon;
        public Icon EnergyIcon => _energyIcon;
    }
}
