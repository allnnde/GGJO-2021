using Assets.Scripts.Domain.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Enemy
{
    public class EnemyMovementDirectionService : IMovementDirectionService
    {
        public Vector2 GetDirection()
        {
            throw new System.NotImplementedException();
        }

        public Vector2 GetDirection(Vector2 direction)
        {
            var dir = Vector2Int.FloorToInt(direction);

            float x = 0;
            float y = 0;

            if (dir.x != 0)
                x = dir.x / Mathf.Abs(dir.x);

            if (dir.y != 0)
                y = dir.y / Mathf.Abs(dir.y);

            if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
                y = 0;
            else
                x = 0;
            return new Vector2(x, y);
        }
    }
}