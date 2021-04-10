using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMoventService))]
public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;


    private Rigidbody2D _playerRb;
    private Animator _anim;

    private IInputService _inputDataService;
    private MovementController _movementController;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _inputDataService = new InputDataService();
        _movementController = new MovementController(GetComponent<PlayerMoventService>());
    }

    void Update()
    {
        var direcion = _inputDataService.GetDirection();
        _movementController.Move(direcion,speed);
    }
}
