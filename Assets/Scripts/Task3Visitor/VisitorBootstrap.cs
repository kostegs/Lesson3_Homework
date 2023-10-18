using UnityEngine;

namespace Visitor
{
    public class VisitorBootstrap : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;

        private Score _score;

        private void Awake()
        {
            _score = new Score(_spawner);
            _spawner.Initialize();
            _spawner.StartWork();
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
                _spawner.KillRandomEnemy();
        }
    }
}
