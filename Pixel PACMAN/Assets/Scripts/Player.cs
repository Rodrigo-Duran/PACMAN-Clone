using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

/* SCRIPT: Player

 Created By:  Rodrigo Duran Daniel
 Created In:  19/03/2024
 Last Update: 01/04/2024

 Function: Dealing with player's mechanichs

 */

public class Player : MonoBehaviour
{
    #region Components

    //Private
    private float speed;
    private Rigidbody2D rb;
    private Vector2 _direction;
    public GameController gameController;
    private List<string> directionCode;
    private float rayDistance;
    [SerializeField] private LayerMask rayLayer;

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

    #region MainMethods

    //Start
    private void Start()
    {
        //Player
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
        directionCode = new List<string>() { "L" };
        rayDistance = (float)0.5;

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
        DecreasePortalsTimer();
    }

    //FixedUpdate
    private void FixedUpdate()
    {
        OnMove();
        
    }

    //OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnTriggerCollision(collision);
    }

    #endregion

    #region MovementHandler

    //OnInput
    void OnInput()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) //Up
        {
            _direction = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) //Left
        {
            _direction = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) //Down
        {
            _direction = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) //Right
        {
            _direction = Vector2.right;
        }
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    //OnMove
    void OnMove()
    {
        rb.MovePosition(rb.position + _direction * speed * Time.fixedDeltaTime);   
    }

    //CheckIfCanMoveDirection
    bool CheckIfCanMoveDirection(Vector2 direction)
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, direction, rayDistance, rayLayer);
        Vector3 endPoint = transform.position * rayDistance;

        Debug.DrawLine(transform.position, transform.position + endPoint, Color.green);
        if (hit2D.collider == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

    #region CollisionsHandler

    //OnTriggerCollision
    void OnTriggerCollision(Collider2D collision)
    {
        //Collecting Normal Items
        if (collision.gameObject.tag == "NormalItem")
        {
            collision.gameObject.SetActive(false);
            gameController.collectibles--;
            GameController.score += 10;
        }

        //Collecting Great Items
        if (collision.gameObject.tag == "GreatItem")
        {
            Debug.Log("COLLISION - GREAT ITEM");
            collision.gameObject.SetActive(false);
            gameController.collectibles--;
            GameController.score += 50;

            StopAllCoroutines();

            //RedGhost
            StartCoroutine(redGhostScript.MakeVulnerable());

            //BlueGhost
            StartCoroutine(blueGhostScript.MakeVulnerable());

            //YellowGhost
            StartCoroutine(yellowGhostScript.MakeVulnerable());

            //PinkGhost
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

    #region PortalsHandler

    //DecreasePortalsTimer
    void DecreasePortalsTimer()
    {
        if (portalsTimer > 0) portalsTimer--;
    }

    #endregion

}
