using Assets.Scripts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Application
{
    public class RouteNavegationBussinessLogic
    {
        private readonly IRouteNavegationService _routeNavegationService;

        public RouteNavegationBussinessLogic(IRouteNavegationService routeNavegationService)
        {
            _routeNavegationService = routeNavegationService;
        }


        public bool IsInCurrentPointRoute()
        {
            return _routeNavegationService.IsInCurrentPointRoute();
        }
        public Vector3 GetCurrentPointRoute()
        {
            return _routeNavegationService.GetCurrentPointRoute();

        }
        public Vector3 GetNextPointRoute()
        {
            var point = _routeNavegationService.GetNextPointRoute();
            return point;
        }






    }
}