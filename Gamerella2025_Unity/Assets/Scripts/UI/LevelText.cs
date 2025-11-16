using TMPro;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _levelText = null;

    private void Start()
    {
        _levelText.text = $"Level: {LevelManager.Instance.CurrentLevelIndex + 1}";
    }
}
