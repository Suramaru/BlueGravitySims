using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterController characterMovement;

    private bool onGameplay;

    private void Start()
    {
        characterMovement.Initialice();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            characterMovement.Conclude();
        if (Input.GetKeyDown(KeyCode.O))
            characterMovement.Initialice();
    }
}
