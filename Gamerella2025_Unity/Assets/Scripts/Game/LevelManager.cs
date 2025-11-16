using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField]
    private MainMenu _mainMenu = null;

    [SerializeField]
    private GameObject _endScreen = null;
    
    [SerializeField]
    private Transform _levelRoot = null;
    
    [SerializeField]
    private Level[] _levelPrefabs = null;

    [SerializeField]
    private Transform _levelUIRoot = null;

    [SerializeField]
    private RectTransform[] _levelUIPrefabs = null;

    public int CurrentLevelIndex { get; private set; } = -1;
    
    public Level CurrentLevel { get; private set; }
    
    private RectTransform _currentUI;

    protected override void Awake()
    {
        base.Awake();
        
        ShowMenu(true);
        ShowEndScreen(false);
    }

    public void LoadNextLevel()
    {
        int nextLevelIndex = CurrentLevelIndex + 1;
        if (nextLevelIndex >= _levelPrefabs.Length)
        {
            CleanupCurrentLevel();
            ShowEndScreen(true);
        }
        else
        {
            LoadLevelIndex(nextLevelIndex);
        }
    }

    public void LoadLevelIndex(int indexLevel)
    {
        CleanupCurrentLevel();
        ShowMenu(false);
        
        CurrentLevelIndex = indexLevel;
        _mainMenu.Show(false);
        
        CurrentLevel = Instantiate(_levelPrefabs[indexLevel], _levelRoot);
        _currentUI = Instantiate(_levelUIPrefabs[indexLevel], _levelUIRoot);
    }

    public void CleanupCurrentLevel()
    {
        if (CurrentLevelIndex == -1)
        {
            return;
        }
        CurrentLevelIndex = -1; 
        
        Destroy(CurrentLevel.gameObject);
        Destroy(_currentUI.gameObject);
    }

    public void ShowEndScreen(bool isShown)
    {
        _endScreen.SetActive(isShown);
    }

    public void ShowMenu(bool isShown, bool showClose = false)
    {
        ShowEndScreen(false);
        _mainMenu.Show(isShown, showClose);
    }
}