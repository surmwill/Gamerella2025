using UnityEngine;
using UnityEngine.UI;

public class ValidateTrackButton : MonoBehaviour
{
    [SerializeField]
    private RectTransform _santaUIRoot = null;
    
    [SerializeField]
    private SantaUI _santaUIPrefab = null;
    
    [SerializeField]
    private Toggle _isPlayerUsersTrackToggle = null;
    
    public void ValidateTrack()
    {
        _isPlayerUsersTrackToggle.isOn = true;
        SantaUI santaUI = Instantiate(_santaUIPrefab, _santaUIRoot);
        santaUI.ShowSanta(LevelManager.Instance.CurrentLevel.HasValidUserTrack() ? SantaUI.SantaState.Happy : SantaUI.SantaState.Angry);
    }
}
