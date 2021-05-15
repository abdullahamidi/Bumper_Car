using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    public static AnimationController instance;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        animator = GetComponent<Animator>();
    }

    public void FrontCrashAnimation()
    {
        animator.Play("FrontCollision");
    }
    public void RightCrashAnimation()
    {
        animator.Play("RightCollision");
    }
    public void LeftCrashAnimation()
    {
        animator.Play("LeftCollision");
    }
    public void BackCrashAnimation()
    {
        animator.Play("BackCollision");
    }
}
