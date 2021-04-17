using Domain.Enums;

namespace Infrastructure.Enemy
{
    public class MedicoEnemyAIService : EnemyAIService
    {
        public override EnemyTypeEnum EnemyType => EnemyTypeEnum.Medico;

        public override void InteractWithPlayer()
        {
            if (PlayerMentalHealth.MentalState == PlayerMentalHealthEnum.Demente)
            {
                dialogService.StartDialog(Name, message);
                PlayerMentalHealth.ChangeMentalHealth(PlayerMentalHealthEnum.Cuerdo);
                audioSource.PlayCuerdo();
            }
        }

        public override bool ShouldFollowPlayer()
        {
            return PlayerMentalHealth.MentalState == PlayerMentalHealthEnum.Demente;
        }
    }
}