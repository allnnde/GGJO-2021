using System;
using UnityEngine;

public interface IPlayerMovimentBL
{
    Action<Vector2> MoveEvent { get; set; }
    Action<string> MoveAnimationEvent { get; set; }

    void Move(Vector2 direction, float speed);
}