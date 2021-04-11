using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyMovementService))]
public class EnemyController : MonoBehaviour
{

    public GameObject Route;
    public List<Vector3> PointsRoute { get; set; }
    public Vector3 CurrentPointRoute { get; set; }
    public float Velocity = 5f;
    public float RadiusOfView = 2f;
    public GameObject Player { get; private set; }
    public PlayerMentalHealthController PlayerMentalHealth { get; private set; }


    public EnemyTypeEnum EnemyType;

    private DialogManager dialogManager;
    public string Name;
    public List<string> dialogs;


    private AudioManager audioSource;
    public bool InCurrentPointRoute
    {
        get
        {
            var distancia = Vector3.Distance(CurrentPointRoute, transform.position);
            return distancia < 1.01f;
        }
    }

    private void Awake()
    {
        PointsRoute = new List<Vector3>();
        foreach (Transform item in Route?.transform)
        {
            PointsRoute.Add(item.position);
        }

        CurrentPointRoute = PointsRoute.FirstOrDefault();

        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerMentalHealth = Player.GetComponent<PlayerMentalHealthController>();

        dialogManager = FindObjectOfType<DialogManager>();
        audioSource = FindObjectOfType<AudioManager>();
    }
    public Vector3 GetNextPointRoute()
    {
        var index = PointsRoute.IndexOf(CurrentPointRoute);
        if (index == -1)
            return PointsRoute[0];

        if (index + 1 < PointsRoute.Count())
            return PointsRoute[index + 1];
        else
            return PointsRoute[0];

    }

    public bool PlayerInView() //Saber si el Player se encuentra dentro del rango de visión
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, RadiusOfView); //Genera circulos alrededor del enemigo. Si el Player colisiona con estos, se activará el enemigo
        if (colliders != null) //Si hay colision
        {
            foreach (var item in colliders) //recorro todos los coliders
            {
                if (item.CompareTag("Player")) //si el colider tiene el tag: "Player", hay que devolver un "true"
                    return true;
            }
        }
        return false; //De lo contrario, devolver "false"
    }

    public bool ShouldFollowPlayer() //Saber si el Player se encuentra dentro del rango de visión
    {
        if (EnemyType == EnemyTypeEnum.Medico && PlayerMentalHealth.MentalState == PlayerMentalHealthEnum.Demente)
        {
            return true;
        }

        if (EnemyType == EnemyTypeEnum.Paciente && PlayerMentalHealth.MentalState == PlayerMentalHealthEnum.Cuerdo)
        {
            return true;
        }
        return false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractWithPlayer();
        }
    }

    private void InteractWithPlayer()
    {
        if (EnemyType == EnemyTypeEnum.Medico && PlayerMentalHealth.MentalState != PlayerMentalHealthEnum.Cuerdo)
        {
            dialogManager.Start_Dialog(Name, dialogs);
            PlayerMentalHealth.ChangeMentalHealth(PlayerMentalHealthEnum.Cuerdo);
            audioSource.PlayCuerdo();
        }

        if (EnemyType == EnemyTypeEnum.Paciente && PlayerMentalHealth.MentalState != PlayerMentalHealthEnum.Demente)
        {
            dialogManager.Start_Dialog(Name, dialogs);
            PlayerMentalHealth.ChangeMentalHealth(PlayerMentalHealthEnum.Demente);
            audioSource.PlayLoco();
        }
    }

    private void OnDrawGizmos() //Dibuja el area de efecto en el editor
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadiusOfView);
    }
}
