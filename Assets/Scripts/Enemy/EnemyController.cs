using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Route;
    public List<Vector3> PointsRoute { get; set; }
    public Vector3 CurrentPointRoute { get; set; }
    public float Velocity = 5f;
    public float RadiusOfView = 2f;
    public GameObject Player { get; set; }
    private NavMeshAgent navAgent;
    public bool InCurrentPointRoute
    {
        get
        {
            var distancia = Vector3.Distance(CurrentPointRoute, transform.position);
            return distancia < 1.01f;
        }
    }

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        PointsRoute = new List<Vector3>();
        foreach (Transform item in Route?.transform)
        {
            PointsRoute.Add(item.position);
        }

        CurrentPointRoute = PointsRoute.FirstOrDefault();
    }
    public Vector3 GetNextPointRoute()
    {
        var index = PointsRoute.IndexOf(CurrentPointRoute);
        if (index == -1)
            return PointsRoute[0];

        if (index + 1 < PointsRoute.Count())
            return PointsRoute[index + 1];
        else
            return PointsRoute[0];

    }


    public void MoveToPoint(Vector3 point)
    {
        Vector3 dir = point - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;        
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        navAgent.SetDestination(point);
    }

    public bool PlayerInView()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, RadiusOfView);
        if (colliders != null)
        {
            foreach (var item in colliders)
            {
                if (item.CompareTag("Player"))
                    return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadiusOfView);
            
    }

}
