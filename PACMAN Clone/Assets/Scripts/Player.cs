using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

/* SCRIPT: Player

 Created By:  Rodrigo Duran Daniel
 Created In:  19/03/2024
 Last Update: 22/03/2024

 Function: Handle with player's mechanichs

 */

public class Player : MonoBehaviour
{
    #region Components

    //Private
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 _direction;

    //Portals
    private int portalsTimer;
    [SerializeField] private GameObject portalLeft;
    [SerializeField] private GameObject portalRight;
    [SerializeField] private GameObject portalUp;
    [SerializeField] private GameObject portalDown;

    //Ghosts
    [SerializeField] private GameObject redGhost;
    [SerializeField] private GameObject blueGhost;
    [SerializeField] private GameObject yellowGhost;
    [SerializeField] private GameObject pinkGhost;
    private Ghost redGhostScript;
    private Ghost blueGhostScript;
    private Ghost yellowGhostScript;
    private Ghost pinkGhostScript;

    //--------------------------------------------------

    //Public
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    #endregion

    #region Methods

    //Start
    private void Start()
    {
        //Player
        rb = GetComponent<Rigidbody2D>();

        //Portals
        portalsTimer = 30;

        //Ghosts
        redGhostScript = redGhost.GetComponent<Ghost>();
        blueGhostScript = blueGhost.GetComponent<Ghost>();
        yellowGhostScript = yellowGhost.GetComponent<Ghost>();
        pinkGhostScript = pinkGhost.GetComponent<Ghost>();
    }

    //Update
    void Update()
    {
        OnInput();
        CheckPortalsTimer();
    }

    //FixedUpdate
    private void FixedUpdate()
    {
        OnMove();
        
    }

    //OnCollisionEnter2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // handle with collision between player and ghosts    
    }

    //OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerCollision(collision);
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

    #endregion

    #region HandleCollisions

    //OnTriggerCollision
    void OnTriggerCollision(Collider2D collision)
    {
        //Collecting Normal Items
        if (collision.gameObject.tag == "NormalItem")
        {
            collision.gameObject.SetActive(false);
            //Debug.Log("+5 PONTOS");
        }

        //Collecting Great Items
        if (collision.gameObject.tag == "GreatItem")
        {
            Debug.Log("COLLISION - GREAT ITEM");
            collision.gameObject.SetActive(false);
            StartCoroutine(redGhostScript.MakeVulnerable());
            StartCoroutine(blueGhostScript.MakeVulnerable());
            StartCoroutine(yellowGhostScript.MakeVulnerable());
            StartCoroutine(pinkGhostScript.MakeVulnerable());
        }

        //Entering in portals
        if (collision.gameObject == portalLeft && portalsTimer == 0)
        {
            Debug.Log("Collision with Portal Left");
            gameObject.transform.localPosition = portalRight.transform.localPosition;
            portalsTimer = 30;
        }

        if (collision.gameObject == portalRight && portalsTimer == 0)
        {
            Debug.Log("Collision with Portal Right");
            gameObject.transform.localPosition = portalLeft.transform.localPosition;
            portalsTimer = 30;
        }

        if (collision.gameObject == portalUp && portalsTimer == 0)
        {
            Debug.Log("Collision with Portal Up");
            gameObject.transform.localPosition = portalDown.transform.localPosition;
            portalsTimer = 30;
        }

        if (collision.gameObject == portalDown && portalsTimer == 0)
        {
            Debug.Log("Collision with Portal Down");
            gameObject.transform.localPosition = portalUp.transform.localPosition;
            portalsTimer = 30;
        }
    }

    #endregion

    #region HandlePortals

    //CheckPortalsTimer
    void CheckPortalsTimer()
    {
        if (portalsTimer > 0) portalsTimer--;
    }

    #endregion
}
