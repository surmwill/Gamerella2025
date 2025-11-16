using System.Collections.Generic;
using System.Linq;
using FMOD.Studio;
using FMODUnity;
using Game;
using UnityEngine;
using UnityEngine.UI;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Transform[] _positions = null;

    [SerializeField]
    private ElfId[] _requiredElves = null;

    [SerializeField]
    private EventReference _targetTrackEvent = default;

    private readonly List<Elf> _elves = new();

    private EventInstance _targetTrackInstance;

    private bool _isPlayingUsersTrack;
    
    private void Start()
    {
        _targetTrackInstance = RuntimeManager.CreateInstance(_targetTrackEvent);
        RuntimeManager.AttachInstanceToGameObject(_targetTrackInstance, transform);
        _targetTrackInstance.start();

        SetPlayUsersTrackToggled(false);
    }

    public bool HasElf(ElfId elfId)
    {
        return _elves.Any(elf => elf.ElfId == elfId);
    }

    public void RemoveElf(ElfId elfId)
    {
        StopUserTrack();
        
        Elf elf = _elves.FirstOrDefault(elf => elf.ElfId == elfId);
        if (elf != null)
        {
            Destroy(elf.gameObject);
            _elves.Remove(elf);   
        }
        
        PlayUserTrack();
    }

    public void AddElf(Elf elfPrefab)
    {
        StopUserTrack();
        
        Transform nextOpenPosition = GetNextOpenPosition();
        if (nextOpenPosition != null)
        {
            _elves.Add(Instantiate(elfPrefab, nextOpenPosition));   
        }
        
        PlayUserTrack();
    }

    private void PlayUserTrack()
    {
        _elves.ForEach(elf => elf.PlaySound());
        UpdateMute();
    }

    private void StopUserTrack()
    {
        _elves.ForEach(elf => elf.StopSound());
    }

    public bool HasValidUserTrack()
    {
        HashSet<ElfId> requiredElves = new HashSet<ElfId>(_requiredElves);
        foreach (ElfId elfId in _elves.Select(elf => elf.ElfId))
        {
            requiredElves.Remove(elfId);
        }

        return !requiredElves.Any();
    }

    private Transform GetNextOpenPosition()
    {
        foreach (Transform position in _positions)
        {
            if (position.childCount == 0)
            {
                return position;
            }
        }

        return null;
    }
    
    public void SetPlayUsersTrackToggled(bool isToggled)
    {
        if (_isPlayingUsersTrack != isToggled)
        {
            _isPlayingUsersTrack = isToggled;
            UpdateMute();
        }
    }

    private void UpdateMute()
    {
        _elves.ForEach(elf => elf.SetVolume(_isPlayingUsersTrack ? 1f : 0f));
        _targetTrackInstance.setVolume(!_isPlayingUsersTrack ? 1f : 0f);
    }
    
    private void OnDestroy()
    {
        StopUserTrack();
        _targetTrackInstance.stop(STOP_MODE.IMMEDIATE);
        _targetTrackInstance.release();
    }
}
