using Domain.Emuns;
using System;
using UnityEngine;

namespace Domain.Interfaces
{
    public interface IMentalHealthService
    {
        public Action<RuntimeAnimatorController> OnChangeMentalHealthAnimator { get; set; }

        void ChangeMentalHealthAnimator(PlayerMentalHealthEnum mentalHealth);
    }
}