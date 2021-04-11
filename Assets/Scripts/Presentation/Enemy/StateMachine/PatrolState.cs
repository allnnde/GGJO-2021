using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public override void CheckExit() 
    {
        if (Enemy.PlayerInView() && Enemy.ShouldFollowPlayer()) 
        {
            StateMachine.ChangeState<FollowState>();
        }


    }
    void Update()
    {
        if (Enemy.InCurrentPointRoute) 
            Enemy.CurrentPointRoute = Enemy.GetNextPointRoute();
        movementController.Move(Enemy.CurrentPointRoute,0);
        Vector2 direction = GetDirectionAnimation(Enemy.CurrentPointRoute);
        movementController.ShowMoveAnimation(direction);

    }
}
