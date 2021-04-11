using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementService : MonoBehaviour, IMovementMotor
{
    
    private Animator _anim;
    private NavMeshAgent navAgent;
    

    void Start()
    {
        _anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector2 point, float speed = 0)
    {
        navAgent.SetDestination(point);
    }

    public void ShowMoveAnimation(Vector2 direction)
    {

        var walking = navAgent.remainingDistance > navAgent.stoppingDistance &&
                      navAgent.hasPath && Mathf.Abs(navAgent.velocity.sqrMagnitude) > 0;

        if (direction.x == 0 && direction.y > 0 && walking)
            _anim.Play(AnimationLabelConstants.WalkingTopLabel);
        if (direction.x == 0 && direction.y < 0 && walking)
            _anim.Play(AnimationLabelConstants.WalkingBottomLabel);

        if (direction.x < 0 && direction.y == 0 && walking)
            _anim.Play(AnimationLabelConstants.WalkingLeftLabel);
        if (direction.x > 0 && direction.y == 0 && walking)
            _anim.Play(AnimationLabelConstants.WalkingRightLabel);

        if (direction.x == 0 && direction.y == 0 && !walking)
            _anim.Play(AnimationLabelConstants.IdleLabel);
    }
}
