using Domain.Enums;
using Domain.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Infrastructure.Enemy
{
    public class EnemyMovementService : MonoBehaviour, IMovementService
    {
        private Animator _anim;
        private IMovementDirectionService _enemyMovementDirectionService;
        private NavMeshAgent _navAgent;

        public Vector2 GetDirectionAnimation(Vector3 point)
        {
            var position = point - transform.position;
            var direction = _enemyMovementDirectionService.GetDirection(position);
            return direction;
        }

        public void Move(Vector2 point, float speed = 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            _navAgent.SetDestination(point);
        }

        public void ShowMoveAnimation(Vector3 point)
        {
            var position = point - transform.position;
            var direction = _enemyMovementDirectionService.GetDirection(position);

            var walking = _navAgent.remainingDistance > _navAgent.stoppingDistance &&
                          _navAgent.hasPath && Mathf.Abs(_navAgent.velocity.sqrMagnitude) > 0;

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

        private void Start()
        {
            _anim = GetComponent<Animator>();
            _navAgent = GetComponent<NavMeshAgent>();
            _enemyMovementDirectionService = new EnemyMovementDirectionService();
        }
    }
}