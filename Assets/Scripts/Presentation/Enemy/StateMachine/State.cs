using Assets.Scripts.Application;
using Assets.Scripts.Domain.Interfaces;
using Assets.Scripts.Infrastructure.Enemy;
using Assets.Scripts.Presentation.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Presentation.Enemy.StateMachine
{
    [RequireComponent(typeof(StateMachine))]
    [RequireComponent(typeof(EnemyController))]
    [RequireComponent(typeof(EnemyMovementService))]
    [RequireComponent(typeof(EnemyRouteService))]
    [RequireComponent(typeof(EnemyAIService))]
    public abstract class State : MonoBehaviour
    {
        protected StateMachine StateMachine;
        protected MovementBussinessLogic movementBussinessLogic;
        protected RouteNavegationBussinessLogic routeNavegationBussinessLogic;
        protected EnemyMovementDirectionService enemyMovementDirectionService;
        protected EnemyAIBussinessLogic enemyAIBussinessLogic;

        void Awake()
        {
            StateMachine = GetComponent<StateMachine>();
            var enemyMovementController = GetComponent<IMovementService>();
            movementBussinessLogic = new MovementBussinessLogic(enemyMovementController);

            var routeNavegationService = GetComponent<IRouteNavegationService>();
            routeNavegationBussinessLogic = new RouteNavegationBussinessLogic(routeNavegationService);
            enemyMovementDirectionService = new EnemyMovementDirectionService();

            var enemyAIService = GetComponent<IEnemyAIService>();
            enemyAIBussinessLogic = new EnemyAIBussinessLogic(enemyAIService);
        }

        public abstract void CheckExit(); //Metodo para verificar la salida de los estados
    }
}