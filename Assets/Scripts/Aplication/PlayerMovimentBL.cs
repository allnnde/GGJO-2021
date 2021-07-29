using System;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovimentBL : IMovimentBL
{
    public Action<Vector2> MoveEvent { get; set; }
    public Action<Vector2> MoveAnimationEvent { get; set; }

    public void Move(Vector2 direction, float speed)
    {
        var res = CalculateVectorMoviment(direction, speed);

        Assert.IsNotNull(MoveEvent, "MoveEvent es null en implmentacion de PlayerMovimentBL");
        MoveEvent?.Invoke(res);

        Assert.IsNotNull(MoveAnimationEvent, "MoveAnimationEvent es null en implmentacion de PlayerMovimentBL");
        MoveAnimationEvent?.Invoke(res);
    }

    private Vector2 CalculateVectorMoviment(Vector2 direction, float speed)
    {
        return direction.normalized * speed;
    }
}