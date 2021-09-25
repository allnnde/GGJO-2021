using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DialogBL : IDialogBL
{
    public Action<bool> DialogActive { get; set; }
    public Action<string> ShowText { get; set; }
    private List<string> _conversation;
    private int _converIndex;

    public void HiddenDialog()
    {
        DialogActive?.Invoke(false);
    }

    public void ShowDialog()
    {
        DialogActive?.Invoke(true);
    }

    public void StartDialog(List<string> conversation)
    {
        Time.timeScale = 0;
        _conversation = conversation;
        _converIndex = 0;
        ShowText?.Invoke(_conversation[_converIndex]);
    }

    public void NextText()
    {
        if (_converIndex < _conversation.Count - 1)
        {
            _converIndex++;
            ShowText?.Invoke(_conversation[_converIndex]);
        }
        else
        {
            StopDialog();
        }
        ShowText?.Invoke(_conversation[_converIndex]);
    }

    private void StopDialog()
    {
        DialogActive?.Invoke(false);
        Time.timeScale = 1;
    }
}