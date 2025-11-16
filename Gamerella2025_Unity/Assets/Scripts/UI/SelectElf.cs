using UnityEngine;
using UnityEngine.UI;

public class SelectElf : MonoBehaviour
{
    [SerializeField]
    private Elf _elfPrefab = null;

    [SerializeField]
    private Image _selectIcon = null;

    [SerializeField]
    private Image _deleteIcon = null;

    [SerializeField]
    private Button _selectElfButton = null;

    public void AddElf()
    {
        if (LevelManager.Instance.CurrentLevel.CanAddElf(_elfPrefab.ElfId))
        {
            LevelManager.Instance.CurrentLevel.AddElf(_elfPrefab);
        }
    }

    public void RemoveElf()
    {
        
    }

    private void Update()
    {
        bool canAddElf = LevelManager.Instance.CurrentLevel.CanAddElf(_elfPrefab.ElfId);

        _selectElfButton.interactable = canAddElf;
        _selectElfButton.targetGraphic = canAddElf ? _selectIcon : _deleteIcon;
        
        _selectElfButton.interactable = LevelManager.Instance.CurrentLevel.CanAddElf(_elfPrefab.ElfId);
    }
}
