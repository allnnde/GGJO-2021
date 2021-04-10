using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    private const string WalkingTopLabel = "WalkingTop";
    private const string WalkingBottomLabel = "WalkingBottom";
    private const string WalkingLeftLabel = "WalkingLeft";
    private const string WalkingRightLabel = "WalkingRight";
    private const string IdleLabel = "Idle";

    public GameObject Route;
    public List<Vector3> PointsRoute { get; set; }
    public Vector3 CurrentPointRoute { get; set; }
    public float Velocity = 5f;
    public float RadiusOfView = 2f;
    public GameObject Player { get; private set; }
    public PlayerMentalHealthController PlayerMentalHealth { get; private set; }

    private NavMeshAgent navAgent;

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
    }

    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
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
        anim = GetComponent<Animator>();
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

    public void Move(Vector2 point)
    {

        var direction = GetDirection(point);

        ShowMoveAnimation(direction);

        navAgent.SetDestination(point);
    }

    private void ShowMoveAnimation(Vector2 direction)
    {

        var walking = navAgent.remainingDistance > navAgent.stoppingDistance &&
                      navAgent.hasPath && Mathf.Abs(navAgent.velocity.sqrMagnitude) > 0;

        if (direction.x == 0 && direction.y > 0 && walking)
            anim.Play(WalkingTopLabel);
        if (direction.x == 0 && direction.y < 0 && walking)
            anim.Play(WalkingBottomLabel);

        if (direction.x < 0 && direction.y == 0 && walking)
            anim.Play(WalkingLeftLabel);
        if (direction.x > 0 && direction.y == 0 && walking)
            anim.Play(WalkingRightLabel);

        if (direction.x == 0 && direction.y == 0 && !walking)
            anim.Play(IdleLabel);
    }

    private Vector2 GetDirection(Vector3 point)
    {
        var dir = Vector2Int.FloorToInt(point - transform.position);
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);

        float x = 0;
        float y = 0;

        if (dir.x != 0)
            x = dir.x / Mathf.Abs(dir.x);

        if (dir.y != 0)
            y = dir.y / Mathf.Abs(dir.y);

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            y = 0;
        else
            x = 0;

        return new Vector2(x, y);
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
