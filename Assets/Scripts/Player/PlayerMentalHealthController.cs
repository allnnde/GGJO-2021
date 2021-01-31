using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMentalHealthController : MonoBehaviour
{

    public PlayerMentalHealthEnum MentalState;
    public RuntimeAnimatorController AnimPlayerCuerdo;
    public RuntimeAnimatorController AnimPlayerNeutro;
    public RuntimeAnimatorController AnimPlayerLoco;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void ChangeMentalHealth(PlayerMentalHealthEnum newMentalHealth)
    {
        MentalState = newMentalHealth;

        switch (MentalState)
        {
            case PlayerMentalHealthEnum.Demente:
                anim.runtimeAnimatorController = AnimPlayerLoco;
                break;
            case PlayerMentalHealthEnum.Cuerdo:
                anim.runtimeAnimatorController = AnimPlayerCuerdo;
                break;
            case PlayerMentalHealthEnum.Neutro:
                anim.runtimeAnimatorController = AnimPlayerNeutro;
                break;
            default:
                break;
        }

    }


}
