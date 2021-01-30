using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    public override void CheckExit()
    {
        if (!Enemy.PlayerInView())
        {
            StateMachine.ChangeState<PatrolState>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        Enemy.MoveToPoint(Enemy.Player.transform.position);
    }
}
