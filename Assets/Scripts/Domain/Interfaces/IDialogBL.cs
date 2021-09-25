using System;
using System.Collections.Generic;

public interface IDialogBL
{
    Action<bool> DialogActive { get; set; }
    Action<string> ShowText { get; set; }

    void HiddenDialog();

    void NextText();

    void ShowDialog();

    void StartDialog(List<string> conversation);
}