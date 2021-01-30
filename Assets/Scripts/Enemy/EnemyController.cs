using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Route;
    public List<Vector3> PointsRoute;
    public Vector3 CurrentPointRoute;
    public float Velocity = 5f;
    public bool InCurrentPointRoute
    {
        get
        {
            var distancia = Vector3.Distance(CurrentPointRoute, transform.position);
            // Debug.Log("Distance" + distancia);
                return distancia  < 1.01f;
        }
    }

    private void Awake()
    {
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



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
