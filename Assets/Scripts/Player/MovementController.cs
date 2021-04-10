using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    public class MovementController
    {
        private readonly IMovementMotor _movementMotor;

        public MovementController(IMovementMotor movementMotor)
        {
            _movementMotor = movementMotor;
        }


        public void Move(Vector2 direction, float speed)
        {
            _movementMotor.Move(direction, speed);
            _movementMotor.ShowMoveAnimation(direction);
        }


    }

