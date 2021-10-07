using System;
using System.Collections.Generic;

public interface IDialogBL
{
    Action<bool> OnDialogActive { get; set; }
    Action<string> OnShowText { get; set; }

    void HiddenDialog();

    void NextText();

    void ShowDialog();

    void StartDialog(List<string> conversation);
}