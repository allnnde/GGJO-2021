using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IDialogService
    {
        void HiddenDialog();

        void NextText();

        void ShowDialog();

        void StartDialog(List<string> conversation);
    }
}