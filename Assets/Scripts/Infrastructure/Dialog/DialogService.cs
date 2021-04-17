using Domain.Interfaces;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Dialog
{
    public class DialogService : MonoBehaviour, IDialogService
    {
        public GameObject DialogPanel;
        public Text DialogText;
        public Text NpcNameText;

        // Start is called before the first frame update
        private void Start()
        {
            DialogPanel.SetActive(false);
        }

        public void StartDialog(string npcName, string text)
        {
            Time.timeScale = 0;
            DialogPanel.SetActive(true);

            NpcNameText.text = npcName;
            DialogText.text = text;
        }

        public void StopDialog()
        {
            DialogPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}