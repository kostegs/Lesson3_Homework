using System;

namespace Visitor
{
    public interface IEnemyDeathNotifier
    {
        event Action<Enemy> Notified;
    }
}
