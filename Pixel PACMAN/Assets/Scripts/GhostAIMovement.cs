using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/* SCRIPT: GhostAIMovement

 Created By:  Rodrigo Duran Daniel
 Created In:  01/04/2024
 Last Update: 03/04/2024

 Function: Dealing with ghosts' AI Movement

 */

public class GhostAIMovement : MonoBehaviour
{

    #region Components

    //Private
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private LayerMask rayLayer;
    [SerializeField] private GameObject startingMovingPoint;
    private Rigidbody2D rb;
    private Ghost ghost;
    private Vector2 currentDirection;
    private Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left};

    private int directionIndex;
    private float rayDistance;
    
    #endregion

    #region MainMethods

    // Start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ghost = GetComponent<Ghost>();
        directionIndex = 1;
        currentDirection = directions[directionIndex];
        rayDistance = 0.5f;
    }

    #endregion

    #region AIMovementHandler

    //OnMove
    public void OnMove()
    {
        if (ghost.isAlive)
        {
            if (ghost.isPossibleToWalk)
            {
                rb.MovePosition(rb.position + currentDirection * ghost.speed * Time.fixedDeltaTime);

                if (currentDirection == Vector2.right)
                    ghost.direction = 1;
                if (currentDirection == Vector2.left)
                    ghost.direction = -1;
                if (currentDirection == Vector2.up)
                    ghost.direction = 2;
                if (currentDirection == Vector2.down)
                    ghost.direction = -2;
            }
        }
        else
        {
            MoveToSpawnPoint();
        }
    }

    //OnCheck
    public void OnCheck()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, currentDirection, rayDistance, rayLayer);
        Vector3 endPoint = transform.position * rayDistance;

        Debug.DrawLine(transform.position, transform.position + endPoint, Color.green);

        if (hit2D.collider != null)
        {
            ChangeDirection();
        }
    }

    //ChangeDirection
    public void ChangeDirection()
    {
        directionIndex += Random.Range(0, 2) * 2 - 1;

        int campledIndex = directionIndex % directions.Length;

        if (campledIndex < 0)
        {
            campledIndex = directions.Length + campledIndex;
        }

        rb.velocity = Vector2.zero;
        currentDirection = directions[campledIndex];
    }

    //MoveToSpawnPoint
    public void MoveToSpawnPoint()
    {
        Vector2 spawnPointDirection = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y) - rb.position;
        rb.MovePosition(rb.position + spawnPointDirection * ghost.speed * Time.fixedDeltaTime);
        if (rb.position == new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y))
        {
            ghost.isAlive = true;
        }
    }

    //MovingToStartingMovingPoint
    public void MoveToStartingMovingPoint()
    {
        rb.MovePosition(rb.position + Vector2.up * ghost.speed * Time.deltaTime);
    }

    //ExitSpawnPointBox
    public void ExitSpawnPointBox()
    {
        ghost.isPossibleToWalk = true;
        this.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
    }

    #endregion

}
