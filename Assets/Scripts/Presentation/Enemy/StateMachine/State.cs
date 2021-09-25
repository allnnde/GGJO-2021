using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(EnemyController))]
public abstract class State : MonoBehaviour
{
    protected StateMachine StateMachine; 
    protected EnemyController Enemy;
    protected IEnemyMovimentBL MovimentBL;

    void Awake()
    {
        StateMachine = GetComponent<StateMachine>(); 
        Enemy = GetComponent<EnemyController>();
        MovimentBL = Enemy.MovimentBL;
    }

    public abstract void CheckExit(); //Metodo para verificar la salida de los estados
}
