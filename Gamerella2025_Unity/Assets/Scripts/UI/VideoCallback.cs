using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoCallback : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer _videoPlayer = null;

    [SerializeField]
    private UnityEvent _onComplete = null;
    
    private void Start()
    {
        _videoPlayer.loopPointReached += OnComplete;
    }

    private void OnDestroy()
    {
        _videoPlayer.loopPointReached -= OnComplete;
    }

    private void OnComplete(VideoPlayer videoPlayer)
    {
        _onComplete?.Invoke();
    }
}
