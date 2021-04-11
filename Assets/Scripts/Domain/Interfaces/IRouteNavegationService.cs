using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Domain.Interfaces
{
    public interface IRouteNavegationService
    {
        bool IsInCurrentPointRoute();
        Vector3 GetCurrentPointRoute();
        Vector3 GetNextPointRoute();
    }
}