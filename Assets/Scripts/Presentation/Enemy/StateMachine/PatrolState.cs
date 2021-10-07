using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public override void CheckExit()
    {
        if (Enemy.IsPlayerInView() && Enemy.ShouldFollowPlayer())
        {
            StateMachine.ChangeState<FollowState>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Enemy.IsPointInCurrentRoute())
            Enemy.GetNextPointRoute();
        Enemy.MoveToPoint(Enemy.CurrentPointRoute);
    }
}