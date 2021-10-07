using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMovimentBL
{
    Action<string> OnMoveAnimation { get; set; }
    Action<Vector2> OnMove { get; set; }

    Vector3 GetNextPointRoute(List<Vector3> pointsRoute, Vector3 currentPointRoute);

    void Move(Vector2 point, Vector2 position, bool walking);

    bool IsPointInCurrentRoute(Vector3 currentPointRoute, Vector3 position, float tolerance = 1.01f);
}