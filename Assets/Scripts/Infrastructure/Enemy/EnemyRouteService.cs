using Assets.Scripts.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Enemy
{
    public class EnemyRouteService : MonoBehaviour, IRouteNavegationService
    {
        public GameObject Route;
        private Vector3 _currentPointRoute;
        private List<Vector3> _pointsRoute;

        public Vector3 GetCurrentPointRoute()
        {
            return _currentPointRoute;
        }

        public Vector3 GetNextPointRoute()
        {
            var index = _pointsRoute.IndexOf(_currentPointRoute);
            if (index == -1)
                _currentPointRoute = _pointsRoute[0];

            if (index + 1 < _pointsRoute.Count())
                _currentPointRoute = _pointsRoute[index + 1];
            else
                _currentPointRoute = _pointsRoute[0];

            return _currentPointRoute;
        }

        public bool IsInCurrentPointRoute()
        {
            var distancia = Vector3.Distance(_currentPointRoute, transform.position);
            return distancia < 1.01f;
        }

        public void Start()
        {
            _pointsRoute = new List<Vector3>();
            foreach (Transform item in Route?.transform)
            {
                _pointsRoute.Add(item.position);
            }

            _currentPointRoute = _pointsRoute.FirstOrDefault();
        }
    }
}