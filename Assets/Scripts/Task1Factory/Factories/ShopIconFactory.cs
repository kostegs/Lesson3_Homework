using System.Collections.Generic;
using System.Linq;

namespace Factory.Task1
{
    public class ShopIconFactory : IIconFactory
    {
        public Icon GetIcon(IconType iconType, IEnumerable<Icon> iconStorage)
        {
            return iconStorage.Where(icon => icon.GameMode == GameMode.Shop && icon.IconType == iconType).FirstOrDefault();
        }
    }
}
