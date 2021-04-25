using Domain.Enums;
using Domain.Interfaces;
using UnityEngine;

namespace Infrastructure.Player
{
    public class PlayerMovementDirectionService : IMovementDirectionService
    {
        public Vector2 GetDirection()
        {
            var horizantal = Input.GetAxisRaw(AxisLabelConstants.HorizontalLabel);
            var vertical = Input.GetAxisRaw(AxisLabelConstants.VerticalLabel);
            return new Vector2(horizantal, vertical);
        }

        public Vector2 GetDirection(Vector2 direction)
        {
            return direction;
        }
    }
}