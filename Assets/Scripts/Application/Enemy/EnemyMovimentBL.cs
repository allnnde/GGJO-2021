using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyMovimentBL : IEnemyMovimentBL
{
    public Action<Vector2> OnMove { get; set; }
    public Action<string> OnMoveAnimation { get; set; }

    public void Move(Vector2 point, Vector2 position, bool walking)
    {
        Assert.IsNotNull(OnMove, "MoveEvent es null en implmentacion de PlayerMovimentBL");
        Assert.IsNotNull(OnMoveAnimation, "MoveAnimationEvent es null en implmentacion de PlayerMovimentBL");

        OnMove?.Invoke(point);

        var animation = GetAnimationName(point, position, walking);
        OnMoveAnimation?.Invoke(animation);
    }

    public Vector3 GetNextPointRoute(List<Vector3> pointsRoute, Vector3 currentPointRoute)
    {
        var index = pointsRoute.IndexOf(currentPointRoute);
        if (index == -1)
            return pointsRoute[0];

        if (index + 1 < pointsRoute.Count())
            return pointsRoute[index + 1];
        else
            return pointsRoute[0];
    }

    private Vector2 GetDirection(Vector2 direction)
    {
        var dir = Vector2Int.FloorToInt(direction);

        float x = 0;
        float y = 0;

        if (dir.x != 0)
            x = dir.x / Mathf.Abs(dir.x);

        if (dir.y != 0)
            y = dir.y / Mathf.Abs(dir.y);

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            y = 0;
        else
            x = 0;
        return new Vector2(x, y);
    }

    private string GetAnimationName(Vector2 point, Vector2 position, bool walking)
    {
        var pos = point - position;
        var direction = GetDirection(pos);

        if (direction.x == 0 && direction.y > 0 && walking)
            return (AnimationLabelConstants.WalkingTopLabel);
        if (direction.x == 0 && direction.y < 0 && walking)
            return (AnimationLabelConstants.WalkingBottomLabel);
        if (direction.x < 0 && direction.y == 0 && walking)
            return (AnimationLabelConstants.WalkingLeftLabel);
        if (direction.x > 0 && direction.y == 0 && walking)
            return (AnimationLabelConstants.WalkingRightLabel);
        if (direction.x == 0 && direction.y == 0 && !walking)
            return (AnimationLabelConstants.IdleLabel);

        return string.Empty;
    }

    public bool IsPointInCurrentRoute(Vector3 currentPointRoute, Vector3 position, float tolerance = 1.01f)
    {
        var distancia = Vector3.Distance(currentPointRoute, position);
        return distancia < tolerance;
    }
}