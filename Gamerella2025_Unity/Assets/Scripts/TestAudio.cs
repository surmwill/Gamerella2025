using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class TestAudio : MonoBehaviour
{
    [SerializeField]
    private EventReference _event;

    private EventInstance _eventInstance;

    private void Start()
    {
        _eventInstance = RuntimeManager.CreateInstance(_event);
        RuntimeManager.AttachInstanceToGameObject(_eventInstance, transform);
        _eventInstance.start();
    }

    private void OnDestroy()
    {
        _eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _eventInstance.release();
    }
}
