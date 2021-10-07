using Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.Dialog
{
    public class DialogManager : MonoBehaviour
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
            Configure();
            _dialogService.HiddenDialog();
        }

        private void Configure()
        {
            _dialogService = ServiceLocator.Instance.GetServiceSingleton<IDialogService>();

            _dialogService.OnDialogActive += DialogPanel.SetActive;
            _dialogService.OnShowText += ShowText;
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
    }
}