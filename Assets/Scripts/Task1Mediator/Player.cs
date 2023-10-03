using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action<int> HPChanged;
    
    private PlayerInput _input;
    private int _hP;
    private GameConfig _gameConfig;

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    private void OnDestroy()
    {
        _input.PlayerControls.IncreaseHP.started -= OnHPIncreased;
        _input.PlayerControls.DecreaseHP.started -= OnHPDecreased;        
    }  

    public void Initialize(PlayerInput input, GameConfig gameConfig)
    {
        _input = input;
        _input.PlayerControls.IncreaseHP.started += OnHPIncreased;
        _input.PlayerControls.DecreaseHP.started += OnHPDecreased;

        _gameConfig = gameConfig;
        SetDefaultHP();
    }

    public void SetDefaultHP()
    {
        _hP = _gameConfig.StartPlayerHP;
        HPChanged?.Invoke(_hP);
    }

    private void OnHPIncreased(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _hP++;
        HPChanged?.Invoke(_hP);
    }

    private void OnHPDecreased(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _hP--;
        HPChanged?.Invoke(_hP);
    }    
}
