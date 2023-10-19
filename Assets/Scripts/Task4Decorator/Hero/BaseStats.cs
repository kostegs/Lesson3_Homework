using UnityEngine;

[CreateAssetMenu(fileName = "BaseStats", menuName = "DecoratorConfigs/BaseStats")]
public class BaseStats : ScriptableObject
{
    [SerializeField] int _power;
    [SerializeField] int _intellect;
    [SerializeField] int _dexerity;

    public int Power => _power;
    public int Intellect => _intellect;
    public int Dexerity => _dexerity;

}
