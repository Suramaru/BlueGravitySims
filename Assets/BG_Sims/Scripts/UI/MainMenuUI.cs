using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : UIBase
{
    public Action ShowShop;
    public Action StartGame;
    public Action ShowLeaderBoard;

    [SerializeField] private Button startGameBtn;
    [SerializeField] private Button showShopBtn;
    [SerializeField] private Button showLeaderBoardBtn;

    protected override void Awake()
    {
        base.Awake();
        showShopBtn.onClick.AddListener(ShowShopPressed);
        startGameBtn.onClick.AddListener(StartGamePressed);
        showLeaderBoardBtn.onClick.AddListener(ShowLeaderBoardPressed);
    }

    private void StartGamePressed()
    {
        StartGame?.Invoke();
        Show(false);
    }

    private void ShowLeaderBoardPressed()
    {
        ShowLeaderBoard?.Invoke();
        Show(false);
    }

    private void ShowShopPressed()
    {
        ShowShop?.Invoke();
        Show(false);
    }
}
