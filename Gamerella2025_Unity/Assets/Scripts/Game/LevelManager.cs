using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private MainMenu _mainMenu = null;
    
    [SerializeField]
    private Transform _levelRoot = null;
    
    [SerializeField]
    private Level[] _levelPrefabs = null;

    [SerializeField]
    private Transform _levelUIRoot = null;

    [SerializeField]
    private RectTransform[] _levelUiPrefabs = null;

    public int CurrentLevelIndex { get; private set; } = -1;
    
    private Level _currentLevel;
    private RectTransform _currentUI;

    protected override void Awake()
    {
        base.Awake();
        ShowMenu(true);
    }

    public void LoadLevelIndex(int indexLevel)
    {
        CleanupCurrentLevel();
        ShowMenu(false);
        
        CurrentLevelIndex = indexLevel;
        _mainMenu.Show(false);
        
        _currentLevel = Instantiate(_levelPrefabs[indexLevel], _levelRoot);
        _currentUI = Instantiate(_levelUiPrefabs[indexLevel], _levelUIRoot);
    }

    public void CleanupCurrentLevel()
    {
        if (CurrentLevelIndex == -1)
        {
            return;
        }
        CurrentLevelIndex = -1; 
        
        Destroy(_currentLevel.gameObject);
        Destroy(_currentUI.gameObject);
    }

    public void ShowMenu(bool isShown, bool showClose = false)
    {
        _mainMenu.Show(isShown, showClose);
    }
}