using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/* SCRIPT: Ghost

 Created By:  Rodrigo Duran Daniel
 Created In:  19/03/2024
 Last Update: 02/04/2024

 Function: Dealing with some ghosts' mechanichs

 */

public class Ghost : MonoBehaviour
{
    #region Components

    //Private
    private Rigidbody2D rb;
    private CircleCollider2D cc;
    private GhostAIMovement ghostAI;
    private Rigidbody2D playerRB;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private Player player;

    private int _direction;
    private float _speed;
    private bool _vulnerability;
    private bool _almostOk;
    private bool _isAlive;

    //--------------------------------------------------

    //Public
    public IEnumerator e;
    public GameController gameController;

    public int direction
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

    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    #endregion

    #region MainMethods

    //Start
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        ghostAI = GetComponent<GhostAIMovement>();
        _direction = 0;
        _speed = 5f;
        _vulnerability = false;
        _almostOk = false;
        _isAlive = true;
        playerRB = player.GetComponent<Rigidbody2D>();
        e = MakeVulnerable();
    }

    //Update
    void Update()
    {
        ghostAI.OnCheck();
    }

    //FixedUpdate
    private void FixedUpdate()
    {
        ghostAI.OnMove();
    }

    //OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnEnterCollision(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnExitCollison(collision);
    }

    #endregion

    #region CollisionsHandler

    //MakeVulnerable
    public IEnumerator MakeVulnerable()
    {
        _almostOk = false;
        _vulnerability = true;
        _speed = 3f;
        yield return new WaitForSeconds(7);
        _almostOk = true;
        yield return new WaitForSeconds(3);
        _almostOk = false;
        _vulnerability = false;
        _speed = 5f;
    }

    //OnEnterCollision
    void OnEnterCollision(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_vulnerability)
            {
                Death();
            }
            else
            {
                gameController.EndGame();
            }
        }

        if (collision.gameObject.tag == "Ghost")
        {
            cc.isTrigger = true;
        }
    }
    
    void OnExitCollison(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ghost") 
        {
            cc.isTrigger = false; 
        }
    }

    //Death
    void Death()
    {
        Debug.Log("GHOST DIED");
        _isAlive = false;
        GameController.score += 1000;
        StopCoroutine(MakeVulnerable());
        _vulnerability = false;
        _almostOk = false;
        _speed = 5f;
        this.gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
    }

    #endregion

}
