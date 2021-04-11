using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Presentation.Enemy.StateMachine
{
    public class PatrolState : State
    {
        public override void CheckExit()
        {
            if (enemyAIBussinessLogic.PlayerInView() && enemyAIBussinessLogic.ShouldFollowPlayer())
            {
                StateMachine.ChangeState<FollowState>();
            }


        }
        void Update()
        {

            var currentPoint = routeNavegationBussinessLogic.GetCurrentPointRoute();
            if (routeNavegationBussinessLogic.IsInCurrentPointRoute())
                currentPoint = routeNavegationBussinessLogic.GetNextPointRoute();
            movementBussinessLogic.Move(currentPoint, 0);

        }
    }
}