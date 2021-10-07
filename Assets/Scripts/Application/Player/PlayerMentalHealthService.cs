using Domain.Enums;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

namespace Application.Player
{
    public class PlayerMentalHealthService : IMentalHealthService
    {
        private readonly Dictionary<PlayerMentalHealthEnum, RuntimeAnimatorController> _mentalHealthDictionary;
        private readonly IPlayerMentalHealthController _playerMentalHealthController;

        public PlayerMentalHealthService(Dictionary<PlayerMentalHealthEnum, RuntimeAnimatorController> mentalHealthDictionary, IPlayerMentalHealthController playerMentalHealthController)
        {
            _mentalHealthDictionary = mentalHealthDictionary;
            _playerMentalHealthController = playerMentalHealthController;
        }

        public void ChangeMentalHealthAnimator(PlayerMentalHealthEnum mentalHealth)
        {
            var mh = _mentalHealthDictionary[mentalHealth];
            _playerMentalHealthController.ChangeMentalHealthAnimator(mh);
        }
    }
}