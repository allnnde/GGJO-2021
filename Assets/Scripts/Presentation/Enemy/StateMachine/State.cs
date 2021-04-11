using Application;
using Domain.Interfaces;
using Infrastructure.Enemy;
using UnityEngine;

namespace Presentation.Enemy.StateMachine
{
    [RequireComponent(typeof(StateMachine))]
    [RequireComponent(typeof(EnemyController))]
    [RequireComponent(typeof(EnemyMovementService))]
    [RequireComponent(typeof(EnemyRouteService))]
    [RequireComponent(typeof(EnemyAIService))]
    public abstract class State : MonoBehaviour
    {
        protected EnemyAIBussinessLogic enemyAIBussinessLogic;
        protected EnemyMovementDirectionService enemyMovementDirectionService;
        protected MovementBussinessLogic movementBussinessLogic;
        protected RouteNavegationBussinessLogic routeNavegationBussinessLogic;
        protected StateMachine StateMachine;

        public abstract void CheckExit();

        private void Awake()
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

        //Metodo para verificar la salida de los estados
    }
}