using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource _audioSource;
    private IAudioBL _audioBL;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioBL = ServiceLocator.Instance.GetServiceSingleton<IAudioBL>();
    }

    public void PlayClipToMentalHealth(PlayerMentalHealthEnum playerMentalHealth)
    {
        _audioSource.clip = _audioBL.GetAudio(playerMentalHealth);
        _audioSource.Play();
    }
}