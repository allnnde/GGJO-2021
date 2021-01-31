using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;

    private bool walking = false;
    private Vector2 lastMovement = Vector2.zero;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";
    private const string walkingState = "Walking";

    private Rigidbody2D playerRb;
    private Animator anim;
    public PlayerMentalHealthController PlayerMentalHealth { get; private set; }

    public static bool playerCreated;

    private void Awake()
    {       
        PlayerMentalHealth = GetComponent<PlayerMentalHealthController>();
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        lastMovement = new Vector2(0, 0);
    }

    void Update()
    {
        walking = false;
        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f || Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5)
        {
            walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
            playerRb.velocity = lastMovement.normalized * speed;
        }


        if (!walking)
        {
            playerRb.velocity = Vector2.zero;
        }

        anim.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        anim.SetFloat(vertical, Input.GetAxisRaw(vertical));

        anim.SetBool(walkingState, walking);

        anim.SetFloat(lastHorizontal, lastMovement.x);
        anim.SetFloat(lastVertical, lastMovement.y);
    }

}
