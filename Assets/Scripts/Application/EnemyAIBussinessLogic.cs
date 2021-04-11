using Domain.Interfaces;

namespace Application
{
    public class EnemyAIBussinessLogic
    {
        private readonly IEnemyAIService _enemyAIService;

        public EnemyAIBussinessLogic(IEnemyAIService enemyAIService)
        {
            _enemyAIService = enemyAIService;
        }

        public float GetRadiusOfView()
        {
            return _enemyAIService.RadiusOfView;
        }

        public void InteractWithPlayer()
        {
            _enemyAIService.InteractWithPlayer();
        }

        public bool PlayerInView()
        {
            return _enemyAIService.PlayerInView();
        }

        public bool ShouldFollowPlayer()
        {
            return _enemyAIService.ShouldFollowPlayer();
        }
    }
}