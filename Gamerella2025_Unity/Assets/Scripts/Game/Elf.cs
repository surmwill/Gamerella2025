using FMOD.Studio;
using FMODUnity;
using Game;
using UnityEngine;

public class Elf : MonoBehaviour
{
    [SerializeField]
    private ElfId _elfId = default;

    [SerializeField]
    private EventReference _sound = default;

    public ElfId ElfId => _elfId;

    private EventInstance _soundInstance;

    public void SetVolume(float volume)
    {
        _soundInstance.setVolume(volume);
    }

    public void PlaySound()
    {
        _soundInstance = RuntimeManager.CreateInstance(_sound);
        RuntimeManager.AttachInstanceToGameObject(_soundInstance, transform);
        _soundInstance.start();
    }

    public void StopSound()
    {
        _soundInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        _soundInstance.release();
    }

    private void OnDestroy()
    {
        StopSound();
    }
}
