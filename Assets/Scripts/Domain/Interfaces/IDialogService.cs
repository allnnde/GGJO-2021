using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Domain.Interfaces
{
    public interface IDialogService
    {
        void StartDialog(string name, string test);
        void StopDialog();
    }
}
