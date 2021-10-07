using Domain.Enums;
using Domain.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation.Audio
{
    public class AudioController : MonoBehaviour, IAudioController
    {
        private AudioSource _audioSource;
        private IAudioService _audioService;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Configuration(IAudioService audioService)
        {
            _audioService = audioService;
        }

        public void PlayClipToMentalHealth(PlayerMentalHealthEnum playerMentalHealth)
        {
            _audioService.PlayAudio(playerMentalHealth);
        }

        public void PlayClip(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}