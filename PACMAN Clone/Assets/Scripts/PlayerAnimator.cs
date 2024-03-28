using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/* SCRIPT: PlayerAnimator

 Created By:  Rodrigo Duran Daniel
 Created In:  19/03/2024
 Last Update: 28/03/2024

 Function: Dealing with player's animations

 */

public class PlayerAnimator : MonoBehaviour
{

    #region Components

    //Private
    private Player player;
    private Rigidbody2D rb;
    private Animator animator;

    #endregion

    #region MainMethods

    //Start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        animator = GetComponent<Animator>();

    }

    //Update
    void Update()
    {
        OnMove();
    }

    #endregion

    #region MovementHandler

    //OnMove
    void OnMove()
    {
        //ANIMATIONS
        if (player.direction.sqrMagnitude > 0)
        {
            animator.SetInteger("transition", 1);
        }

        //ROTATING
        if (player.direction.x > 0 && Time.timeScale == 1) //Right
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0 && Time.timeScale == 1) //Left
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (player.direction.y > 0 && Time.timeScale == 1) //Up
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }

        if (player.direction.y < 0 && Time.timeScale == 1) //Down
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }
    #endregion
}
