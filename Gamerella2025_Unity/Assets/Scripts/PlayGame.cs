using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public void Play()
    {
        LevelManager.Instance.LoadLevelIndex(0);
    }
}
