using Domain.Enums;

namespace Domain.Interfaces
{
    public interface IEnemyAIService
    {
        EnemyTypeEnum EnemyType { get; set; }
        float RadiusOfView { get; set; }

        void InteractWithPlayer();

        bool PlayerInView();

        bool ShouldFollowPlayer();
    }
}