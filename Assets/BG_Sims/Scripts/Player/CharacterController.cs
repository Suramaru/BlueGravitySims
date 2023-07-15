using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;

[RequireComponent(typeof(Rigidbody2D))]
sealed class CharacterController : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private Rigidbody2D rb2D;
    private Vector2 motionVector;
    private Vector2 lastMotionVector;

    private bool onGameplay;
    private bool isWalking;

    private CoroutineHandle vectorCoroutine;
    private CoroutineHandle moveCoroutine;

    private AnimationController animationController;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animationController = GetComponentInChildren<AnimationController>();
    }

    /// <summary>
    /// Start the movement
    /// </summary>
    public void Initialice()
    {
        onGameplay = true;

        vectorCoroutine = Timing.RunCoroutine(GetMotionVector());
        moveCoroutine = Timing.RunCoroutine(MoveCharacter());
    }

    //Get the motion vector
    private IEnumerator<float> GetMotionVector()
    {
        while (onGameplay)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            motionVector = new Vector2(horizontal, vertical);
            animationController.SetMovementAnimation(horizontal, vertical);

            isWalking = horizontal != 0 || vertical != 0;

            animationController.IsWalking(isWalking);

            if (horizontal != 0 || vertical != 0)
            {
                lastMotionVector = new Vector2(horizontal, vertical).normalized;

                animationController.SetLastMovementAnimation(horizontal, vertical);
            }

            yield return 0f;
        }
    }

    //Move the player
    private IEnumerator<float> MoveCharacter()
    {
        while (onGameplay)
        {
            rb2D.velocity = motionVector * speed;
            yield return 0f;
        }
    }

    /// <summary>
    /// Stop the movement and set de volicity in zero
    /// </summary>
    public void Conclude()
    {
        rb2D.velocity = Vector2.zero;

        Timing.KillCoroutines(vectorCoroutine);
        Timing.KillCoroutines(moveCoroutine);
    }
}