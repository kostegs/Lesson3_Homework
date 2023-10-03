public class MediatorUI
{
    private Hud _hud;
    private Player _player;
    private Level _level;

    public MediatorUI(Hud hud, Player player, Level level)
    {
        _hud = hud;
        _player = player;
        _level = level;
        
        _player.HPChanged += OnHpChanged;
        _level.LevelChanged += OnLevelChanged;
        _hud.ButtonRestartClicked += OnRestartClicked;
    }

    ~MediatorUI() => Destruct();

    public void Destruct()
    {
        _player.HPChanged -= OnHpChanged;
        _level.LevelChanged -= OnLevelChanged;
    }

    private void OnLevelChanged(int level)
    {
        if (level > 0) 
            _hud.SetLevelText(level);
    }

    private void OnHpChanged(int hp)
    {
        if (hp < 0)
        {
            _player.HPChanged -= OnHpChanged;
            _level.LevelChanged -= OnLevelChanged;
            _hud.ShowRestartButton(true);
        }            
        else
            _hud.SetHPText(hp);
    }  

    private void OnRestartClicked()
    {
        _player.HPChanged += OnHpChanged;
        _level.LevelChanged += OnLevelChanged;
        _player.SetDefaultHP();
        _level.SetDefaultLevel();
    }


}
