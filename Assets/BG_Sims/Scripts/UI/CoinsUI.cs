using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsUI : UIBase
{
    [SerializeField] private TextMeshProUGUI coinsText;

    protected override void Awake()
    {
        base.Awake();
    }

    public void SetCoinsUI(float currentScore)
    {
        coinsText.text = "x" + currentScore.ToString();
    }
}
