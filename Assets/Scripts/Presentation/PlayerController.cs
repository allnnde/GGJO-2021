using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;

    public PlayerMentalHealthEnum CurrentMentalState;

    public RuntimeAnimatorController AnimPlayerCuerdo;
    public RuntimeAnimatorController AnimPlayerNeutro;
    public RuntimeAnimatorController AnimPlayerLoco;

    private Dictionary<PlayerMentalHealthEnum, RuntimeAnimatorController> _mentalHealthDictionary;


    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";

    private Rigidbody2D _playerRb;
    private Animator _anim;

    private IMovimentBL _movimentBL;
    private IMentalHealthBL _mentalHealthBL;

    

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

        _movimentBL = new PlayerMovimentBL();
        _movimentBL.MoveEvent += Move;
        _movimentBL.MoveAnimationEvent += MoveAnimation;

        _mentalHealthDictionary = new Dictionary<PlayerMentalHealthEnum, RuntimeAnimatorController>();
        _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Cuerdo, AnimPlayerCuerdo);
        _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Demente, AnimPlayerLoco);
        _mentalHealthDictionary.Add(PlayerMentalHealthEnum.Neutro, AnimPlayerNeutro);

        _mentalHealthBL = new PlayerMentalHealthBL(_mentalHealthDictionary);
        _mentalHealthBL.ChangeMentalHealthAnimatorEvent += ChangeMentalHealthAnimator;

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
