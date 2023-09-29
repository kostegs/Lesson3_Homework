using System;
using System.Collections.Generic;

namespace Factory1.Version1
{
    public class IconFactory : IIconFactory
    {
        private GameMode _gameMode;

        public IconFactory(GameMode gameMode) => _gameMode = gameMode;

        public Icon GetIcon(IconType iconType, IEnumerable<Icon> iconStorage)
        {
            IIconFactory iconFactory;

            switch (_gameMode)
            {
                case GameMode.Menu:
                    iconFactory = new MainMenuIconFactory();
                    return iconFactory.GetIcon(iconType, iconStorage);
                case GameMode.Shop:
                    iconFactory = new ShopIconFactory();
                    return iconFactory.GetIcon(iconType, iconStorage);
                default:
                    throw new ArgumentException(nameof(_gameMode));
            }
        }       
    }
}
