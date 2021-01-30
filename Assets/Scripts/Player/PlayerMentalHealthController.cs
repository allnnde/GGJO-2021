using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMentalHealthController : MonoBehaviour
{

    public PlayerMentalHealthEnum MentalState;
   
    public void ChangeSalud(PlayerMentalHealthEnum newMentalHealth)
    {
        MentalState = newMentalHealth;
    }


}
