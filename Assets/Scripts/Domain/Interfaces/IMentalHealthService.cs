using Assets.Scripts.Domain.Enums;

namespace Assets.Scripts.Domain.Interfaces
{
    public interface IMentalHealthService
    {
        void ChangeMentalHealth(PlayerMentalHealthEnum newMentalHealth);
    }
}