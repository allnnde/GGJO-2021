using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Application.Dialog
{
    public class DialogService : IDialogService
    {
        private List<string> _conversation;
        private int _converIndex;
        private readonly IDialogManager _dialogManager;

        public DialogService(IDialogManager dialogManager)
        {
            _dialogManager = dialogManager;
        }

        public void HiddenDialog()
        {
            _dialogManager.DialogActive(false);
        }

        public void ShowDialog()
        {
            _dialogManager.DialogActive(true);
        }

        public void StartDialog(List<string> conversation)
        {
            Time.timeScale = 0;
            _conversation = conversation;
            _converIndex = 0;
            _dialogManager.ShowText(_conversation[_converIndex]);
        }

        public void NextText()
        {
            if (_converIndex < _conversation.Count - 1)
            {
                _converIndex++;
                _dialogManager.ShowText(_conversation[_converIndex]);
            }
            else
            {
                StopDialog();
            }
            _dialogManager.ShowText(_conversation[_converIndex]);
        }

        private void StopDialog()
        {
            _dialogManager.DialogActive(false);
            Time.timeScale = 1;
        }
    }
}