using UnityEngine;

namespace Presentation.Enemy.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        private State currentState; //El estado

        public void ChangeState<TState>() where TState : State //Metodo que cambia el estado
        {
            var newState = GetComponent<TState>(); //Busca el estado que le pasamos al metodo
            if (newState == null) //Si el nuevo estado equivale a "null", se le asigna automaticamente
            {
                newState = gameObject.AddComponent<TState>();
            }

            currentState.enabled = false; //Desactivamos el estado actual
            currentState = newState; //Asignamos el nuevo estado al estado actual
            currentState.enabled = true; //El nuevo estado es activado
        }

        private void Awake()
        {
            currentState = GetComponent<PatrolState>(); //EL estado inicial es el de Patrullaje
            if (currentState == null) //Si no existe este estado se le asigna automaticamente
            {
                currentState = gameObject.AddComponent<PatrolState>();
            }
            currentState.enabled = true; //El estado es activado
        }

        private void Update()
        {
            currentState.CheckExit(); //Al estado que se encuentre activo se le verifica su condicion de salida
        }
    }
}