using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public override void CheckExit()
    {
        if (Enemy.PlayerInView())
        {
            Enemy.Player = GameObject.FindGameObjectWithTag("Player");
            StateMachine.ChangeState<FollowState>();
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.InCurrentPointRoute)
            Enemy.CurrentPointRoute = Enemy.GetNextPointRoute();

        // TODO caundo tengamos el mapa deberimos ver de agregar logica para que no choque con paredes al regrezar
        Enemy.MoveToPoint(Enemy.CurrentPointRoute);
    }
}
