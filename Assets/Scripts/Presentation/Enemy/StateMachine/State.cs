using Presentation.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation.Enemy.StateMachine
{
    [RequireComponent(typeof(StateMachine))]
    [RequireComponent(typeof(EnemyController))]
    public abstract class State : MonoBehaviour
    {
        protected StateMachine StateMachine;
        protected EnemyController Enemy;

        private void Awake()
        {
            StateMachine = GetComponent<StateMachine>();
            Enemy = GetComponent<EnemyController>();
        }

        public abstract void CheckExit();
    }
}