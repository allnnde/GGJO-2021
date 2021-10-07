using Application.Audio;
using Application.Dialog;
using Application.Enemy;
using Application.Player;
using Domain.Enums;
using Presentation.Audio;
using Presentation.Dialog;
using Presentation.Enemy;
using Presentation.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation
{
    public class GameInit : MonoBehaviour
    {
        public RuntimeAnimatorController AnimPlayerCuerdo;
        public RuntimeAnimatorController AnimPlayerNeutro;
        public RuntimeAnimatorController AnimPlayerLoco;

        public AudioClip ClipPlayerCuerdo;
        public AudioClip ClipPlayerLoco;

        private void Awake()
        {
            var _mentalHealthDictionary = new Dictionary<PlayerMentalHealthEnum, RuntimeAnimatorController>();
            _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Cuerdo, AnimPlayerCuerdo);
            _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Demente, AnimPlayerLoco);
            _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Neutro, AnimPlayerNeutro);

            var playerController = FindObjectsOfType(typeof(PlayerController)) as PlayerController[];

            foreach (var item in playerController)
            {
                var _movimentService = new PlayerMovimentService(item);
                var _mentalHealthService = new PlayerMentalHealthService(_mentalHealthDictionary, item);
                item.Configuration(_mentalHealthService, _movimentService);
            }
            var enemiesController = FindObjectsOfType(typeof(EnemyController)) as EnemyController[];

            foreach (var item in enemiesController)
            {
                var enemyMovimentService = new EnemyMovimentService(item);
                item.Configuration(enemyMovimentService);
            }

            var _audioDictionary = new Dictionary<PlayerMentalHealthEnum, AudioClip>();
            _audioDictionary.Add(PlayerMentalHealthEnum.Cuerdo, ClipPlayerCuerdo);
            _audioDictionary.Add(PlayerMentalHealthEnum.Demente, ClipPlayerLoco);

            var audioController = FindObjectsOfType(typeof(AudioController)) as AudioController[];

            foreach (var item in audioController)
            {
                var audioService = new AudioService(_audioDictionary, item);
                item.Configuration(audioService);
            }

            var dialogManager = FindObjectsOfType(typeof(DialogManager)) as DialogManager[];

            foreach (var item in dialogManager)
            {
                var dialogService = new DialogService(item);
                item.Configuration(dialogService);
            }
        }
    }
}