using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    public override void CheckExit() 
    {
        if (!Enemy.PlayerInView() || !Enemy.ShouldFollowPlayer()) 
        {
            StateMachine.ChangeState<PatrolState>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        movementController.Move(Enemy.Player.transform.position, 0);

        Vector2 direction = GetDirectionAnimation(Enemy.Player.transform.position);

        movementController.ShowMoveAnimation(direction);

    }

 
}
