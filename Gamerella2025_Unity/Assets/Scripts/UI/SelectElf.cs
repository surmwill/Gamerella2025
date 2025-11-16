using System;
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

    [SerializeField]
    private CanvasGroup _canvasGroup = null;

    private const float FadeValue = 0.5f;

    private Level CurrentLevel => LevelManager.Instance.CurrentLevel;

    private void Start()
    {
        UpdateCanAddElfState();
    }

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
        UpdateCanAddElfState();
    }

    private void UpdateCanAddElfState()
    {
        bool hasElf = CurrentLevel.HasElf(_elfPrefab.ElfId);
        
        if (!CurrentLevel.CanFitElf() && !hasElf)
        {
            _canvasGroup.interactable = false;
            _canvasGroup.alpha = FadeValue;
        }
        else
        {
            _canvasGroup.interactable = true;
            _canvasGroup.alpha = 1.0f;
        }
        
        _selectElfButton.targetGraphic = !hasElf ? _addIcon : _deleteIcon;
        _addIcon.gameObject.SetActive(!hasElf);
        _deleteIcon.gameObject.SetActive(hasElf);
    }
}
