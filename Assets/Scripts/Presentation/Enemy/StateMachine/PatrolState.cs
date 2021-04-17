namespace Presentation.Enemy.StateMachine
{
    public class PatrolState : State
    {
        private void Update()
        {
            var currentPoint = routeNavegationBussinessLogic.GetCurrentPointRoute();
            if (routeNavegationBussinessLogic.IsInCurrentPointRoute())
                currentPoint = routeNavegationBussinessLogic.GetNextPointRoute();
            movementBussinessLogic.Move(currentPoint, 0);
        }

        public override void CheckExit()
        {
            if (enemyAIBussinessLogic.PlayerInView() && enemyAIBussinessLogic.ShouldFollowPlayer())
            {
                stateMachine.ChangeState<FollowState>();
            }
        }
    }
}