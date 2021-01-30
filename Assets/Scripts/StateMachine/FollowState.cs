using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    public override void CheckExit()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 2);

        if (colliders != null)
        {
            foreach (var item in colliders)
            {
                if (item.CompareTag("Player"))                
                    return;                
            }

            StateMachine.ChangeState<PatrolState>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Enemy.Player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.Translate(Vector2.right * Enemy.Velocity * Time.deltaTime);
        
        //TODO ver de agregar interacion con el player

    }
}
