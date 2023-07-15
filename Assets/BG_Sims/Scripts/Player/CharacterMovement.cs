using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private Rigidbody2D rb2D;
    private Vector2 motionVector;

    private bool onGameplay;

    private CoroutineHandle vectorCoroutine;
    private CoroutineHandle moveCoroutine;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Initialice();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Conclude();
    }

    public void Initialice()
    {
        onGameplay = true;

        vectorCoroutine = Timing.RunCoroutine(GetMotionVector());
        moveCoroutine = Timing.RunCoroutine(MoveCharacter());
    }

    private IEnumerator<float> GetMotionVector()
    {
        while (onGameplay)
        {
            motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            yield return 0f;
        }
    }

    private IEnumerator<float> MoveCharacter()
    {
        while (onGameplay)
        {
            rb2D.velocity = motionVector * speed;
            yield return 0f;
        }
    }

    public void Conclude()
    {
        Timing.KillCoroutines(vectorCoroutine);
        Timing.KillCoroutines(moveCoroutine);
    }
}