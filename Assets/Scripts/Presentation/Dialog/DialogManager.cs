using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject DialogPanel;
    public Text NpcNameText;
    public Text DialogText;
    private IDialogBL dialogBL;

    // Start is called before the first frame update
    private void Start()
    {
        var buttonNextText = GetComponentInChildren<Button>();
        buttonNextText.onClick.AddListener(Next);

        dialogBL = ServiceLocator.Instance.GetServiceSingleton<IDialogBL>();

        dialogBL.DialogActive += DialogPanel.SetActive;
        dialogBL.ShowText += ShowText;
        dialogBL.HiddenDialog();
    }

    public void Start_Dialog(string npcName, List<string> convo)
    {
        NpcNameText.text = npcName;

        dialogBL.ShowDialog();
        dialogBL.StartDialog(convo);
    }

    public void ShowText(string text)
    {
        DialogText.text = text;
    }

    public void Next()
    {
        dialogBL.NextText();
    }
}