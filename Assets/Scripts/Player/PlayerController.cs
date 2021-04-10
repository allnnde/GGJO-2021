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

        var direcion = GetInputData();

        Move(direcion.x, direcion.y);

        ShowAnimation(direcion.x, direcion.y);
    }


    private Vector2 GetInputData()
    {
        var horizantal = Input.GetAxisRaw(horizontalLabel);
        var vertical = Input.GetAxisRaw(verticalLabel);

        return new Vector2(horizantal, vertical);
    }

    private void ShowAnimation(float horizantal, float vertical)
    {   


        if (vertical > 0 && horizantal == 0)
            anim.Play(WalkingTopLabel);
        if (vertical < 0 && horizantal == 0)
            anim.Play(WalkingBottomLabel);

        if (horizantal < 0 && vertical == 0)
            anim.Play(WalkingLeftLabel);
        if (horizantal > 0 && vertical == 0)
            anim.Play(WalkingRightLabel);

        if (horizantal == 0 && vertical == 0)
            anim.Play(IdleLabel);

    }

    private void Move(float horizantal, float vertical)
    {
        playerRb.velocity = new Vector2(horizantal, vertical).normalized * speed;

    }
}
