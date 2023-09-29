using UnityEngine;

namespace Factory.Task1
{
    [CreateAssetMenu(fileName = "IconCfg", menuName = "Resources/Icons")]
    public class Icon : ScriptableObject
    {
        [SerializeField] private IconType _iconType;
        [SerializeField] private GameMode _gameMode;
        [SerializeField] private Sprite _iconImage;
        [SerializeField] private string _text;

        public Sprite IconImage => _iconImage;
        public string Text => _text;
        public IconType IconType => _iconType;
        public GameMode GameMode => _gameMode;
    }
}
