using DG.Tweening;
using UnityEngine;

public class SantaUI : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _backgroundFade = null;

    [SerializeField]
    private RectTransform _santaStartPosition = null;

    [SerializeField]
    private RectTransform _santaEndPosition = null;

    [SerializeField]
    private RectTransform _happySanta = null;

    [SerializeField]
    private RectTransform _angrySanta = null;

    private const float FadeInTime = 0.4f;
    private const float SlideInTime = 0.6f;

    public void ShowSanta(SantaState santaState)
    {
        _happySanta.gameObject.SetActive(santaState == SantaState.Happy);
        _angrySanta.gameObject.SetActive(santaState == SantaState.Angry);

        RectTransform santaTransform = null;
        switch (santaState)
        {
            case SantaState.Happy:
                santaTransform = _happySanta;
                break;
            
            case SantaState.Angry:
                santaTransform = _angrySanta;
                break;
        }

        santaTransform.position = _santaStartPosition.transform.position;
        
        float fadeToAlpha = _backgroundFade.alpha;
        _backgroundFade.alpha = 0f;
        
        DOTween.Sequence()
            .Append(_backgroundFade.DOFade(fadeToAlpha, FadeInTime).SetEase(Ease.OutQuad))
            .Append(santaTransform.DOMove(_santaEndPosition.transform.position, SlideInTime).SetEase(Ease.OutQuad));
    }

    public void CloseAndRetry()
    {
        Destroy(gameObject);
    }

    public void NextLevel()
    {
        LevelManager.Instance.LoadNextLevel();
    }

    public enum SantaState
    {
        Normal = 0,
        Happy = 1,
        Angry = 2,
    }
}
