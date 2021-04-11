using Domain.Enums;
using Infrastructure.Audios;
using Infrastructure.Dialog;
using Infrastructure.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Enemy
{
    public abstract class EnemyAIService : MonoBehaviour
    {
        protected AudioManager audioSource;
        protected DialogManager dialogManager;
        protected PlayerMentalHealthService PlayerMentalHealth;
        public List<string> dialogs;
        public string Name;
        public abstract EnemyTypeEnum EnemyType { get; }
        public float RadiusOfView { get; set; } = 4f;

        private void Awake()
        {
            PlayerMentalHealth = FindObjectOfType<PlayerMentalHealthService>();

            dialogManager = FindObjectOfType<DialogManager>();
            audioSource = FindObjectOfType<AudioManager>();
        }

        public abstract void InteractWithPlayer();

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

        public abstract bool ShouldFollowPlayer();
    }
}