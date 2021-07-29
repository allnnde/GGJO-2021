using System;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovimentBL : IMovimentBL
{
    public Action<Vector2> MoveEvent { get; set; }

    public void Move(Vector2 direction, float speed)
    {
        var res = direction.normalized * speed;

        Assert.IsNotNull(MoveEvent, "MoveEvent es null en implmentacion de PlayerMovimentBL");
        MoveEvent?.Invoke(res);
    }
}