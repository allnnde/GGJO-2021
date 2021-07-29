using System;
using UnityEngine;

public interface IMentalHealthBL
{
    public Action<RuntimeAnimatorController> ChangeMentalHealthAnimatorEvent { get; set; }
    void ChangeMentalHealthAnimator(PlayerMentalHealthEnum mentalHealth);
}