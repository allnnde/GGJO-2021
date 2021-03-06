using Domain.Enums;
using Domain.Interfaces;
using UnityEngine;

namespace Infrastructure.Player
{
    public class PlayerMentalHealthService : MonoBehaviour, IMentalHealthService
    {
        private Animator anim;
        public RuntimeAnimatorController AnimPlayerCuerdo;
        public RuntimeAnimatorController AnimPlayerLoco;
        public RuntimeAnimatorController AnimPlayerNeutro;
        public PlayerMentalHealthEnum MentalState;

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
}