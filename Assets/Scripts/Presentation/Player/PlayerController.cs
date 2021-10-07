using Domain.Emuns;
using Domain.Interfaces;
using Presentation.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 4.0f;

        public PlayerMentalHealthEnum CurrentMentalState;

        private Rigidbody2D _playerRb;
        private Animator _anim;

        private IPlayerMovimentService _movimentService;
        private IMentalHealthService _mentalHealthService;
        private AudioController _audioSource;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
            _audioSource = FindObjectOfType<AudioController>();

            Configuration();
        }

        private void Configuration()
        {
            _movimentService = ServiceLocator.Instance.GetServiceSingleton<IPlayerMovimentService>();
            _mentalHealthService = ServiceLocator.Instance.GetServiceSingleton<IMentalHealthService>();

            _movimentService.OnMove += Move;
            _movimentService.OnMoveAnimation += MoveAnimation;
            _mentalHealthService.OnChangeMentalHealthAnimator += ChangeMentalHealthAnimator;
        }

        private void Start()
        {
            Time.timeScale = 1;
        }

        private void Update()
        {
            var lastMovement = new Vector2(Input.GetAxisRaw(AxisLabelConstants.HorizontalLabel), Input.GetAxisRaw(AxisLabelConstants.VerticalLabel));
            _movimentService.Move(lastMovement, speed);
        }

        private void MoveAnimation(string animation)
        {
            if (!animation.Equals(string.Empty))
                _anim.Play(animation);
        }

        public void ChangeMentalHealth(PlayerMentalHealthEnum playerMentalHealth)
        {
            CurrentMentalState = playerMentalHealth;
            _mentalHealthService.ChangeMentalHealthAnimator(CurrentMentalState);
            _audioSource.PlayClipToMentalHealth(CurrentMentalState);
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
}