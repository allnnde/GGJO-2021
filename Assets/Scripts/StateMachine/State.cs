using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(EnemyController))]
public abstract class State : MonoBehaviour
{
    protected StateMachine StateMachine; //Maquina de estado
    protected EnemyController Enemy; //Enemigo

    void Awake()
    {
        StateMachine = GetComponent<StateMachine>(); //La maquina de estado obtiene el componente "Maquina de estado"
        Enemy = GetComponent<EnemyController>(); //El enemigo obtiene el componente "EnemyController"
    }

    public abstract void CheckExit(); //Metodo para verificar la salida de los estados
}
