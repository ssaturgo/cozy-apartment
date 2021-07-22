using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheikhScript : MonoBehaviour
{
    public enum animStates
    {
        Dancing,
        Sleeping,
        Coding
    }

    public animStates sheikhState = animStates.Dancing;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (sheikhState)
        {
            case animStates.Dancing:
                animator.SetBool("isDancing", true);
                break;

            case animStates.Sleeping:
                break;

            case animStates.Coding:
                break;
        }
    }

    private void StateSwitch()
    {

    }
}
