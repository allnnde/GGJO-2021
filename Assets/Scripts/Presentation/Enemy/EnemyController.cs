using Domain.Enums;
using Domain.Interfaces;
using Presentation.Dialog;
using Presentation.Player;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Presentation.Enemy
{
    public abstract class EnemyController : MonoBehaviour, IEnemyMovimentController
    {
        public GameObject Route;
        public List<Vector3> PointsRoute { get; set; }
        public Vector3 CurrentPointRoute { get; set; }
        public float Velocity = 5f;
        public float RadiusOfView = 2f;
        public PlayerController Player { get; private set; }

        private NavMeshAgent _navAgent;

        public EnemyTypeEnum EnemyType;

        protected DialogManager dialogManager;

        private Animator _anim;

        public string Name;

        public List<string> dialogs;
        public IEnemyMovimentService MovimentService;

        private void Awake()
        {
            _navAgent = GetComponent<NavMeshAgent>();
            PointsRoute = new List<Vector3>();
            foreach (Transform item in Route?.transform)
            {
                PointsRoute.Add(item.position);
            }

            CurrentPointRoute = PointsRoute.FirstOrDefault();

            Player = FindObjectOfType<PlayerController>();
            dialogManager = FindObjectOfType<DialogManager>();
            _anim = GetComponent<Animator>();
        }

        public void Configuration(IEnemyMovimentService enemyMovimentService)
        {
            MovimentService = enemyMovimentService;
        }

        public void Move(Vector2 point)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            _navAgent.SetDestination(point);
        }

        public void MoveAnimation(string animation)
        {
            _anim.Play(animation);
        }

        public void MoveToPoint(Vector3 point)
        {
            var walking = _navAgent.remainingDistance > _navAgent.stoppingDistance &&
                         _navAgent.hasPath && Mathf.Abs(_navAgent.velocity.sqrMagnitude) > 0;
            MovimentService.Move(point, transform.position, walking);
        }

        public bool IsPlayerInView()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, RadiusOfView);
            if (colliders != null)
            {
                foreach (var item in colliders)
                {
                    if (item.CompareTag("Player"))
                        return true;
                }
            }
            return false;
        }

        public bool IsPointInCurrentRoute()
        {
            return MovimentService.IsPointInCurrentRoute(CurrentPointRoute, transform.position);
        }

        public Vector3 GetNextPointRoute()
        {
            CurrentPointRoute = MovimentService.GetNextPointRoute(PointsRoute, CurrentPointRoute);
            return CurrentPointRoute;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                InteractuePlayer();
            }
        }

        public abstract void InteractuePlayer();

        public abstract bool ShouldFollowPlayer();

        private void OnDrawGizmos() //Dibuja el area de efecto en el editor
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, RadiusOfView);
        }
    }
}