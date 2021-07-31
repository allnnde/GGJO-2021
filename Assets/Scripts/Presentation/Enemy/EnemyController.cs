using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyController : MonoBehaviour
{
    public GameObject Route; 
    public List<Vector3> PointsRoute { get; set; } 
    public Vector3 CurrentPointRoute { get; set; } 
    public float Velocity = 5f;
    public float RadiusOfView = 2f;
    public PlayerController Player { get; private set; }

    private NavMeshAgent _navAgent;

    //TODO esto se puede eliminar, ahi que modificar el ShouldFollowPlayer
    public EnemyTypeEnum EnemyType;

    protected DialogManager dialogManager;

    private Animator _anim;

    public string Name;

    public List<string> dialogs;
    public IEnemyMovimentBL MovimentBL;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>(); 
        PointsRoute = new List<Vector3>(); 
        foreach (Transform item in Route?.transform)
        {
            PointsRoute.Add(item.position);
        }

        CurrentPointRoute = PointsRoute.FirstOrDefault();

        Player = FindObjectOfType<PlayerController>();
        dialogManager = FindObjectOfType<DialogManager>();
        _anim = GetComponent<Animator>();

        Configuration();
    }

    private void Configuration()
    {
        MovimentBL = ServiceLocator.Instance.GetServiceScoped<IEnemyMovimentBL>();
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
            InteractuePlayer();
        }
    }

    public abstract void InteractuePlayer();


    private void OnDrawGizmos() //Dibuja el area de efecto en el editor
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadiusOfView);
    }
}
