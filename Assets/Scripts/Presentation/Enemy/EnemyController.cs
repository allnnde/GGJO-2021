using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject Route; 
    public List<Vector3> PointsRoute { get; set; } 
    public Vector3 CurrentPointRoute { get; set; } 
    public float Velocity = 5f;
    public float RadiusOfView = 2f;
    public PlayerController Player { get; private set; } //Personaje

    private NavMeshAgent _navAgent; //Agente de navegacion

    public EnemyTypeEnum EnemyType;

    private DialogManager dialogManager;

    private Animator _anim;

    public string Name;
    public List<string> dialogs;


    public IEnemyMovimentBL MovimentBL;


    private AudioManager audioSource;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>(); //Consigues el NavMesh
        PointsRoute = new List<Vector3>(); //Creas la lista de puntos en Route
        foreach (Transform item in Route?.transform)
        {
            PointsRoute.Add(item.position); //añadís puntos a la lista
        }

        CurrentPointRoute = PointsRoute.FirstOrDefault(); //Asignas al primer punto de la lista al CurrentPointRoute

        Player = FindObjectOfType<PlayerController>();
        dialogManager = FindObjectOfType<DialogManager>();
        audioSource = FindObjectOfType<AudioManager>();
        _anim = GetComponent<Animator>();

        Configuration();
    }

    private void Configuration()
    {
        MovimentBL = ServiceLocator.Instance.GetService<IEnemyMovimentBL>(ServicesLifecycleEnum.Scoped);
        MovimentBL.MoveEvent += Move;
        MovimentBL.MoveAnimationEvent += MoveAnimation;
    }

    private void Move(Vector2 point)
    {
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        _navAgent.SetDestination(point);
    }

    private void MoveAnimation(string animation)
    {
        _anim.Play(animation);
    }

    public void MoveToPoint(Vector3 point)
    {
        var walking = _navAgent.remainingDistance > _navAgent.stoppingDistance &&
                     _navAgent.hasPath && Mathf.Abs(_navAgent.velocity.sqrMagnitude) > 0;

        MovimentBL.Move(point, transform.position, walking);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (EnemyType == EnemyTypeEnum.Medico && Player.CurrentMentalState != PlayerMentalHealthEnum.Cuerdo)
            {
                dialogManager.Start_Dialog(Name, dialogs);
                Player.ChangeMentalHealth(PlayerMentalHealthEnum.Cuerdo);
                audioSource.PlayCuerdo();
            }

            if (EnemyType == EnemyTypeEnum.Paciente && Player.CurrentMentalState != PlayerMentalHealthEnum.Demente)
            {
                dialogManager.Start_Dialog(Name, dialogs);
                Player.ChangeMentalHealth(PlayerMentalHealthEnum.Demente);
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
