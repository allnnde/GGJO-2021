using Assets.Scripts.Presentation.Player;

namespace Assets.Scripts.Presentation.Enemy.StateMachine
{
    public class FollowState : State
    {
        public override void CheckExit()
        {
            if (!enemyAIBussinessLogic.PlayerInView() || !enemyAIBussinessLogic.ShouldFollowPlayer())
            {
                StateMachine.ChangeState<PatrolState>();
            }
        }

        // Update is called once per frame
        private void Update()
        {
            movementBussinessLogic.Move(PlayerController.Instance.transform.position, 0);
        }
    }
}