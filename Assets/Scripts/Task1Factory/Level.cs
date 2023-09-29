using System.Collections.Generic;
using UnityEngine;

namespace Factory.Task1
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameMode _gameMode;

        private PanelUI _panel;
        private List<Icon> _iconStorage;

        public void Initialize(PanelUI panel)
        {
            _panel = panel;
            _iconStorage = _panel.IconStorage;
        }

        [ContextMenu("ChangePanel")]
        public void ShowPanel()
        {
            _panel.Hide();

            IIconFactory iconFactory = new IconFactory(_gameMode);

            List<Icon> icons = new List<Icon>();
            icons.Add(iconFactory.GetIcon(IconType.Coin, _iconStorage));
            icons.Add(iconFactory.GetIcon(IconType.Energy, _iconStorage));

            _panel.Initialize(icons);
            _panel.Show();

        }
    }
}
