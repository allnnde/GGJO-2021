using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    public override void CheckExit() //Condicion de Salida
    {
        if (!Enemy.PlayerInView()) //Si el NO enemigo detecta al Player
        {
            StateMachine.ChangeState<PatrolState>();//La maquina de estado cambia al estado de Patrullaje
        }
    }


    // Update is called once per frame
    void Update()
    {
        Enemy.MoveToPoint(Enemy.Player.transform.position); //El enemigo persigue al Player
    }
}
