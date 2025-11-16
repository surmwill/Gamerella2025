using UnityEngine;

public class ShowMenuButton : MonoBehaviour
{
    [SerializeField]
    private bool _showMenuCloseButton = true;
    
    public void ShowMenu(bool isShown)
    {
        LevelManager.Instance.ShowMenu(isShown, _showMenuCloseButton);
    }
}