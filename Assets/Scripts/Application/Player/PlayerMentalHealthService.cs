using Domain.Emuns;
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

        public Action<RuntimeAnimatorController> OnChangeMentalHealthAnimator { get; set; }

        public PlayerMentalHealthService(Dictionary<PlayerMentalHealthEnum, RuntimeAnimatorController> mentalHealthDictionary)
        {
            _mentalHealthDictionary = mentalHealthDictionary;
        }

        public void ChangeMentalHealthAnimator(PlayerMentalHealthEnum mentalHealth)
        {
            Assert.IsNotNull(OnChangeMentalHealthAnimator, "ChangeMentalHealthAnimatorEvent es null en implmentacion de PlayerMentalHealthBL");

            var mh = _mentalHealthDictionary[mentalHealth];

            OnChangeMentalHealthAnimator?.Invoke(mh);
        }
    }
}