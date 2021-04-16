using Application.Common;
using Domain.Enums;
using Infrastructure.Dialog;
using Infrastructure.Player;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Presentation.Door
{
    public class DoorController : MonoBehaviour
    {
        public Sprite Open;
        public Sprite Close;
        public PlayerMentalHealthEnum NeededMetalHealthe;
        public string NexLevel;
        private SpriteRenderer _spriteRenderer;
        private DialogBussinessLogic dialogManager;

        private GameObject _door;
        private const string nombre = "Puesta";

        private void Awake()
        {
            var dialogservice = FindObjectOfType<DialogService>();
            dialogManager = new DialogBussinessLogic(dialogservice);
            _door = transform.parent.gameObject;
            _spriteRenderer = _door.GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
            if (collision.CompareTag("Player"))
            {
                var playerMentalHealth = collision.GetComponent<PlayerMentalHealthService>();
                if (playerMentalHealth.MentalState == NeededMetalHealthe)
                {
                    changeDoorSprite(Open);
                    dialogManager.StartDialog(nombre, "Puesta Abierta");

                    if (!string.IsNullOrEmpty(NexLevel))
                        SceneManager.LoadScene(NexLevel);
                    else
                    {
                        dialogManager.StartDialog(nombre, "Pudiste escapar, felicidades");
                        UnityEngine.Application.Quit();
                    }
                }
                else
                {
                    changeDoorSprite(Close);
                    dialogManager.StartDialog(nombre, "Puesta Cerrada");
                }
            }
        }

        private void changeDoorSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
    }
}