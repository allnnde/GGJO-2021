using Domain.Emuns;
using Presentation.Dialog;
using Presentation.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Presentation.Door
{
    public class DoorController : MonoBehaviour
    {
        public PlayerMentalHealthEnum NeededMetalHealthe;
        public GameObject Door;
        private DialogManager _dialogManager;
        private SpriteRenderer _doorSpriteRenderer;

        public Sprite Opened;
        public Sprite Closed;

        public string NextLevel;

        private void Awake()
        {
            _dialogManager = FindObjectOfType<DialogManager>();
            Door = transform.parent.gameObject;
            _doorSpriteRenderer = Door.GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                var playerMentalHealth = collision.GetComponent<PlayerController>();
                if (playerMentalHealth.CurrentMentalState == NeededMetalHealthe)
                {
                    _doorSpriteRenderer.sprite = Opened;
                    _dialogManager.Start_Dialog("Puesta", new List<string> { "Puesta Abierta" });

                    if (!string.IsNullOrEmpty(NextLevel))
                        SceneManager.LoadScene(NextLevel);
                    else
                    {
                        _dialogManager.Start_Dialog("Puesta", new List<string> { "Pudsite escapar, felicidades" });
                        UnityEngine.Application.Quit();
                    }
                }
                else
                {
                    _doorSpriteRenderer.sprite = Closed;
                    _dialogManager.Start_Dialog("Puesta", new List<string> { "Puesta Cerrada" });
                }
            }
        }
    }
}