using Domain.Emuns;
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

        public AudioService(Dictionary<PlayerMentalHealthEnum, AudioClip> audiosDictionary)
        {
            _audiosDictionary = audiosDictionary;
        }

        public AudioClip GetAudio(PlayerMentalHealthEnum playerMentalHealth)
        {
            return _audiosDictionary[playerMentalHealth];
        }
    }
}