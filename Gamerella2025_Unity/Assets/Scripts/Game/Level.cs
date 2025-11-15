using Game;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Transform[] _positions = null;

    [SerializeField]
    private ElfId[] _requiredElves = null;

    public void RemoveElf(Elf elf)
    {
        PauseTrack();
        Destroy(elf.gameObject);
    }

    public void AddElf(Elf elfPrefab)
    {
        PauseTrack();
        
        Transform nextOpenPosition = GetNextOpenPosition();
        if (nextOpenPosition != null)
        {
            Instantiate(elfPrefab, nextOpenPosition);   
        }
    }

    private void PauseTrack()
    {
        
    }

    public void ValidateTrack()
    {
        
    }

    private void PlayMusic()
    {
        
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
