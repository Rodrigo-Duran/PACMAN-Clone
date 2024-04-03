using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

/* SCRIPT: ItemsController

 Created By:  Rodrigo Duran Daniel
 Created In:  02/04/2024
 Last Update: 02/04/2024

 Function: Dealing with connections between items and help in player movement

 */

public class ItemsController : MonoBehaviour
{

    #region Components

    //Private
    [SerializeField] private LayerMask layer;
    public GameObject gameControllerObject;
    private GameController gameController;

    //Public
    public GameObject leftItem;
    public GameObject rightItem;
    public GameObject upItem;
    public GameObject downItem;

    public bool canMoveLeft = false;
    public bool canMoveRight = false;
    public bool canMoveUp = false;
    public bool canMoveDown = false;

    #endregion

    #region MainMethods

    // Start
    void Start()
    {
        gameControllerObject = GameObject.FindWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
        gameController.collectibles++;
        ConnectingItems();
    }

    #endregion

    #region ConnectItemsHandler

    //ConnectingItems
    public void ConnectingItems()
    {
       
        //Checking Left
        Vector2 vectorLeft = new Vector2(transform.position.x - 0.7f, transform.position.y);
        RaycastHit2D hitLeft = Physics2D.Raycast(vectorLeft, Vector2.left, 0.3f, layer);

        if (hitLeft.collider != null)
        {
            canMoveLeft = true;
            leftItem = hitLeft.collider.gameObject;
        }

        //Checking Right
        Vector2 vectorRight = new Vector2(transform.position.x + 0.7f, transform.position.y);
        RaycastHit2D hitRight = Physics2D.Raycast(vectorRight, Vector2.right, 0.3f, layer);

        if (hitRight.collider != null)
        {
            canMoveRight = true;
            rightItem = hitRight.collider.gameObject;
        }

        //Checking Up
        Vector2 vectorUp = new Vector2(transform.position.x, transform.position.y + 0.7f);
        RaycastHit2D hitUp = Physics2D.Raycast(vectorUp, Vector2.up, 0.3f, layer);

        if (hitUp.collider != null)
        {
            canMoveUp = true;
            upItem = hitUp.collider.gameObject;
        }

        //Checking Down
        Vector2 vectorDown = new Vector2(transform.position.x, transform.position.y - 0.7f);
        RaycastHit2D hitDown = Physics2D.Raycast(vectorDown, Vector2.down, 0.3f, layer);

        if (hitDown.collider != null)
        {
            canMoveDown = true;
            downItem = hitDown.collider.gameObject;
        }
    }

    public GameObject GetItemFromDirection(string desiredDirection)
    {
        if (desiredDirection == "left" && canMoveLeft)
        {
            return leftItem;
        }
        else if (desiredDirection == "right" && canMoveRight)
        {
            return rightItem;
        }
        else if (desiredDirection == "up" && canMoveUp)
        {
            return upItem;
        }
        else if (desiredDirection == "down" && canMoveDown)
        {
            return downItem;
        }
        else
        {
            return null;
        }
    }

    #endregion

}
