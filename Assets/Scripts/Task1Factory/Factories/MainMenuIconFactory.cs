using System.Collections.Generic;
using System.Linq;

namespace Factory1.Version1
{
    public class MainMenuIconFactory : IIconFactory
    {
        public Icon GetIcon(IconType iconType, IEnumerable<Icon> iconStorage)
        {
            return iconStorage.Where(icon => icon.GameMode == GameMode.Menu && icon.IconType == iconType).FirstOrDefault();            
        }
    }
}
