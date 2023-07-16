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

    public void SetCoinsToUI(float score)
    {
        scoreUI.SetCoinsUI(score);
    }

    private void OnSetMainMenu()
    {
        SetUi(UIType.MainMenu);
    }

    private void OnStartGame()
    {
        StartGame?.Invoke();
    }
}