using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IMentalHealthService
    {
        void ChangeMentalHealth(PlayerMentalHealthEnum newMentalHealth);
    }
}