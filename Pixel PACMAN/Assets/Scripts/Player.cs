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
 Last Update: 02/04/2024

 Function: Dealing with player's mechanichs

 */

public class Player : MonoBehaviour
{
    #region Components

    //Private
    [SerializeField] private LayerMask rayLayer;
    private Rigidbody2D rb;
    public GameController gameController;
    private float speed;

    //Items
    [SerializeField] private GameObject currentItem;
    [SerializeField] private GameObject itemInPortalRight;
    [SerializeField] private GameObject itemInPortalLeft;
    [SerializeField] private GameObject itemInPortalUp;
    [SerializeField] private GameObject itemInPortalDown;
    private string _movingDirection;
    private string lastMovingDirection;

    //Portals
    [SerializeField] private GameObject portalLeft;
    [SerializeField] private GameObject portalRight;
    [SerializeField] private GameObject portalUp;
    [SerializeField] private GameObject portalDown;
    private int portalsTimer;

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
    public string movingDirection
    {
        get { return _movingDirection; }
        set { _movingDirection = value; }
    }
    #endregion

    #region MainMethods

    //Start
    private void Start()
    {
        //Player
        rb = GetComponent<Rigidbody2D>();
        speed = 5f;

        //Items
        _movingDirection = "";
        lastMovingDirection = "";

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
            _movingDirection = "up";
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) //Left
        {
            _movingDirection = "left";
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) //Down
        {
            _movingDirection = "down";
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) //Right
        {
            _movingDirection = "right";
        }
    }

    //OnMove
    void OnMove()
    {
        ItemsController currentItemController = currentItem.GetComponent<ItemsController>();

        transform.position = Vector2.MoveTowards(transform.position, currentItem.transform.position, speed * Time.deltaTime);

        //Checking if the player are in the center of the current Item
        if (transform.position == currentItem.transform.position)
        {
            //Getting the new Item based in our desired direction
            GameObject newItem = currentItemController.GetItemFromDirection(_movingDirection);

            //If the player can move in the desired direction
            if (newItem != null)
            {
                currentItem = newItem;
                lastMovingDirection = _movingDirection;
            }
            //If the player can't move in the desired direction, try to keep going in the last moving direction
            else
            {
                _movingDirection = lastMovingDirection;
                newItem = currentItemController.GetItemFromDirection(_movingDirection);

                if (newItem != null)
                {
                    currentItem = newItem;
                }

            }

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
            currentItem = itemInPortalRight;
            portalsTimer = 30;
        }

        if (collision.gameObject == portalRight && portalsTimer == 0)
        {
            Debug.Log("Collision with Portal Right");
            gameObject.transform.localPosition = portalLeft.transform.localPosition;
            currentItem = itemInPortalLeft;
            portalsTimer = 30;
        }

        if (collision.gameObject == portalUp && portalsTimer == 0)
        {
            Debug.Log("Collision with Portal Up");
            gameObject.transform.localPosition = portalDown.transform.localPosition;
            currentItem = itemInPortalDown;
            portalsTimer = 30;
        }

        if (collision.gameObject == portalDown && portalsTimer == 0)
        {
            Debug.Log("Collision with Portal Down");
            gameObject.transform.localPosition = portalUp.transform.localPosition;
            currentItem = itemInPortalUp;
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
