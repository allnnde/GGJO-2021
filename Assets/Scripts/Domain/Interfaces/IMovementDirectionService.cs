using UnityEngine;

namespace Assets.Scripts.Domain.Interfaces
{
    public interface IMovementDirectionService
    {
        Vector2 GetDirection();
        Vector2 GetDirection(Vector2 direction);
    }
}