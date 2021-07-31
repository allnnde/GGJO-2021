using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MedicEnemyController : EnemyController
{
    public override void InteractuePlayer()
    {
        if (Player.CurrentMentalState != PlayerMentalHealthEnum.Cuerdo)
        {
            dialogManager.Start_Dialog(Name, dialogs);
            Player.ChangeMentalHealth(PlayerMentalHealthEnum.Cuerdo);
        }
    }
}
