using Domain.Enums;
using Domain.Interfaces;
using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace Application.Player
{
    public class PlayerMovimentService : IPlayerMovimentService
    {
        private readonly IPlayerMovimentController _playerMovimentController;

        public PlayerMovimentService(IPlayerMovimentController playerMovimentController)
        {
            _playerMovimentController = playerMovimentController;
        }

        public void Move(Vector2 direction, float speed)
        {
            var res = CalculateVectorMoviment(direction, speed);
            _playerMovimentController.Move(res);

            var animation = GetAnimationName(direction);
            _playerMovimentController.MoveAnimation(animation);
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