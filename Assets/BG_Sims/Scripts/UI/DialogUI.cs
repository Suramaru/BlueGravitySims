using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogUI : UIBase
{
    [SerializeField] private TextMeshProUGUI dialogText;

    public void SetDialog(string text)
    {
        WriteText(text);
    }

    private IEnumerator<float> WriteText(string text)
    {
        dialogText.text = "";
        foreach (char caracter in text)
        {
            dialogText.text = dialogText.text + caracter;
            yield return 0f;
        }
    }
}
