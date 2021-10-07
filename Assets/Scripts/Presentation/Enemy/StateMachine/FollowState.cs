using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation.Enemy.StateMachine
{
    public class FollowState : State
    {
        public override void CheckExit()
        {
            if (!Enemy.IsPlayerInView() || !Enemy.ShouldFollowPlayer())
            {
                StateMachine.ChangeState<PatrolState>();
            }
        }

        // Update is called once per frame
        private void Update()
        {
            Enemy.MoveToPoint(Enemy.Player.transform.position);
        }
    }
}