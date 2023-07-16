using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public Action<string, UserType> SetDialog;

    private Dialogs dialogs;

    private int maxProgress;
    private int currentProgress = 0;

    private void Awake()
    {
        maxProgress = 3;
    }

    public void Initialice(Dialogs _dialogs)
    {
        dialogs = _dialogs;
    }

    private void DialogToSay()
    {
        SetDialog?.Invoke(dialogs.GetDialogById(currentProgress), UserType.NPC);
    }

    public void ActualiceProgress()
    {
        if (currentProgress <= maxProgress)
        {
            DialogToSay();
            currentProgress++;
        }
    }

    public void ActualiceMaxProgress(int nextMaxProgress)
    {
        currentProgress = maxProgress + 1;
        maxProgress = nextMaxProgress;
    }
}
