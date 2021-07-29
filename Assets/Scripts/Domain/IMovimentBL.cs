using System;
using UnityEngine;

public interface IMovimentBL
{
    Action<Vector2> MoveEvent { get; set; }
    void Move(Vector2 direction, float speed);
}