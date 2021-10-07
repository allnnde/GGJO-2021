using System;
using UnityEngine;

namespace Domain.Interfaces
{
    public interface IPlayerMovimentService
    {
        void Move(Vector2 direction, float speed);
    }
}