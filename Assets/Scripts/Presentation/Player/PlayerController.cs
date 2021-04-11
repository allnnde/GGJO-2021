using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovementService))]
[RequireComponent(typeof(PlayerMentalHealthService))]
public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;

    private IMovementDirectionService _movementDirectionService;
    private MovementBussinessLogic _movementBussinessLogic;

    public static GameObject Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = gameObject;
        }

    }


    void Start()
    {
        _movementDirectionService = new PlayerMovementDirectionService();
        _movementBussinessLogic = new MovementBussinessLogic(GetComponent<PlayerMovementService>());
    }

    void Update()
    {
        var direcion = _movementDirectionService.GetDirection();
        _movementBussinessLogic.Move(direcion, speed);
    }
}
