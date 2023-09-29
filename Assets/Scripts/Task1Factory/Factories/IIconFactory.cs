using System.Collections.Generic;

namespace Factory1.Version1
{
    public interface IIconFactory
    {
        Icon GetIcon(IconType iconType, IEnumerable<Icon> iconStorage);
    }
}
