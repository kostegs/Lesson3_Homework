using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private List<SpawnPoint> _freePoints;
    private CoinFactory _coinFactory;
    private int _coinTypesCount;
    private Coroutine _spawnCoroutine;
        
    public void Initialize(CoinFactory coinFactory)
    {
        _freePoints = new List<SpawnPoint>(_spawnPoints);        
        _coinFactory = coinFactory;
        _coinTypesCount = Enum.GetValues(typeof(CoinType)).Length;        
    }

    public void StartSpawn() => _spawnCoroutine = StartCoroutine(SpawnCoin());

    public void StopSpawn() => StopCoroutine(_spawnCoroutine);

    private IEnumerator SpawnCoin()
    {
        while (CheckSpawnAbility() == true)
        {
            Coin coin = _coinFactory.GetCoin(GetRandomCoinType());

            int randomIndex = UnityEngine.Random.Range(0, _freePoints.Count);
            coin.transform.position = _freePoints[randomIndex].transform.position;
            _freePoints.RemoveAt(randomIndex);

            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private CoinType GetRandomCoinType()
    {
        return (CoinType)UnityEngine.Random.Range(0, _coinTypesCount);
    }

    private bool CheckSpawnAbility() => _freePoints.Count > 0;
}
