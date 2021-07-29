using System;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovimentBL : IMovimentBL
{
    public Action<Vector2> MoveEvent { get; set; }
    public Action<string> MoveAnimationEvent { get; set; }

    public void Move(Vector2 direction, float speed)
    {

        Assert.IsNotNull(MoveEvent, "MoveEvent es null en implmentacion de PlayerMovimentBL");
        Assert.IsNotNull(MoveAnimationEvent, "MoveAnimationEvent es null en implmentacion de PlayerMovimentBL");

        var res = CalculateVectorMoviment(direction, speed);
        MoveEvent?.Invoke(res);

        var animation = GetAnimationName(direction);
        MoveAnimationEvent?.Invoke(animation);
    }

    private string GetAnimationName(Vector2 direction)
    {

        if (direction.x == 0 && direction.y > 0)
            return (AnimationLabelConstants.WalkingTopLabel);
        if (direction.x == 0 && direction.y < 0)
            return (AnimationLabelConstants.WalkingBottomLabel);
        if (direction.x < 0 && direction.y == 0)
            return (AnimationLabelConstants.WalkingLeftLabel);
        if (direction.x > 0 && direction.y == 0)
            return (AnimationLabelConstants.WalkingRightLabel);
        if (direction.x == 0 && direction.y == 0)
            return (AnimationLabelConstants.IdleLabel);

        return "";
    }

    private Vector2 CalculateVectorMoviment(Vector2 direction, float speed)
    {
        return direction.normalized * speed;
    }
}