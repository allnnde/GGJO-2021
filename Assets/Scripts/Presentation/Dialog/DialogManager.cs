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
        Configure();
        dialogBL.HiddenDialog();
    }

    private void Configure()
    {
        dialogBL = ServiceLocator.Instance.GetServiceSingleton<IDialogBL>();

        dialogBL.OnDialogActive += DialogPanel.SetActive;
        dialogBL.OnShowText += ShowText;
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