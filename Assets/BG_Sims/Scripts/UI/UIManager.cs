using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Action StartGame;
    public Action CountDownFinish;

    [SerializeField] private CoinsUI scoreUI;
    [SerializeField] private MainMenuUI mainMenuUI;
    [SerializeField] private DialogUI dialogUI;

    private void Awake()
    {
        dialogUI.DialogFinish += OnDialogFinish;
    }

    public void SetUi(UIType currentType)
    {
        switch (currentType)
        {
            case UIType.MainMenu:
                mainMenuUI.Show(true);
                break;
            case UIType.Coins:
                scoreUI.Show(true);
                break;
            case UIType.Dialog:
                dialogUI.Show(true);
                break;
            default:
                break;
        }
    }

    public void SetDialogUI(string dialog)
    {
        dialogUI.SetDialog(dialog);
        SetUi(UIType.Dialog);
    }

    public void SetCoinsToUI(float score)
    {
        scoreUI.SetCoinsUI(score);
    }

    private void OnDialogFinish()
    {
        dialogUI.Show(false);
    }
}