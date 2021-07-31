using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    public override void CheckExit() 
    {
        if (!MovimentBL.PlayerInView(Enemy.transform.position, Enemy.RadiusOfView) || !MovimentBL.ShouldFollowPlayer(Enemy.EnemyType, Enemy.Player.CurrentMentalState))
        {
            StateMachine.ChangeState<PatrolState>(); 
        }
    }


    // Update is called once per frame
    void Update()
    {
        Enemy.MoveToPoint(Enemy.Player.transform.position); //El enemigo persigue al Player
    }
}
