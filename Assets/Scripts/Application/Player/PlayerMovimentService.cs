using Domain.Emuns;
using Domain.Interfaces;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Application.Player
{
    public class PlayerMovimentService : IPlayerMovimentService
    {
        public Action<Vector2> OnMove { get; set; }
        public Action<string> OnMoveAnimation { get; set; }

        public void Move(Vector2 direction, float speed)
        {
            Assert.IsNotNull(OnMove, "MoveEvent es null en implmentacion de PlayerMovimentBL");
            Assert.IsNotNull(OnMoveAnimation, "MoveAnimationEvent es null en implmentacion de PlayerMovimentBL");

            var res = CalculateVectorMoviment(direction, speed);
            OnMove?.Invoke(res);

            var animation = GetAnimationName(direction);
            OnMoveAnimation?.Invoke(animation);
        }

        private string GetAnimationName(Vector2 direction)
        {
            if (direction.x == 0 && direction.y > 0)
                return AnimationLabelConstants.WalkingTopLabel;
            if (direction.x == 0 && direction.y < 0)
                return AnimationLabelConstants.WalkingBottomLabel;
            if (direction.x < 0 && direction.y == 0)
                return AnimationLabelConstants.WalkingLeftLabel;
            if (direction.x > 0 && direction.y == 0)
                return AnimationLabelConstants.WalkingRightLabel;
            if (direction.x == 0 && direction.y == 0)
                return AnimationLabelConstants.IdleLabel;

            return string.Empty;
        }

        private Vector2 CalculateVectorMoviment(Vector2 direction, float speed)
        {
            return direction.normalized * speed;
        }
    }
}