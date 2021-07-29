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

    private Rigidbody2D _playerRb;
    private Animator _anim;
    public PlayerMentalHealthController PlayerMentalHealth { get; private set; }

    private IMovimentBL _movimentBL;

    private void Awake()
    {
        PlayerMentalHealth = GetComponent<PlayerMentalHealthController>();
        _playerRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _movimentBL = new PlayerMovimentBL();

        _movimentBL.MoveEvent += Move;
        _movimentBL.MoveAnimationEvent += Move;

    }

    void Start()
    {

        lastMovement = new Vector2(0, 0);

        Time.timeScale = 1;
    }

    void Update()
    {
        var lastMovement = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
        _movimentBL.Move(lastMovement.normalized, speed);
    }


    public void MoveAnimation(Vector3 direction)
    {
        if (direction.x == 0 && direction.y > 0)
            _anim.Play(AnimationLabelConstants.WalkingTopLabel);
        if (direction.x == 0 && direction.y < 0)
            _anim.Play(AnimationLabelConstants.WalkingBottomLabel);

        if (direction.x < 0 && direction.y == 0)
            _anim.Play(AnimationLabelConstants.WalkingLeftLabel);
        if (direction.x > 0 && direction.y == 0)
            _anim.Play(AnimationLabelConstants.WalkingRightLabel);
        if (direction.x == 0 && direction.y == 0)
            _anim.Play(AnimationLabelConstants.IdleLabel);
    }


    private void Move(Vector2 direction)
    {
        _playerRb.velocity = direction;
    }

}
