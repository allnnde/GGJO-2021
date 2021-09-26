using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PacientEnemyController : EnemyController
{
    public override void InteractuePlayer()
    {
        if (Player.CurrentMentalState != PlayerMentalHealthEnum.Demente)
        {
            dialogManager.Start_Dialog(Name, dialogs);
            Player.ChangeMentalHealth(PlayerMentalHealthEnum.Demente);
        }
    }

    public override bool ShouldFollowPlayer()
    {
        if (Player.CurrentMentalState == PlayerMentalHealthEnum.Cuerdo)
        {
            return true;
        }
        return false;
    }
}