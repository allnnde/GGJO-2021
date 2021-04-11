using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementService : MonoBehaviour, IMovementMotor
{
    private Rigidbody2D _playerRb;
    private Animator _anim;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    public void ShowMoveAnimation(Vector2 direction)
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

    public void Move(Vector2 direction, float speed)
    {
        _playerRb.velocity = direction.normalized * speed;
    }
}
