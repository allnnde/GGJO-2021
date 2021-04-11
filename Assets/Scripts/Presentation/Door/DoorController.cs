using Assets.Scripts.Domain.Enums;
using Assets.Scripts.Infrastructure.Dialog;
using Assets.Scripts.Infrastructure.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace Assets.Scripts.Presentation.Door
{
    public class DoorController : MonoBehaviour
    {

        public PlayerMentalHealthEnum NeededMetalHealthe;
        public GameObject Puesta;
        private DialogManager dialogManager;

        public Sprite Abierto;
        public Sprite Cerrado;

        public string NexLevel;
        private void Awake()
        {
            dialogManager = FindObjectOfType<DialogManager>();
            Puesta = transform.parent.gameObject;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
            if (collision.CompareTag("Player"))
            {
                var playerMentalHealth = collision.GetComponent<PlayerMentalHealthService>();
                if (playerMentalHealth.MentalState == NeededMetalHealthe)
                {
                    Puesta.GetComponent<SpriteRenderer>().sprite = Abierto;
                    dialogManager.Start_Dialog("Puesta", new List<string> { "Puesta Abierta" });

                    if (!string.IsNullOrEmpty(NexLevel))
                        SceneManager.LoadScene(NexLevel);
                    else
                    {
                        dialogManager.Start_Dialog("Puesta", new List<string> { "Pudsite escapar, felicidades" });
                        UnityEngine.Application.Quit();                    }

                }
                else
                {
                    Puesta.GetComponent<SpriteRenderer>().sprite = Cerrado;
                    dialogManager.Start_Dialog("Puesta", new List<string> { "Puesta Cerrada" });

                }

            }
        }


    }
}