using System;
using UnityEngine;

public interface IPlayerMovimentBL
{
    Action<Vector2> OnMove { get; set; }
    Action<string> OnMoveAnimation { get; set; }

    void Move(Vector2 direction, float speed);
}