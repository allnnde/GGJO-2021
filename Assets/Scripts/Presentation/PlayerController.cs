using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;

    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    private Rigidbody2D _playerRb;
    private Animator _anim;

    private IMovimentBL _movimentBL;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _movimentBL = new PlayerMovimentBL();
        _movimentBL.MoveEvent += Move;
        _movimentBL.MoveAnimationEvent += MoveAnimation;

    }

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        var lastMovement = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
        _movimentBL.Move(lastMovement, speed);
    }


    public void MoveAnimation(string animation)
    {
        _anim.Play(animation);
    }


    private void Move(Vector2 direction)
    {
        _playerRb.velocity = direction;
    }

}
