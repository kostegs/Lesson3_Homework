using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] Level _level;
    [SerializeField] Hud _hud;
    [SerializeField] GameConfig _gameConfig;

    private MediatorUI _mediatorUI;

    private void Awake()
    {
        _mediatorUI = new MediatorUI(_hud, _player, _level);

        PlayerInput input = new PlayerInput();
        _player.Initialize(input, _gameConfig);
        _level.Initialize(input, _gameConfig);
        _hud.Initialize();

        _player.gameObject.SetActive(true);
        _level.gameObject.SetActive(true);        
    }

    private void OnDestroy() => _mediatorUI.Destruct();
}
