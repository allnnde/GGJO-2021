using Domain.Enums;
using UnityEngine;

namespace Domain.Interfaces
{
    public interface IAudioService
    {
        void PlayAudio(PlayerMentalHealthEnum playerMentalHealth);
    }
}