using System;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Action<int> LevelChanged;

    private PlayerInput _input;
    private int _levelNumber;
    private GameConfig _gameConfig;

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    private void OnDestroy()
    {
        _input.LevelControls.IncreaseLevel.started -= OnLevelIncreased;
        _input.LevelControls.DecreaseLevel.started -= OnLevelDecreased;
    }

    public void Initialize(PlayerInput input, GameConfig gameConfig)
    {
        _input = input;
        _input.LevelControls.IncreaseLevel.started += OnLevelIncreased;
        _input.LevelControls.DecreaseLevel.started += OnLevelDecreased;

        _gameConfig = gameConfig;
        SetDefaultLevel();
    }

    public void SetDefaultLevel()
    {
        _levelNumber = _gameConfig.StartLevel;
        LevelChanged?.Invoke(_levelNumber);
    }

    private void OnLevelIncreased(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _levelNumber++;
        LevelChanged?.Invoke(_levelNumber);
    }

    private void OnLevelDecreased(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (_levelNumber > 1)
        {
            _levelNumber--;
            LevelChanged?.Invoke(_levelNumber);
        }        
    }
}
