using System;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IDialogService
    {
        Action<bool> OnDialogActive { get; set; }
        Action<string> OnShowText { get; set; }

        void HiddenDialog();

        void NextText();

        void ShowDialog();

        void StartDialog(List<string> conversation);
    }
}