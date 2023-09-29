using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Factory.Task1
{
    public class PanelUI : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Image _coinImage;
        [SerializeField] private Image _energyImage;
        [SerializeField] private TextMeshProUGUI _coinText;
        [SerializeField] private TextMeshProUGUI _energyText;

        [SerializeField] private List<Icon> _iconStorage;

        public List<Icon> IconStorage => new List<Icon>(_iconStorage);

        public void Initialize(List<Icon> icons)
        {            
            foreach (var icon in icons)
            {
                switch (icon.IconType)
                {
                    case IconType.Coin:
                        SetIcon(_coinImage, _coinText, icon.IconImage, icon.Text);
                        break;
                    case IconType.Energy:
                        SetIcon(_energyImage, _energyText, icon.IconImage, icon.Text);
                        break;
                    default:
                        continue;
                }
            }
        }

        private void SetIcon(Image iconImageElement, TextMeshProUGUI iconTextElement, Sprite iconSprite, string iconText)
        {
            iconImageElement.sprite = iconSprite;
            iconTextElement.text = iconText;
        }

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}



