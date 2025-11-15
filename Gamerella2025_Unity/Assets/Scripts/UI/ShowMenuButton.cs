using UnityEngine;

public class ShowMenuButton : MonoBehaviour
{
    public void ShowMenu(bool isShown)
    {
        LevelManager.Instance.ShowMenu(isShown, true);
    }
}