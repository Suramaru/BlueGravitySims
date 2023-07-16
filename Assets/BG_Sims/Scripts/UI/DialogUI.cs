using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogUI : UIBase
{
    public Action DialogFinish;

    [SerializeField] private TextMeshProUGUI dialogText;
    private CoroutineHandle dialogCoroutine;

    public void SetDialog(string dialog)
    {
        dialogCoroutine = Timing.RunCoroutine(WriteText(dialog));
    }

    private IEnumerator<float> WriteText(string dialog)
    {
        dialogText.text = "";
        foreach (char caracter in dialog)
        {
            dialogText.text += caracter;
            yield return Timing.WaitForSeconds(.1f);
        }

        DialogFinish?.Invoke();
    }
}
