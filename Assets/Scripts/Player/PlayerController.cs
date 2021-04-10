using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;

    private const string horizontalLabel = "Horizontal";
    private const string verticalLabel = "Vertical";
    private const string WalkingTopLabel = "WalkingTop";
    private const string WalkingBottomLabel = "WalkingBottom";
    private const string WalkingLeftLabel = "WalkingLeft";
    private const string WalkingRightLabel = "WalkingRight";
    private const string IdleLabel = "Idle";
    private Rigidbody2D playerRb;
    private Animator anim;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        var direcion = GetDirection();

        Move(direcion);

        ShowAnimation(direcion);
    }


    private Vector2 GetDirection()
    {
        var horizantal = Input.GetAxisRaw(horizontalLabel);
        var vertical = Input.GetAxisRaw(verticalLabel);

        return new Vector2(horizantal, vertical);
    }

    private void ShowAnimation(Vector2 direction)
    {   
        if (direction.x == 0  && direction.y > 0)
            anim.Play(WalkingTopLabel);
        if (direction.x == 0  && direction.y < 0)
            anim.Play(WalkingBottomLabel);

        if (direction.x < 0 && direction.y == 0)
            anim.Play(WalkingLeftLabel);
        if (direction.x > 0 && direction.y == 0)
            anim.Play(WalkingRightLabel);

        if (direction.x == 0 && direction.y == 0)
            anim.Play(IdleLabel);
    }

    private void Move(Vector2 direction)
    {
        playerRb.velocity = direction.normalized * speed;
    }
}
