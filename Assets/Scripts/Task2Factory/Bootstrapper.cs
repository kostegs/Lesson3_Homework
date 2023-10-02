using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private CoinFactory _coinFactory;
    [SerializeField] private Spawner _spawner;

    private void Awake()
    {
        _spawner.Initialize(_coinFactory);
        _spawner.StartSpawn();
    }
}
