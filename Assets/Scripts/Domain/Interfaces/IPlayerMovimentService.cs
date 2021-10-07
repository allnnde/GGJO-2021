using System;
using UnityEngine;

namespace Domain.Interfaces
{
    public interface IPlayerMovimentService
    {
        Action<Vector2> OnMove { get; set; }
        Action<string> OnMoveAnimation { get; set; }

        void Move(Vector2 direction, float speed);
    }
}