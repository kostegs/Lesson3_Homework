using UnityEngine;

namespace Decorator
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private StatsProviderConfig _statsProviderConfig;
        [SerializeField] private Player _player;

        private void Awake()
        {
            _player.Initialize(_statsProviderConfig);
        }
    }
}
