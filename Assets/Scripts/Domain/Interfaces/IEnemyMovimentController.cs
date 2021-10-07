using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Domain.Interfaces
{
    public interface IEnemyMovimentController
    {
        void MoveAnimation(string animation);

        void Move(Vector2 point);
    }
}