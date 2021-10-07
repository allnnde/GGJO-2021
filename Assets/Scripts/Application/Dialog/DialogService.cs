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
        public Action<bool> OnDialogActive { get; set; }
        public Action<string> OnShowText { get; set; }
        private List<string> _conversation;
        private int _converIndex;

        public void HiddenDialog()
        {
            OnDialogActive?.Invoke(false);
        }

        public void ShowDialog()
        {
            OnDialogActive?.Invoke(true);
        }

        public void StartDialog(List<string> conversation)
        {
            Time.timeScale = 0;
            _conversation = conversation;
            _converIndex = 0;
            OnShowText?.Invoke(_conversation[_converIndex]);
        }

        public void NextText()
        {
            if (_converIndex < _conversation.Count - 1)
            {
                _converIndex++;
                OnShowText?.Invoke(_conversation[_converIndex]);
            }
            else
            {
                StopDialog();
            }
            OnShowText?.Invoke(_conversation[_converIndex]);
        }

        private void StopDialog()
        {
            OnDialogActive?.Invoke(false);
            Time.timeScale = 1;
        }
    }
}