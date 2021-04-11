using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Infrastructure.Dialog
{
    public class DialogManager : MonoBehaviour
    {

        public GameObject DialogPanel;
        public Text NpcNameText;
        public Text DialogText;

        private List<string> Conversation;
        private int ConverIndex;
        // Start is called before the first frame update
        void Start()
        {
            DialogPanel.SetActive(false);
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
        public void ShowText()
        {
            DialogText.text = Conversation[ConverIndex];
        }
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
    }
}