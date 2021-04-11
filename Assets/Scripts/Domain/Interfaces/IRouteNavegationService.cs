using UnityEngine;

namespace Assets.Scripts.Domain.Interfaces
{
    public interface IRouteNavegationService
    {
        Vector3 GetCurrentPointRoute();

        Vector3 GetNextPointRoute();

        bool IsInCurrentPointRoute();
    }
}