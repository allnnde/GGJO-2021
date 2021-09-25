using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public override void CheckExit() 
    {
        if (MovimentBL.PlayerInView(Enemy.transform.position, Enemy.RadiusOfView) && MovimentBL.ShouldFollowPlayer(Enemy.EnemyType, Enemy.Player.CurrentMentalState)) 
        {
            StateMachine.ChangeState<FollowState>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (MovimentBL.InCurrentPointRoute(Enemy.CurrentPointRoute, Enemy.transform.position)) 
            Enemy.CurrentPointRoute = MovimentBL.GetNextPointRoute(Enemy.PointsRoute, Enemy.CurrentPointRoute);

        Enemy.MoveToPoint(Enemy.CurrentPointRoute); 
    }
}
