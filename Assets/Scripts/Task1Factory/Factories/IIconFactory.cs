using System.Collections.Generic;

namespace Factory.Task1
{
    public interface IIconFactory
    {
        Icon GetIcon(IconType iconType, IEnumerable<Icon> iconStorage);
    }
}
