using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/* SCRIPT: GhostAIMovement

 Created By:  Rodrigo Duran Daniel
 Created In:  01/04/2024
 Last Update: 01/04/2024

 */

public class GhostAIMovement : MonoBehaviour
{

    #region Components

    //Private
    private Rigidbody2D rb;
    [SerializeField] private GameObject spawnPoint;
    private Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left};
    private int directionIndex;
    private Vector2 currentDirection;
    private Ghost ghost;
    private float rayDistance;
    [SerializeField] private LayerMask rayLayer;
    

    #endregion

    #region MainMethods

    // Start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ghost = GetComponent<Ghost>();
        directionIndex = 1;
        currentDirection = directions[directionIndex];
        rayDistance = (float)0.5;
    }

    #endregion

    #region AIMovementHandler

    //OnMove
    public void OnMove()
    {
        if (ghost.isAlive)
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
            //Debug.Log("COLLIDE WITH WALL");
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
        Vector2 direction = new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y) - rb.position;
        rb.MovePosition(rb.position + direction * ghost.speed * Time.fixedDeltaTime);
        if (rb.position == new Vector2(spawnPoint.transform.position.x, spawnPoint.transform.position.y))
        {
            ghost.isAlive = true;
            this.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
            Debug.Log("GHOST ALIVE AGAIN");
            return;
        }
    }

    #endregion
}
