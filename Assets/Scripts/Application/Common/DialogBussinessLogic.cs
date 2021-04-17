using Domain.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Application.Common
{
    public class DialogBussinessLogic
    {
        private readonly IDialogService _dialogService;

        private List<string> _conversation;
        private int _dialogIndex;

        public DialogBussinessLogic(IDialogService dialogService)
        {
            _dialogService = dialogService; 
        }

        public void StartDialog(string name, string text)
        {
            _dialogService.StartDialog(name, text);
        }

        public void StopDialog()
        {
            _dialogService.StopDialog();
        }

    }
}