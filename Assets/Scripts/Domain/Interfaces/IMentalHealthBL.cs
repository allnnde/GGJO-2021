using System;
using UnityEngine;

public interface IMentalHealthBL
{
    public Action<RuntimeAnimatorController> OnChangeMentalHealthAnimator { get; set; }
    void ChangeMentalHealthAnimator(PlayerMentalHealthEnum mentalHealth);
}