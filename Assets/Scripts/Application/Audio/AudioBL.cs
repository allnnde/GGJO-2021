using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AudioBL : IAudioBL
{
    private readonly Dictionary<PlayerMentalHealthEnum, AudioClip> _audiosDictionary;

    public AudioBL(Dictionary<PlayerMentalHealthEnum, AudioClip> audiosDictionary)
    {
        _audiosDictionary = audiosDictionary;
    }

    public AudioClip GetAudio(PlayerMentalHealthEnum playerMentalHealth)
    {
        return _audiosDictionary[playerMentalHealth];
    }



}

