using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            var playerMentalHealth = collision.GetComponent<PlayerMentalHealthController>();
            if (playerMentalHealth.MentalState == NeededMetalHealthe)
            {
                Puesta.GetComponent<SpriteRenderer>().sprite = Abierto;
                dialogManager.Start_Dialog("Puesta", new List<string> { "Puesta Abierta" });

                if (!string.IsNullOrEmpty(NexLevel))
                    SceneManager.LoadScene(NexLevel);
                else
                    dialogManager.Start_Dialog("Puesta", new List<string> { "Pudsite escapar, felicidades" });

            }
            else
            {
                Puesta.GetComponent<SpriteRenderer>().sprite = Cerrado;
                dialogManager.Start_Dialog("Puesta", new List<string> { "Puesta Cerrada" });

            }

        }
    }


}
