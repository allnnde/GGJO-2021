using UnityEngine;

public interface IMovementMotor
{
    void Move(Vector2 direction, float speed);
    void ShowMoveAnimation(Vector2 direction);
}
