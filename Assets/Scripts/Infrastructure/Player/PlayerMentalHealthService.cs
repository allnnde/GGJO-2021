using Assets.Scripts.Domain.Enums;
using Assets.Scripts.Domain.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Player
{
    public class PlayerMentalHealthService : MonoBehaviour, IMentalHealthService
    {
        public RuntimeAnimatorController AnimPlayerCuerdo;
        public RuntimeAnimatorController AnimPlayerLoco;
        public RuntimeAnimatorController AnimPlayerNeutro;
        public PlayerMentalHealthEnum MentalState;
        private Animator anim;

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

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }
    }
}