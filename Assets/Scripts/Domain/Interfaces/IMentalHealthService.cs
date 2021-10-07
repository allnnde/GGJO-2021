using Domain.Enums;
using System;
using UnityEngine;

namespace Domain.Interfaces
{
    public interface IMentalHealthService
    {
        void ChangeMentalHealthAnimator(PlayerMentalHealthEnum mentalHealth);
    }
}