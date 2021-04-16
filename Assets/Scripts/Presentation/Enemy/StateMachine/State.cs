using Application.Common;
using Application.Enemy;
using Domain.Interfaces;
using Infrastructure.Enemy;
using UnityEngine;

namespace Presentation.Enemy.StateMachine
{
    [RequireComponent(typeof(StateMachine))]
    [RequireComponent(typeof(EnemyController))]
    [RequireComponent(typeof(EnemyMovementService))]
    [RequireComponent(typeof(EnemyRouteService))]
    public abstract class State : MonoBehaviour
    {
        protected EnemyAIBussinessLogic enemyAIBussinessLogic;
        protected EnemyMovementDirectionService enemyMovementDirectionService;
        protected MovementBussinessLogic movementBussinessLogic;
        protected RouteNavegationBussinessLogic routeNavegationBussinessLogic;
        protected StateMachine stateMachine;

        private void Awake()
        {
            stateMachine = GetComponent<StateMachine>();
            var enemyMovementController = GetComponent<IMovementService>();
            movementBussinessLogic = new MovementBussinessLogic(enemyMovementController);

            var routeNavegationService = GetComponent<IRouteNavegationService>();
            routeNavegationBussinessLogic = new RouteNavegationBussinessLogic(routeNavegationService);
            enemyMovementDirectionService = new EnemyMovementDirectionService();

            var enemyAIService = GetComponent<EnemyAIService>();
            enemyAIBussinessLogic = new EnemyAIBussinessLogic(enemyAIService);
        }

        public abstract void CheckExit();

        //Metodo para verificar la salida de los estados
    }
}