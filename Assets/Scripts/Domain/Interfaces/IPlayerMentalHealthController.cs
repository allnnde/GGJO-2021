using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Domain.Interfaces
{
    public interface IPlayerMentalHealthController
    {
        void ChangeMentalHealthAnimator(RuntimeAnimatorController mh);
    }
}