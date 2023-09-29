using UnityEngine;

namespace Factory.Task1
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Level _level;
        [SerializeField] private PanelUI _panel;

        private void Awake() => _level.Initialize(_panel);
    }
}
