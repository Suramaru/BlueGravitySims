using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public Action<bool, string, int, InventoryItem> OptionSelected;

    [SerializeField] private Button parButton;
    [SerializeField] private Button imparButton;
    [SerializeField] private BoxCollider2D interactor;
    [SerializeField] private InventoryItem inventoryItem;

    private bool guessed;
    private string textToShow;
    private int number;

    private void Awake()
    {
        interactor.enabled = false;

        parButton.onClick.AddListener(GuessEven);
        imparButton.onClick.AddListener(GuessOdd);
    }

    /// <summary>
    /// Enable interaction with the minigame
    /// </summary>
    public void EnableMinigame()
    {
        interactor.enabled = true;
    }

    public void StartMinigame()
    {
        number = UnityEngine.Random.Range(1, 101);
    }

    /// <summary>
    /// PlayerGuess even
    /// </summary>
    private void GuessEven()
    {
        guessed = number % 2 == 0;

        if (guessed)
            textToShow = "You guessed it! The number was even. You won! Keep playing";
        else
            textToShow = "You didn't guess. The number was odd. You lost! Keep playing";


        ShowResult();
    }

    /// <summary>
    /// Player guess odd
    /// </summary>
    private void GuessOdd()
    {
        guessed = number % 2 != 0;

        if (guessed)
            textToShow = "You guessed it! The number was odd. You won! Keep playing";
        else
            textToShow = "You didn't guess. The number was even. You lost! Keep playing";

        ShowResult();
    }

    /// <summary>
    /// Show result
    /// </summary>
    private void ShowResult()
    {
        OptionSelected?.Invoke(guessed, textToShow, number, inventoryItem);
        StartMinigame();
    }
}