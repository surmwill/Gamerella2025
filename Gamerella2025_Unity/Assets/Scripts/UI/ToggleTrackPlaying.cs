using UnityEngine;

public class ToggleTrackPlaying : MonoBehaviour
{
    public void OnPlayUsersTrackToggled(bool isToggled)
    {
        LevelManager.Instance.CurrentLevel.SetPlayUsersTrackToggled(isToggled);   
    }
}