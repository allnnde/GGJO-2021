using Domain.Enums;

namespace Infrastructure.Enemy
{
    public class PacienteEnemyAIService : EnemyAIService
    {
        public override EnemyTypeEnum EnemyType => EnemyTypeEnum.Paciente;
        
        public override void InteractWithPlayer()
        {
            if (PlayerMentalHealth.MentalState != PlayerMentalHealthEnum.Demente)
            {
                dialogManager.Start_Dialog(Name, dialogs);
                PlayerMentalHealth.ChangeMentalHealth(PlayerMentalHealthEnum.Demente);
                audioSource.PlayLoco();
            }
        }

        public override bool ShouldFollowPlayer()
        {
            return PlayerMentalHealth.MentalState != PlayerMentalHealthEnum.Demente;
        }
    }
}