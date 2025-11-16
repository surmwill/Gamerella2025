using UnityEngine;

public class ValidateTrackButton : MonoBehaviour
{
    [SerializeField]
    private RectTransform _santaUIRoot = null;
    
    [SerializeField]
    private SantaUI _santaUIPrefab = null;
    
    public void ValidateTrack()
    {
        bool isValid = LevelManager.Instance.CurrentLevel.PlayAndValidateTrack();
        SantaUI santaUI = Instantiate(_santaUIPrefab, _santaUIRoot);
        santaUI.ShowSanta(isValid ? SantaUI.SantaState.Happy : SantaUI.SantaState.Angry);
    }
}
