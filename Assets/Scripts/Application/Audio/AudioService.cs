using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Application.Audio
{
    public class AudioService : IAudioService
    {
        private readonly Dictionary<PlayerMentalHealthEnum, AudioClip> _audiosDictionary;
        private readonly IAudioController _audioController;

        public AudioService(Dictionary<PlayerMentalHealthEnum, AudioClip> audiosDictionary, IAudioController audioController)
        {
            _audiosDictionary = audiosDictionary;
            _audioController = audioController;
        }

        public void PlayAudio(PlayerMentalHealthEnum playerMentalHealth)
        {
            var clip = _audiosDictionary[playerMentalHealth];
            _audioController.PlayClip(clip);
        }
    }
}