using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementService))]
public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;


    private Rigidbody2D _playerRb;
    private Animator _anim;

    private IMovementDirectionService _movementDirectionService;
    private MovementBussinessLogic _movementController;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _movementDirectionService = new PlayerMovementDirectionService();
        _movementController = new MovementBussinessLogic(GetComponent<PlayerMovementService>());
    }

    void Update()
    {
        var direcion = _movementDirectionService.GetDirection();
        _movementController.Move(direcion, speed);
        _movementController.ShowMoveAnimation(direcion);
    }
}
