using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State currentState;

    void Awake()
    {
        currentState = GetComponent<PatrolState>();
        if (currentState == null)
        {
            currentState = gameObject.AddComponent<PatrolState>();
        }
        currentState.enabled = true; 
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
