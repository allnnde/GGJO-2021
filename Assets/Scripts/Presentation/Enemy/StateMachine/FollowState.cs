using Presentation.Player;

namespace Presentation.Enemy.StateMachine
{
    public class FollowState : State
    {
        // Update is called once per frame
        private void Update()
        {
            movementBussinessLogic.Move(PlayerController.Instance.transform.position, 0);
        }

        public override void CheckExit()
        {
            if (!enemyAIBussinessLogic.PlayerInView() || !enemyAIBussinessLogic.ShouldFollowPlayer())
            {
                StateMachine.ChangeState<PatrolState>();
            }
        }
    }
}