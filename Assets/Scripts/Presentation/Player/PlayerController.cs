using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;

    public PlayerMentalHealthEnum CurrentMentalState;

    private Dictionary<PlayerMentalHealthEnum, RuntimeAnimatorController> _mentalHealthDictionary;

    private Rigidbody2D _playerRb;
    private Animator _anim;

    private IPlayerMovimentBL _movimentBL;
    private IMentalHealthBL _mentalHealthBL;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        
        _movimentBL = ServiceLocator.Instance.GetService<IPlayerMovimentBL>();
        _mentalHealthBL = ServiceLocator.Instance.GetService<IMentalHealthBL>();

        _movimentBL.MoveEvent += Move;
        _movimentBL.MoveAnimationEvent += MoveAnimation;
        _mentalHealthBL.ChangeMentalHealthAnimatorEvent += ChangeMentalHealthAnimator;

    }

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        var lastMovement = new Vector2(Input.GetAxisRaw(AxisLabelConstants.HorizontalLabel), Input.GetAxisRaw(AxisLabelConstants.VerticalLabel));
        _movimentBL.Move(lastMovement, speed);
    }


    private void MoveAnimation(string animation)
    {
        if(!animation.Equals(string.Empty))
        _anim.Play(animation);
    }

    public void ChangeMentalHealth(PlayerMentalHealthEnum playerMentalHealth)
    {
        CurrentMentalState = playerMentalHealth;
        _mentalHealthBL.ChangeMentalHealthAnimator(CurrentMentalState);
    }


    private void Move(Vector2 direction)
    {
        _playerRb.velocity = direction;
    }

    private void ChangeMentalHealthAnimator(RuntimeAnimatorController aminPlayer)
    {
        _anim.runtimeAnimatorController = aminPlayer;
    }
}
