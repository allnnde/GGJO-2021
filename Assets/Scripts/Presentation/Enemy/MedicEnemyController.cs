using Domain.Emuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Enemy
{
    public class MedicEnemyController : EnemyController
    {
        private const PlayerMentalHealthEnum playerMentalHealthInteractive = PlayerMentalHealthEnum.Cuerdo;

        public override void InteractuePlayer()
        {
            if (Player.CurrentMentalState != playerMentalHealthInteractive)
            {
                dialogManager.Start_Dialog(Name, dialogs);
                Player.ChangeMentalHealth(playerMentalHealthInteractive);
            }
        }

        public override bool ShouldFollowPlayer()
        {
            return Player.CurrentMentalState == PlayerMentalHealthEnum.Demente;
        }
    }
}