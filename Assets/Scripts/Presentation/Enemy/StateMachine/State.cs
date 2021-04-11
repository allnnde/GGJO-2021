using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
[RequireComponent(typeof(EnemyController))]
public abstract class State : MonoBehaviour
{
    protected StateMachine StateMachine; 
    protected EnemyController Enemy;
    protected MovementBussinessLogic movementController;
    protected EnemyMovementDirectionService _enemyMovementDirectionService;

    void Awake()
    {
        StateMachine = GetComponent<StateMachine>();
        Enemy = GetComponent<EnemyController>();
        var enemyMovementController = Enemy.GetComponent<IMovementMotor>();
        movementController = new MovementBussinessLogic(enemyMovementController);
        _enemyMovementDirectionService = new EnemyMovementDirectionService();
    }

    protected Vector2 GetDirectionAnimation(Vector3 point)
    {
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        var position = point - transform.position;
        var direction = _enemyMovementDirectionService.GetDirection(position);
        return direction;
    }

    public abstract void CheckExit(); //Metodo para verificar la salida de los estados
}
