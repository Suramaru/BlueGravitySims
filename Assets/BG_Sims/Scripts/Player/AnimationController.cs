using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator[] animator;    

    private void Awake()
    {
        animator = GetComponentsInChildren<Animator>();
    }

    public void SetMovementAnimation(float horizontal, float vertical)
    {
        foreach (Animator animator in animator)
        {
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
        }  
    }

    public void SetLastMovementAnimation(float horizontal, float vertical)
    {
        foreach (Animator animator in animator)
        {
            animator.SetFloat("LastHorizontal", horizontal);
            animator.SetFloat("LastVertical", vertical);
        }
    }

    public void IsWalking(bool isTrue)
    {
        foreach (Animator animator in animator)
        {
            animator.SetBool("IsWalking", isTrue);
        }
    }
}