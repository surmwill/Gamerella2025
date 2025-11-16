using UnityEngine;
using UnityEngine.UI;

public class SelectElf : MonoBehaviour
{
    [SerializeField]
    private Elf _elfPrefab = null;

    [SerializeField]
    private Image _addIcon = null;

    [SerializeField]
    private Image _deleteIcon = null;

    [SerializeField]
    private Button _selectElfButton = null;

    private Level CurrentLevel => LevelManager.Instance.CurrentLevel;

    public void AddOrRemoveElf()
    {
        if (CurrentLevel.HasElf(_elfPrefab.ElfId))
        {
            CurrentLevel.RemoveElf(_elfPrefab.ElfId);
        }
        else
        {
            CurrentLevel.AddElf(_elfPrefab);
        }
    }

    private void Update()
    {
        bool canAddElf = !CurrentLevel.HasElf(_elfPrefab.ElfId);
        
        _selectElfButton.targetGraphic = canAddElf ? _addIcon : _deleteIcon;
        _addIcon.gameObject.SetActive(canAddElf);
        _deleteIcon.gameObject.SetActive(!canAddElf);
    }
}
