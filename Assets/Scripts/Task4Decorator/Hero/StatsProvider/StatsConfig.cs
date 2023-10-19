using UnityEngine;

[CreateAssetMenu(fileName = "StatsConfig", menuName = "DecoratorConfigs/StatsConfig")]
public class StatsConfig : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _power;
    [SerializeField] private int _intellect;
    [SerializeField] private int _dexterity;
    [SerializeField] private StatsProviderActions _mulitiplicator;

    public string Name => _name;
    public int Power => _power;
    public int Intellect => _intellect;
    public int Dexterity => _dexterity;
    public StatsProviderActions Multiplicator => _mulitiplicator;
}
