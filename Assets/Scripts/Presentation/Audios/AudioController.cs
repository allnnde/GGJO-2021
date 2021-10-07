using Domain.Emuns;
using Domain.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation.Audio
{
    public class AudioController : MonoBehaviour
    {
        private AudioSource _audioSource;
        private IAudioService _audioService;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioService = ServiceLocator.Instance.GetServiceSingleton<IAudioService>();
        }

        public void PlayClipToMentalHealth(PlayerMentalHealthEnum playerMentalHealth)
        {
            _audioSource.clip = _audioService.GetAudio(playerMentalHealth);
            _audioSource.Play();
        }
    }
}