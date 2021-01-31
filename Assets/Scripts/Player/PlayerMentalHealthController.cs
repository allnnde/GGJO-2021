using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMentalHealthController : MonoBehaviour
{

    public PlayerMentalHealthEnum MentalState;
   
    public void ChangeMentalHealth(PlayerMentalHealthEnum newMentalHealth)
    {
        MentalState = newMentalHealth;
    }


}
