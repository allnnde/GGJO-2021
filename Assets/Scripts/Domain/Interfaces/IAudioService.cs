using Domain.Emuns;
using UnityEngine;

namespace Domain.Interfaces
{
    public interface IAudioService
    {
        AudioClip GetAudio(PlayerMentalHealthEnum playerMentalHealth);
    }
}