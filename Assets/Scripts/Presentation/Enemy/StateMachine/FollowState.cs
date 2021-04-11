using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    public override void CheckExit() 
    {
        if (!enemyAIBussinessLogic.PlayerInView() || !enemyAIBussinessLogic.ShouldFollowPlayer()) 
        {
            StateMachine.ChangeState<PatrolState>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        movementBussinessLogic.Move(PlayerController.Instance.transform.position, 0);

    }

 
}
