using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(EnemyController))]
public abstract class State : MonoBehaviour
{
    protected StateMachine StateMachine;
    protected EnemyController Enemy;

    void Awake()
    {
        StateMachine = GetComponent<StateMachine>();
        Enemy = GetComponent<EnemyController>();
    }

    public abstract void CheckExit();
}
