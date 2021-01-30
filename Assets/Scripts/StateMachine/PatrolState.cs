using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{

    private void Start()
    {
    }
    public override void CheckExit()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 2);

        if (colliders != null)
        {
            foreach (var item in colliders)
            {
                if (item.CompareTag("Player"))
                {
                    //TODO tenemos que agregar la logica para ver el estado del personaje 
                    Enemy.Player = item.gameObject;
                    StateMachine.ChangeState<FollowState>();
                    break;
                }
            }
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (Enemy.InCurrentPointRoute)
            Enemy.CurrentPointRoute = Enemy.GetNextPointRoute();


        // TODO caundo tengamos el mapa deberimos ver de agregar logica para que no choque con paredes al regrezar

        Vector3 dir = Enemy.CurrentPointRoute - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Translate(Vector2.right * Enemy.Velocity * Time.deltaTime);
    }
}
