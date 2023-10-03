using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/MediatorLevelConfig")]
public class GameConfig : ScriptableObject
{
    [SerializeField] private int _startLevel;
    [SerializeField] private int _startPlayerHP;

    public int StartLevel => _startLevel;
    public int StartPlayerHP => _startPlayerHP;
}
