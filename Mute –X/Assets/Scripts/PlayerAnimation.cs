using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Walking,
    Shooting,
}

public class PlayerAnimation : MonoBehaviour {

    PlayerState state;
    PlayerState previousState;
    Animator animator;
	void Start () {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckState();
        if (state != previousState)
        {
            animator.SetInteger("State", (int)state);
        }
    }

    bool MovementKeyDown()
    {
        return Input.GetButton("Horizontal") || Input.GetButton("Vertical");
    }

    void CheckState()
    {
        if (MovementKeyDown())
        {
            previousState = state;
            state = PlayerState.Walking;
        }
        else if (GetComponent<PlayerAttack>().IsShooting())
        {
            previousState = state;
            state = PlayerState.Shooting;
        }
        else
        {
            previousState = state;
            state = PlayerState.Idle;
        }
    }
}
