using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/* SCRIPT: GhostAnimator

 Created By:  Rodrigo Duran Daniel
 Created In:  19/03/2024
 Last Update: 02/04/2024

 Function: Dealing with ghosts' animations  

 */

public class GhostAnimator : MonoBehaviour
{
    #region Components

    //Private
    private Ghost ghost;
    private Rigidbody2D rb;
    private Animator animator;

    #endregion

    #region MainMethods

    //Start
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ghost = GetComponent<Ghost>();
        animator = GetComponent<Animator>();
    }

    //Update
    private void Update()
    {
        OnMove();
    }

    #endregion

    #region MovementAnimationHandler

    //OnMove
    void OnMove()
    {
        //ANIMATIONS
        if (ghost.isAlive) //Alive
        {
            if (ghost.direction == 1 && !ghost.vulnerability) //Right
            {
                animator.SetInteger("transition", 1);
            }

            if (ghost.direction == -1 && !ghost.vulnerability) //Left
            {
                animator.SetInteger("transition", 2);
            }

            if (ghost.direction == 2 && !ghost.vulnerability) //Up
            {
                animator.SetInteger("transition", 3);
            }

            if (ghost.direction == -2 && !ghost.vulnerability) //Down
            {
                animator.SetInteger("transition", 4);
            }

            if (ghost.vulnerability) //Vulnerable
            {
                if(!ghost.almostOk) animator.SetInteger("transition", 9);
                if(ghost.almostOk) animator.SetInteger("transition", 10);
            }
        }
        else //Dead
        {
            if (rb.position.x > 0) //Right
            {
                animator.SetInteger("transition", 5);
            }

            if (rb.position.x < 0) //Left
            {
                animator.SetInteger("transition", 6);
            }

            if (rb.position.y > 0) //Up
            {
                animator.SetInteger("transition", 7);
            }

            if (rb.position.y < 0) //Down
            {
                animator.SetInteger("transition", 8);
            }
        }
    }
    #endregion

}
