using Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.Dialog
{
    public class DialogManager : MonoBehaviour, IDialogManager
    {
        public GameObject DialogPanel;
        public Text NpcNameText;
        public Text DialogText;
        private IDialogService _dialogService;

        // Start is called before the first frame update
        private void Start()
        {
            var buttonNextText = GetComponentInChildren<Button>();
            buttonNextText.onClick.AddListener(Next);
            _dialogService.HiddenDialog();
        }

        public void Configuration(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public void Start_Dialog(string npcName, List<string> convo)
        {
            NpcNameText.text = npcName;
            _dialogService.ShowDialog();
            _dialogService.StartDialog(convo);
        }

        public void ShowText(string text)
        {
            DialogText.text = text;
        }

        public void Next()
        {
            _dialogService.NextText();
        }

        public void DialogActive(bool active)
        {
            DialogPanel.SetActive(active);
        }
    }
}