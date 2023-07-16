using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public Action<string> SetDialog;

    [SerializeField] private Dialogs dialogs;

    private int currentProgress = 0;

    public void DialogToSay()
    {
        SetDialog?.Invoke(dialogs.GetDialogById(currentProgress));
    }

    public void ActualiceProgress()
    {
        currentProgress++;
        DialogToSay();
    }
}
