using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    public class MovementBussinessLogic
    {
        private readonly IMovementMotor _movementMotor;

        public MovementBussinessLogic(IMovementMotor movementMotor)
        {
            _movementMotor = movementMotor;
        }


        public void Move(Vector2 direction, float speed)
        {
            _movementMotor.Move(direction, speed);
        }

        public void ShowMoveAnimation(Vector2 direction)
        {
            _movementMotor.ShowMoveAnimation(direction);
        }


}

