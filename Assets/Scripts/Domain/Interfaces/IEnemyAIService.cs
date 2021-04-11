using Assets.Scripts.Domain.Enums;

namespace Assets.Scripts.Domain.Interfaces
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