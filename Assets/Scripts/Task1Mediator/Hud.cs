using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Button _restartButton;

    public Action ButtonRestartClicked;

    public void OnDestroy() => _restartButton.onClick.RemoveAllListeners();

    public void Initialize() => _restartButton.onClick.AddListener(OnRestartClick);

    public void SetHPText(int hp) => _hpText.text = $"HP: {hp}";

    public void SetLevelText(int level) => _levelText.text = $"Level: {level}";

    public void ShowRestartButton(bool state) => _restartButton.gameObject.SetActive(state);

    private void OnRestartClick()
    {
        ShowRestartButton(false);
        ButtonRestartClicked?.Invoke();
    }  
}
