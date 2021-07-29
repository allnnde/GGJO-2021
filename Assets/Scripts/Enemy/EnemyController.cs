using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private const string horizontal = "x";
    private const string vertical = "y";
    private const string lastHorizontal = "lastX";
    private const string lastVertical = "lastY";
    private const string walkingState = "Runing";

    public GameObject Route; //Variable que contiene todos los puntos donde el enemigo se va a mover
    public List<Vector3> PointsRoute { get; set; } //Variable que contiene los vectores del Route
    public Vector3 CurrentPointRoute { get; set; } //Variable que indica hacia donde se está moviendo el enemigo
    public float Velocity = 5f; //Velocidad de moviento del Enemigo
    public float RadiusOfView = 2f; //Radio de visión del Enemigo
    public GameObject Player { get; private set; } //Personaje
    public PlayerMentalHealthController PlayerMentalHealth { get; private set; }

    private NavMeshAgent navAgent; //Agente de navegacion

    public EnemyTypeEnum EnemyType;

    private DialogManager dialogManager;

    private Animator anim;

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
    } //Variable para indicar si el enemigo llegó al punto

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>(); //Consigues el NavMesh
        PointsRoute = new List<Vector3>(); //Creas la lista de puntos en Route
        foreach (Transform item in Route?.transform)
        {
            PointsRoute.Add(item.position); //añadís puntos a la lista
        }       

        CurrentPointRoute = PointsRoute.FirstOrDefault(); //Asignas al primer punto de la lista al CurrentPointRoute
  
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerMentalHealth = Player.GetComponent<PlayerMentalHealthController>();

        dialogManager = FindObjectOfType<DialogManager>();
        audioSource = FindObjectOfType<AudioManager>();
        anim = GetComponent<Animator>();
    }
    public Vector3 GetNextPointRoute() //Al llegar al punto seleccionado de la lista, se selecciona el siguiente
    {
        var index = PointsRoute.IndexOf(CurrentPointRoute);
        if (index == -1)
            return PointsRoute[0]; //Devuelve nada

        if (index + 1 < PointsRoute.Count())
            return PointsRoute[index + 1]; //Devuelve siguiente punto
        else
            return PointsRoute[0]; //Comenzar trayectoria denuevo

    }


    public void MoveToPoint(Vector3 point) //Mueve al enemigo al punto seleccionado
    {
        Vector3 dir = point - transform.position; //Calcula la dirección a la cual el enemigo tiene que ver
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;   //Calcula el angulo al cual tiene que rotar      
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward); //Rotar en esta cantidad de angulos

        float x = 0;
        float y = -1;


        if (dir.x != 0)
            x = dir.x / Mathf.Abs(dir.x);

        if (dir.y != 0)
            y = dir.y / Mathf.Abs(dir.y);

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            y = 0;
        else
            x = 0;



        anim.SetFloat(horizontal, x);
        anim.SetFloat(vertical, y);

        bool walking = false;
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            if (!navAgent.hasPath || Mathf.Abs(navAgent.velocity.sqrMagnitude) < float.Epsilon)
                walking = false;
        }
        else
        {
            walking = true;
        }

        anim.SetBool(walkingState, walking);

        anim.SetFloat(lastHorizontal, x);
        anim.SetFloat(lastVertical, y);

        navAgent.SetDestination(point); //Marca el destino en el NavAgent
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

            Debug.Log("EnemyType " + EnemyType);
            Debug.Log("PlayerMentalHealth.MentalState " + PlayerMentalHealth.MentalState);
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
    }


    private void OnDrawGizmos() //Dibuja el area de efecto en el editor
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadiusOfView);
    }
}
