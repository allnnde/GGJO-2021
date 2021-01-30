using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{

    private void Start()
    {

        Vector3 dir = Enemy.CurrentPointRoute - transform.position;
        float angle =Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
    public override void CheckExit()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nextPoint;
        if (!Enemy.InCurrentPointRoute)
            nextPoint = Enemy.CurrentPointRoute;
        else
        {
            nextPoint = Enemy.GetNextPointRoute();
            Enemy.CurrentPointRoute = nextPoint;

            Vector3 dir = Enemy.CurrentPointRoute - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        Debug.Log("nextPoint " + nextPoint);
        Debug.Log("position " + transform.position);
        transform.Translate(Vector2.right * Enemy.Velocity * Time.deltaTime);
    }
}
