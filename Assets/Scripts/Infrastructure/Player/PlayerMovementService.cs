﻿using Domain.Enums;
using Domain.Interfaces;
using UnityEngine;

namespace Infrastructure.Player
{
    public class PlayerMovementService : MonoBehaviour, IMovementService
    {
        private Animator _anim;
        private Rigidbody2D _playerRb;

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
        }

        public void Move(Vector2 direction, float speed)
        {
            _playerRb.velocity = direction.normalized * speed;
        }

        public void ShowMoveAnimation(Vector3 direction)
        {
            if (direction.x == 0 && direction.y > 0)
                _anim.Play(AnimationLabelConstants.WalkingTopLabel);
            if (direction.x == 0 && direction.y < 0)
                _anim.Play(AnimationLabelConstants.WalkingBottomLabel);

            if (direction.x < 0 && direction.y == 0)
                _anim.Play(AnimationLabelConstants.WalkingLeftLabel);
            if (direction.x > 0 && direction.y == 0)
                _anim.Play(AnimationLabelConstants.WalkingRightLabel);

            if (direction.x == 0 && direction.y == 0)
                _anim.Play(AnimationLabelConstants.IdleLabel);
        }
    }
}