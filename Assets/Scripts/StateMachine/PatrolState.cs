using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public override void CheckExit() //Salir de este estado
    {
        if (Enemy.PlayerInView()) //Si el enemigo detecta al Player
        {
            Enemy.Player = GameObject.FindGameObjectWithTag("Player"); //El enemigo debe encontrar al GameObject con el Tag: "Player"
            StateMachine.ChangeState<FollowState>(); //La máquina de estado camabiara al estado Seguir
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.InCurrentPointRoute) //Si el enemigo a llegado al punto seleccionado del Route
            Enemy.CurrentPointRoute = Enemy.GetNextPointRoute(); //El enemigo busca el siguiente punto en Route y lo asigna a current

        // TODO caundo tengamos el mapa deberimos ver de agregar logica para que no choque con paredes al regrezar
        Enemy.MoveToPoint(Enemy.CurrentPointRoute); //El enemigo se mueve a ese punto
    }
}
