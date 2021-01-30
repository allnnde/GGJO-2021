using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public float checkExitRate;
    private State currentState;

    void Awake()
    {

        currentState = GetComponent<PatrolState>();
        if (currentState == null)
        {
            currentState = gameObject.AddComponent<PatrolState>();
        }
        currentState.enabled = true;
        //InvokeRepeating("Check", 0, checkExitRate);
    }

    void Update()
    {
        currentState.CheckExit();

    }

    public void ChangeState<TState>() where TState : State
    {
        var newState = GetComponent<TState>();
        if (newState == null)
        {
            newState = gameObject.AddComponent<TState>();
        }

        currentState.enabled = false;
        currentState = newState;
        currentState.enabled = true;
    }
}
