﻿using UnityEngine;

namespace Domain.Interfaces
{
    public interface IMovementService
    {
        void Move(Vector2 direction, float speed);

        void ShowMoveAnimation(Vector3 direction);
    }
}