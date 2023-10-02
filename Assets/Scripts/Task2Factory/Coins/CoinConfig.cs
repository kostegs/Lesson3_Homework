using UnityEngine;

[CreateAssetMenu(fileName = "CoinsConfig", menuName = "Configs/Coins")]
public class CoinConfig : ScriptableObject
{
    [field: SerializeField] public Coin Prefab { get; private set; }
}
