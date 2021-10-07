using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Enemy
{
    public class PacientEnemyController : EnemyController
    {
        private const PlayerMentalHealthEnum playerMentalHealthInteractive = PlayerMentalHealthEnum.Demente;

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
            return Player.CurrentMentalState == PlayerMentalHealthEnum.Cuerdo;
        }
    }
}