using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    protected virtual void Awake()
    {
        Show(false);
    }

    public virtual void Show(bool isTrue)
    {
        gameObject.SetActive(isTrue);
    }
}