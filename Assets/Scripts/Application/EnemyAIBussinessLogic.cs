using Assets.Scripts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Application
{
    public class EnemyAIBussinessLogic
    {
        private readonly IEnemyAIService _enemyAIService;

        public EnemyAIBussinessLogic(IEnemyAIService enemyAIService)
        {
            _enemyAIService = enemyAIService;
        }
        public bool PlayerInView()
        {
            return _enemyAIService.PlayerInView();
        }

        public bool ShouldFollowPlayer()
        {
            return _enemyAIService.ShouldFollowPlayer();
        }


        public void InteractWithPlayer()
        {
            _enemyAIService.InteractWithPlayer();
        }

        public float GetRadiusOfView()
        {
            return _enemyAIService.RadiusOfView;
        }
    }
}