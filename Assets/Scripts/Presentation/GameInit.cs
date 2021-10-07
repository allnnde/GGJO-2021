using Application.Audio;
using Application.Dialog;
using Application.Enemy;
using Application.Player;
using Domain.Emuns;
using Domain.Interfaces;
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
            ServiceLocator.Instance.UnRegisterAllServices();
            var _movimentService = new PlayerMovimentService();

            var _mentalHealthDictionary = new Dictionary<PlayerMentalHealthEnum, RuntimeAnimatorController>();
            _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Cuerdo, AnimPlayerCuerdo);
            _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Demente, AnimPlayerLoco);
            _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Neutro, AnimPlayerNeutro);

            var _mentalHealthService = new PlayerMentalHealthService(_mentalHealthDictionary);

            ServiceLocator.Instance.RegisterService<IPlayerMovimentService>(_movimentService);
            ServiceLocator.Instance.RegisterService<IMentalHealthService>(_mentalHealthService);

            var enemyMovimentService = new EnemyMovimentService();
            ServiceLocator.Instance.RegisterService<IEnemyMovimentService>(enemyMovimentService);

            var _audioDictionary = new Dictionary<PlayerMentalHealthEnum, AudioClip>();
            _audioDictionary.Add(PlayerMentalHealthEnum.Cuerdo, ClipPlayerCuerdo);
            _audioDictionary.Add(PlayerMentalHealthEnum.Demente, ClipPlayerLoco);

            var audioService = new AudioService(_audioDictionary);
            ServiceLocator.Instance.RegisterService<IAudioService>(audioService);

            var dialogService = new DialogService();
            ServiceLocator.Instance.RegisterService<IDialogService>(dialogService);
        }
    }
}