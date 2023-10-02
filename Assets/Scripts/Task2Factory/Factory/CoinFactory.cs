using System;
using UnityEngine;

[CreateAssetMenu(fileName ="Coin factory config", menuName = "Configs/Factories")]
public class CoinFactory : ScriptableObject
{
    [SerializeField] private CoinConfig _redCoin, _greenCoin, _blueCoin;

    public Coin GetCoin(CoinType coinType)
    {
        switch (coinType)
        {
            case CoinType.RedCoin:
                return Instantiate(_redCoin.Prefab);
            case CoinType.GreenCoin:
                return Instantiate (_greenCoin.Prefab);
            case CoinType.BlueCoin:
                return Instantiate(_blueCoin.Prefab);
            default:
                throw new ArgumentException(nameof(coinType));
        }
    }
}
