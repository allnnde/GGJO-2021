﻿using UnityEngine;

public interface IMovementDirectionService
{
    Vector2 GetDirection();
    Vector2 GetDirection(Vector2 direction);
}