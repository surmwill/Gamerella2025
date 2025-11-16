using UnityEngine;
using UnityEngine.UI;

public class SelectElf : MonoBehaviour
{
    [SerializeField]
    private Elf _elfPrefab = null;

    [SerializeField]
    private Button _selectElfButton = null;

    public void AddElf()
    {
        if (LevelManager.Instance.CurrentLevel.CanAddElf(_elfPrefab.ElfId))
        {
            LevelManager.Instance.CurrentLevel.AddElf(_elfPrefab);
        }
    }

    private void Update()
    {
        _selectElfButton.interactable = LevelManager.Instance.CurrentLevel.CanAddElf(_elfPrefab.ElfId);
    }
}
