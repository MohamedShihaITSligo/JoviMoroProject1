using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle,
    Walking,
    Atacking,
}

public class AnimationController : MonoBehaviour {

    State state;
    State previousState;
    Animator animator;
    public bool Player, Ai;
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
        if (Player)
        {
            if (MovementKeyDown())
            {
                SetState(State.Walking);
            }
            else if (GetComponent<PlayerAttack>().IsShooting())
            {
                SetState(State.Atacking);
            }
            else
            {
                SetState(State.Idle);
            }
        }else if (Ai)
        {
            if (GetComponent<EnemyAttack>().attacking)
            {
                SetState(State.Atacking);
            }
            else if (GetComponent<Rigidbody2D>().velocity != Vector2.zero)
            {
                SetState(State.Idle);
            }
            else
            {
                SetState(State.Walking);
            }
        }
    }


    void SetState(State newState)
    {
        previousState = state;
        state = newState;
    }
}
