using System;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonAudio : MonoBehaviour
{
    [SerializeField]
    private EventReference _event;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.onClick.AddListener(PlayOneShot);
    }

    private void PlayOneShot()
    {
        RuntimeManager.PlayOneShot(_event);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(PlayOneShot);
    }
}
