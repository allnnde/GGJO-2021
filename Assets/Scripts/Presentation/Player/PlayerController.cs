using Application;
using Domain.Interfaces;
using Infrastructure.Player;
using UnityEngine;

namespace Presentation.Player
{
    [RequireComponent(typeof(PlayerMovementService))]
    [RequireComponent(typeof(PlayerMentalHealthService))]
    public class PlayerController : MonoBehaviour
    {
        public static GameObject Instance;
        public float speed = 4.0f;

        private MovementBussinessLogic _movementBussinessLogic;
        private IMovementDirectionService _movementDirectionService;

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

        private void Start()
        {
            _movementDirectionService = new PlayerMovementDirectionService();
            _movementBussinessLogic = new MovementBussinessLogic(GetComponent<PlayerMovementService>());
        }

        private void Update()
        {
            var direcion = _movementDirectionService.GetDirection();
            _movementBussinessLogic.Move(direcion, speed);
        }
    }
}