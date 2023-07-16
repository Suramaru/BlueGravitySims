using MEC;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogUI : UIBase
{
    public Action DialogFinish;

    [SerializeField] private TextMeshProUGUI nPCDialogText;
    [SerializeField] private TextMeshProUGUI playerDialogText;

    private CoroutineHandle dialogCoroutine;
    private Dictionary<UserType, TextMeshProUGUI> dialogTextDictionary;

    protected override void Awake()
    {
        base.Awake();

        dialogTextDictionary = new Dictionary<UserType, TextMeshProUGUI>()
        {
            { UserType.NPC, nPCDialogText },
            { UserType.Player, playerDialogText }
        };

        nPCDialogText.transform.parent.gameObject.SetActive(false);
        playerDialogText.transform.parent.gameObject.SetActive(false);
    }

    public void SetDialog(string dialog, UserType userType)
    {
        LeanTween.cancel(gameObject);
        dialogCoroutine = Timing.RunCoroutine(WriteText(dialog, userType));
    }

    private IEnumerator<float> WriteText(string dialog, UserType userType)
    {
        if (dialogTextDictionary.TryGetValue(userType, out TextMeshProUGUI targetText))
        {
            targetText.transform.parent.gameObject.SetActive(true);
            targetText.text = "";
            foreach (char character in dialog)
            {
                targetText.text += character;
                yield return Timing.WaitForSeconds(.1f);
            }

            LeanTween.delayedCall(2, () => targetText.transform.parent.gameObject.SetActive(false));
        }
    }
}