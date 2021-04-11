using Assets.Scripts.Domain.Enums;
using Assets.Scripts.Domain.Interfaces;
using Assets.Scripts.Infrastructure.Audios;
using Assets.Scripts.Infrastructure.Dialog;
using Assets.Scripts.Infrastructure.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Enemy
{
    public class EnemyAIService : MonoBehaviour, IEnemyAIService
    {

        [SerializeField] private EnemyTypeEnum _enemyType;
        public EnemyTypeEnum EnemyType { get { return _enemyType; } set { _enemyType = value; } }
        public float RadiusOfView { get; set; } = 4f;

        PlayerMentalHealthService PlayerMentalHealth;


        private DialogManager dialogManager;
        private AudioManager audioSource;
        public string Name;
        public List<string> dialogs;


        private void Awake()
        {
            PlayerMentalHealth = FindObjectOfType<PlayerMentalHealthService>();

            dialogManager = FindObjectOfType<DialogManager>();
            audioSource = FindObjectOfType<AudioManager>();
        }

        public bool PlayerInView()
        {
            var colliders = Physics2D.OverlapCircleAll(transform.position, RadiusOfView); //Genera circulos alrededor del enemigo. Si el Player colisiona con estos, se activará el enemigo
            if (colliders != null)
            {
                foreach (var item in colliders)
                {
                    if (item.CompareTag("Player"))
                        return true;
                }
            }
            return false;
        }

        public bool ShouldFollowPlayer()
        {
            if (EnemyType == EnemyTypeEnum.Medico && PlayerMentalHealth.MentalState == PlayerMentalHealthEnum.Demente)
            {
                return true;
            }

            if (EnemyType == EnemyTypeEnum.Paciente && PlayerMentalHealth.MentalState != PlayerMentalHealthEnum.Demente)
            {
                return true;
            }
            return false;
        }

        public void InteractWithPlayer()
        {
            if (EnemyType == EnemyTypeEnum.Medico && PlayerMentalHealth.MentalState != PlayerMentalHealthEnum.Cuerdo)
            {
                dialogManager.Start_Dialog(Name, dialogs);
                PlayerMentalHealth.ChangeMentalHealth(PlayerMentalHealthEnum.Cuerdo);
                audioSource.PlayCuerdo();
            }

            if (EnemyType == EnemyTypeEnum.Paciente && PlayerMentalHealth.MentalState != PlayerMentalHealthEnum.Demente)
            {
                dialogManager.Start_Dialog(Name, dialogs);
                PlayerMentalHealth.ChangeMentalHealth(PlayerMentalHealthEnum.Demente);
                audioSource.PlayLoco();
            }
        }

    }
}