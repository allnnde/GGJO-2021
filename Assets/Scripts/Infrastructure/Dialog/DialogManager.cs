using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure.Dialog
{
    public class DialogManager : MonoBehaviour
    {
        public GameObject DialogPanel;
        public Text DialogText;
        public Text NpcNameText;
        private int ConverIndex;
        private List<string> Conversation;

        public void Next()
        {
            if (ConverIndex < Conversation.Count - 1)
            {
                ConverIndex++;
                ShowText();
            }
            else
            {
                StopDialog();
            }
        }

        public void ShowText()
        {
            DialogText.text = Conversation[ConverIndex];
        }

        public void Start_Dialog(string npcName, List<string> convo)
        {
            Time.timeScale = 0;
            NpcNameText.text = npcName;
            Conversation = new List<string>(convo);
            DialogPanel.SetActive(true);
            ConverIndex = 0;
            ShowText();
        }

        public void StopDialog()
        {
            DialogPanel.SetActive(false);
            Time.timeScale = 1;
        }

        // Start is called before the first frame update
        private void Start()
        {
            DialogPanel.SetActive(false);
        }
    }
}