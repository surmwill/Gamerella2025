using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _closeButton = null;

    public void Show(bool isShown, bool showClose = false)
    {
        gameObject.SetActive(isShown);
        _closeButton.SetActive(showClose);
    }
}
