using System.Collections.Generic;
using UnityEngine;


public class GameInit : MonoBehaviour
{


    public RuntimeAnimatorController AnimPlayerCuerdo;
    public RuntimeAnimatorController AnimPlayerNeutro;
    public RuntimeAnimatorController AnimPlayerLoco;


    public AudioClip ClipPlayerCuerdo;
    public AudioClip ClipPlayerLoco;

    private void Awake()
    {


       var _movimentBL = new PlayerMovimentBL();

        var _mentalHealthDictionary = new Dictionary<PlayerMentalHealthEnum, RuntimeAnimatorController>();
        _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Cuerdo, AnimPlayerCuerdo);
        _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Demente, AnimPlayerLoco);
        _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Neutro, AnimPlayerNeutro);

        var _mentalHealthBL = new PlayerMentalHealthBL(_mentalHealthDictionary);

        ServiceLocator.Instance.RegisterService<IPlayerMovimentBL>(_movimentBL);
        ServiceLocator.Instance.RegisterService<IMentalHealthBL>(_mentalHealthBL);


        var enemyMovimentBL = new EnemyMovimentBL();
        ServiceLocator.Instance.RegisterService<IEnemyMovimentBL>(enemyMovimentBL);



        var _audioDictionary = new Dictionary<PlayerMentalHealthEnum, AudioClip>();
        _audioDictionary.Add(PlayerMentalHealthEnum.Cuerdo, ClipPlayerCuerdo);
        _audioDictionary.Add(PlayerMentalHealthEnum.Demente, ClipPlayerLoco);

        var audioBL = new AudioBL(_audioDictionary);
        ServiceLocator.Instance.RegisterService<IAudioBL>(audioBL);


        


    }
}

