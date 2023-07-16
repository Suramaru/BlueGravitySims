using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigameUI : UIBase
{
    [SerializeField] private Button closeBtn;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private TextMeshProUGUI numberText;

    protected override void Awake()
    {
        base.Awake();
        closeBtn.onClick.AddListener(CloseUI);
    }

    public void ShowMessages(string message, int number)
    {
        resultText.text = message;
        numberText.text = number.ToString();
    }

    private void CloseUI()
    {
        resultText.text = ""; 
        numberText.text = "";
        Show(false);
    }
}
