using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMentalHealthBL : IMentalHealthBL
{
    private readonly Dictionary<PlayerMentalHealthEnum, RuntimeAnimatorController> _mentalHealthDictionary;

    public Action<RuntimeAnimatorController> ChangeMentalHealthAnimatorEvent { get; set; }
    public PlayerMentalHealthBL(Dictionary<PlayerMentalHealthEnum, RuntimeAnimatorController> mentalHealthDictionary)
    {
        _mentalHealthDictionary = mentalHealthDictionary;
    }

    public void ChangeMentalHealthAnimator(PlayerMentalHealthEnum mentalHealth)
    {

        Assert.IsNotNull(ChangeMentalHealthAnimatorEvent, "ChangeMentalHealthAnimatorEvent es null en implmentacion de PlayerMentalHealthBL");

        var mh = _mentalHealthDictionary[mentalHealth];

        ChangeMentalHealthAnimatorEvent?.Invoke(mh);
    }


}

