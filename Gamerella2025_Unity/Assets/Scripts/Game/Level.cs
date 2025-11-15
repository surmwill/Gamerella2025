using System.Collections.Generic;
using System.Linq;
using Game;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Transform[] _positions = null;

    [SerializeField]
    private ElfId[] _requiredElves = null;

    private readonly List<Elf> _elves = new();

    public void RemoveElf(Elf elf)
    {
        StopTrack();
        Destroy(elf.gameObject);
        _elves.Remove(elf);
    }

    public void AddElf(Elf elfPrefab)
    {
        StopTrack();
        
        Transform nextOpenPosition = GetNextOpenPosition();
        if (nextOpenPosition != null)
        {
            _elves.Add(Instantiate(elfPrefab, nextOpenPosition));   
        }
    }
    
    public bool PlayAndValidateTrack()
    {
        PlayTrack();
        return IsValidTrack();
    }

    private void PlayTrack()
    {
        _elves.ForEach(elf => elf.PlaySound());
    }

    private void StopTrack()
    {
        _elves.ForEach(elf => elf.StopSound());
    }

    private bool IsValidTrack()
    {
        HashSet<ElfId> requiredElves = new HashSet<ElfId>(_requiredElves);
        foreach (ElfId elfId in _elves.Select(elf => elf.ElfId))
        {
            if (!requiredElves.Remove(elfId))
            {
                return false;
            }
        }

        return true;
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
}
