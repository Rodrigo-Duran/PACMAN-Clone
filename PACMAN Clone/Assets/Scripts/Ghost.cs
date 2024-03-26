using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

/* SCRIPT: Ghost

 Created By:  Rodrigo Duran Daniel
 Created In:  19/03/2024
 Last Update: 23/03/2024

 Function: Handle with ghosts' mechanichs

 */

public class Ghost : MonoBehaviour
{
    #region Components

    //Private
    private float speed;
    private Rigidbody2D rb;
    private Vector2 _direction;
    private bool _vulnerability;
    private bool _almostOk;
    private bool _isAlive;
    [SerializeField] GameObject spawnPoint;

    //Public
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    public bool vulnerability
    {
        get { return _vulnerability; }
        set { _vulnerability = value; }
    }
    public bool almostOk
    {
        get { return _almostOk; }
        set { _almostOk = value; }
    }

    public bool isAlive
    {
        get { return _isAlive; }
        set { _isAlive = value; }
    }

    #endregion

    #region Methods

    //Start
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
        _vulnerability = false;
        _almostOk = false;
        _isAlive = true;
    }

    //Update
    void Update()
    {
        OnInput();
    }

    //FixedUpdate
    private void FixedUpdate()
    {
        OnMove();
    }

    //OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnEnterCollision(collision);
    }

    #endregion

    #region HandleMovement

    //OnInput
    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    //OnMove
    void OnMove()
    {
        rb.MovePosition(rb.position + _direction * speed * Time.fixedDeltaTime);
    }

    //MoveToSpawnPoint
    public IEnumerator MoveToSpawnPoint()
    {
        
        yield return new WaitForSeconds(5);
        this.gameObject.transform.localPosition = spawnPoint.transform.localPosition;
        _isAlive = true;
        this.gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
        Debug.Log("Ghost is Alive? " + _isAlive);
        Debug.Log("GHOST ALIVE AGAIN");
    }

    #endregion

    #region HandleCollisions

    //MakeVulnerable
    public IEnumerator MakeVulnerable()
    {
        _vulnerability = true;
        speed = 3;
        yield return new WaitForSeconds(7);
        _almostOk = true;
        yield return new WaitForSeconds(3);
        _almostOk = false;
        _vulnerability = false;
        speed = 5;
    }

    //OnTriggerCollision
    void OnEnterCollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_vulnerability)
            {
                Debug.Log("GHOST IS DEAD");
                Death();
            }
            else
            {
                //Fim de jogo
            }
        }
    }

    //Death
    void Death()
    {
        _isAlive = false;
        StopCoroutine(MakeVulnerable());
        _vulnerability = false;
        _almostOk = false;
        speed = 5;
        this.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
        Debug.Log("Ghost is Alive? " + _isAlive);
        StartCoroutine(MoveToSpawnPoint());
    }

    #endregion
}
