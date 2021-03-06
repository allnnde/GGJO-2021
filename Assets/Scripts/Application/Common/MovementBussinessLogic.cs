﻿using Domain.Interfaces;
using UnityEngine;

namespace Application.Common
{
    public class MovementBussinessLogic
    {
        private readonly IMovementService _movementMotor;

        public MovementBussinessLogic(IMovementService movementMotor)
        {
            _movementMotor = movementMotor;
        }

        public void Move(Vector2 direction, float speed)
        {
            _movementMotor.Move(direction, speed);
            _movementMotor.ShowMoveAnimation(direction);
        }
    }
}