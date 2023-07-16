using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogUI : UIBase
{
    public Action DialogFinish;

    [SerializeField] private TextMeshProUGUI dialogText;

    public void SetDialog(string dialog)
    {
        WriteText(dialog);
    }

    private IEnumerator<float> WriteText(string dialog)
    {
        dialogText.text = "";
        foreach (char caracter in dialog)
        {
            dialogText.text = dialogText.text + caracter;
            yield return 0f;
        }

        DialogFinish?.Invoke();
    }
}
