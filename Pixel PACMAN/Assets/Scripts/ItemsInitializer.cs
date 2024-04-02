using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* SCRIPT: ItemsInitializer

 Created By:  Rodrigo Duran Daniel
 Created In:  25/03/2024
 Last Update: 02/04/2024

 Function: Initializing all normal items

 */

public class ItemsInitializer : MonoBehaviour
{
    #region Components

    //Private
    [SerializeField] private GameObject startPosition;
    [SerializeField] private GameController gameController;
    private GameObject ItemPrefab;
    private float y;
    private List<List<float>> listOfX;

    #endregion

    #region MainMethods

    //Start
    private void Start()
    {
        y = startPosition.transform.position.y;
        listOfX = new List<List<float>>();
        ItemPrefab = Resources.Load<GameObject>("Item");
        CreateListOfPositions();
        CreatePrefabs(listOfX);
    }
    #endregion

    #region PrefabsHandler

    //CreateListOfPositions
    private void CreateListOfPositions()
    {
        //Positions in X for each position in Y

        /*0*/ /*Y = 8.5*/ listOfX.Add(new List<float> { -17.5f, -16.5f, -15.5f, -14.5f, -13.5f, -12.5f, -11.5f, -10.5f, -9.5f, -8.5f, -7.5f, -6.5f, -5.5f, -3.5f, -2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f, 4.5f, 5.5f, 6.5f, 7.5f, 8.5f, 9.5f, 11.5f, 12.5f, 13.5f, 14.5f, 15.5f, 16.5f, 17.5f, 18.5f, 19.5f });
        /*1*/ /*Y = 7.5*/ listOfX.Add(new List<float> { -18.5f, -16.5f, -12.5f, -8.5f, -5.5f, -3.5f, -0.5f, 2.5f, 4.5f, 9.5f, 11.5f, 14.5f, 19.5f });
        /*2*/ /*Y = 6.5*/ listOfX.Add(new List<float> { -18.5f, -16.5f, -15.5f, -14.5f, -13.5f, -12.5f, -8.5f, -6.5f, -5.5f, -4.5f, -3.5f, -0.5f, 2.5f, 3.5f, 4.5f, 5.5f, 6.5f, 7.5f, 8.5f, 9.5f, 10.5f, 11.5f, 12.5f, 13.5f, 14.5f, 16.5f, 17.5f, 18.5f, 19.5f });
        /*3*/ /*Y = 5.5*/ listOfX.Add(new List<float> { -18.5f, -16.5f, -12.5f, -11.5f, -10.5f, -9.5f, -8.5f, -6.5f, -3.5f, -2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f, 4.5f, 9.5f, 14.5f, 16.5f });
        /*4*/ /*Y = 4.5*/ listOfX.Add(new List<float> { -18.5f, -16.5f, -15.5f, -14.5f, -13.5f, -12.5f, -8.5f, -6.5f, -3.5f, 0.5f, 2.5f, 4.5f, 9.5f, 10.5f, 11.5f, 12.5f, 14.5f, 16.5f, 17.5f, 18.5f, 19.5f });
        /*5*/ /*Y = 3.5*/ listOfX.Add(new List<float> { -18.5f, -12.5f, -8.5f, -6.5f, -5.5f, -4.5f, -3.5f, 4.5f, 5.5f, 6.5f, 7.5f, 8.5f, 9.5f, 12.5f, 14.5f, 19.5f });
        /*6*/ /*Y = 2.5*/ listOfX.Add(new List<float> { -18.5f, -17.5f, -16.5f, -15.5f, -14.5f, -13.5f, -12.5f, -11.5f, -10.5f, -9.5f, -8.5f, -7.5f, -6.5f, -3.5f, 4.5f, 9.5f, 11.5f, 12.5f, 13.5f, 14.5f, 15.5f, 16.5f, 17.5f, 18.5f, 19.5f });
        /*7*/ /*Y = 1.5*/ listOfX.Add(new List<float> { -12.5f, -10.5f, -6.5f, -3.5f, 4.5f, 9.5f, 11.5f, 13.5f });
        /*8*/ /*Y = 0.5*/ listOfX.Add(new List<float> { -12.5f, -10.5f, -9.5f, -6.5f, -3.5f, 4.5f, 5.5f, 6.5f, 7.5f, 8.5f, 9.5f, 11.5f, 13.5f });
        /*9*/ /*Y = -0.5*/ listOfX.Add(new List<float> { -12.5f, -8.5f, -6.5f, -3.5f, 4.5f, 9.5f, 11.5f, 13.5f });
        /*10*/ /*Y = -1.5*/ listOfX.Add(new List<float> { -12.5f, -10.5f, -9.5f, -8.5f, -7.5f, -6.5f, -5.5f, -4.5f, -3.5f, 4.5f, 9.5f, 11.5f, 13.5f });
        /*11*/ /*Y = -2.5*/ listOfX.Add(new List<float> { -12.5f, -10.5f, -8.5f, -3.5f, 4.5f, 5.5f, 6.5f, 7.5f, 8.5f, 9.5f, 10.5f, 11.5f, 13.5f });
        /*12*/ /*Y = -3.5*/ listOfX.Add(new List<float> { -18.5f, -17.5f, -16.5f, -15.5f, -14.5f, -13.5f, -12.5f, -11.5f, -10.5f, -8.5f, -7.5f, -6.5f, -5.5f, -3.5f, 4.5f, 9.5f, 13.5f, 14.5f, 15.5f, 16.5f, 17.5f, 18.5f, 19.5f });
        /*13*/ /*Y = -4.5*/ listOfX.Add(new List<float> { -18.5f, -12.5f, -10.5f, -5.5f, -3.5f, -2.5f, -1.5f, -0.5f, 0.5f, 1.5f, 2.5f, 3.5f, 4.5f, 5.5f, 6.5f, 7.5f, 9.5f, 10.5f, 11.5f, 13.5f, 19.5f });
        /*14*/ /*Y = -5.5*/ listOfX.Add(new List<float> { -18.5f, -12.5f, -10.5f, -8.5f, -7.5f, -6.5f, -5.5f, -4.5f, -3.5f, 3.5f, 7.5f, 9.5f, 11.5f, 13.5f, 19.5f });
        /*15*/ /*Y = -6.5*/ listOfX.Add(new List<float> { -17.5f, -16.5f, -15.5f, -14.5f, -13.5f, -12.5f, -10.5f, -8.5f, -3.5f, -2.5f, -1.5f, -0.5f, 1.5f, 2.5f, 3.5f, 5.5f, 6.5f, 7.5f, 8.5f, 9.5f, 11.5f, 12.5f, 13.5f, 14.5f, 15.5f, 16.5f, 17.5f, 18.5f, 19.5f });
        /*16*/ /*Y = -7.5*/ listOfX.Add(new List<float> { -18.5f, -14.5f, -12.5f, -11.5f, -10.5f, -9.5f, -8.5f, -2.5f, -0.5f, 1.5f, 3.5f, 4.5f, 5.5f, 7.5f, 9.5f, 11.5f, 19.5f });
        /*17*/ /*Y = -8.5*/ listOfX.Add(new List<float> { -18.5f, -14.5f, -12.5f, -9.5f, -6.5f, -5.5f, -4.5f, -2.5f, -0.5f, 1.5f, 7.5f, 9.5f, 11.5f, 19.5f });
        /*18*/ /*Y = -9.5*/ listOfX.Add(new List<float> { -18.5f, -17.5f, -16.5f, -15.5f, -14.5f, -13.5f, -12.5f, -11.5f, -10.5f, -9.5f, -8.5f, -7.5f, -6.5f, -4.5f, -3.5f, -2.5f, -0.5f, 0.5f, 2.5f, 3.5f, 4.5f, 5.5f, 6.5f, 7.5f, 8.5f, 9.5f, 12.5f, 13.5f, 14.5f, 15.5f, 16.5f, 17.5f, 18.5f, 19.5f });

    }

    //CreatePrefabs
    private void CreatePrefabs(List<List<float>> list)
    {
        //For each position in Y, create a list of objects in the respective positions in X
        int cont = 0;
        for (float i = y; i > -10; i--)
        {
            foreach (float j in list[cont])
            {
                Instantiate(ItemPrefab, new Vector2(j, i), Quaternion.identity);
                gameController.collectibles++;
            }
            if (list.Count - 1 > cont) cont++;
        }
    }

    #endregion
}

