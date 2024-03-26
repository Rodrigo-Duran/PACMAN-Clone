using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* SCRIPT: ItemsInitializer

 Created By:  Rodrigo Duran Daniel
 Created In:  25/03/2024
 Last Update: 25/03/2024

 Function: Initializing all normal items

 */

public class ItemsInitializer : MonoBehaviour
{
    #region Components

    //Private
    [SerializeField] private GameObject startPosition;
    private GameObject ItemPrefab;
    private float y;
    private List<List<float>> listOfX;

    #endregion

    #region Methods

    //Start
    private void Start()
    {
        y = startPosition.transform.position.y;
        listOfX = new List<List<float>>();
        ItemPrefab = Resources.Load<GameObject>("Item");
        ListOfPositions();
        CreatePrefabs(listOfX);
    }

    //CreateListOfPositions
    private void ListOfPositions()
    {
        //Positions in X for each position in Y

        /*0*/ /*Y = 8.5*/   listOfX.Add(new List<float> { (float)-17.5, (float)-16.5, (float)-15.5, (float)-14.5, (float)-13.5, (float)-12.5, (float)-11.5, (float)-10.5, (float)-9.5, (float)-8.5, (float)-7.5, (float)-6.5, (float)-5.5, (float)-3.5, (float)-2.5, (float)-1.5, (float)-0.5, (float)0.5, (float)1.5, (float)2.5, (float)4.5, (float)5.5, (float)6.5, (float)7.5, (float)8.5, (float)9.5, (float)11.5, (float)12.5, (float)13.5, (float)14.5, (float)15.5, (float)16.5, (float)17.5, (float)18.5, (float)19.5 });
        /*1*/ /*Y = 7.5*/   listOfX.Add(new List<float> { (float)-18.5, (float)-16.5, (float)-12.5, (float)-8.5, (float)-5.5, (float)-3.5, (float)0.5, (float)2.5, (float)4.5, (float)9.5, (float)11.5, (float)14.5, (float)19.5 });
        /*2*/ /*Y = 6.5*/   listOfX.Add(new List<float> { (float)-18.5, (float)-16.5, (float)-15.5, (float)-14.5, (float)-13.5, (float)-12.5, (float)-8.5, (float)-6.5, (float)-5.5, (float)-4.5, (float)-3.5, (float)0.5, (float)2.5, (float)3.5, (float)4.5, (float)5.5, (float)6.5, (float)7.5, (float)8.5, (float)9.5, (float)10.5, (float)11.5, (float)12.5, (float)13.5, (float)14.5, (float)16.5, (float)17.5, (float)18.5, (float)19.5 });
        /*3*/ /*Y = 5.5*/   listOfX.Add(new List<float> { (float)-18.5, (float)-16.5, (float)-12.5, (float)-11.5, (float)-10.5, (float)-9.5, (float)-8.5, (float)-6.5, (float)-3.5, (float)-2.5, (float)-1.5, (float)-0.5, (float)0.5, (float)4.5, (float)9.5, (float)14.5, (float)16.5});
        /*4*/ /*Y = 4.5*/   listOfX.Add(new List<float> { (float)-18.5, (float)-16.5, (float)-15.5, (float)-14.5, (float)-13.5, (float)-12.5, (float)-8.5, (float)-6.5, (float)-3.5, (float)0.5, (float)1.5, (float)2.5, (float)3.5, (float)4.5, (float)9.5, (float)10.5, (float)11.5, (float)12.5, (float)14.5, (float)16.5, (float)17.5, (float)18.5, (float)19.5 });
        /*5*/ /*Y = 3.5*/   listOfX.Add(new List<float> { (float)-18.5, (float)-12.5, (float)-8.5, (float)-6.5, (float)-5.5, (float)-4.5, (float)-3.5, (float)4.5, (float)5.5, (float)6.5, (float)7.5, (float)8.5, (float)9.5, (float)12.5, (float)14.5, (float)19.5 });
        /*6*/ /*Y = 2.5*/   listOfX.Add(new List<float> { (float)-18.5, (float)-17.5, (float)-16.5, (float)-15.5, (float)-14.5, (float)-13.5, (float)-12.5, (float)-11.5, (float)-10.5, (float)-9.5, (float)-8.5, (float)-7.5,(float)-6.5, (float)-3.5, (float)4.5, (float)9.5, (float)11.5, (float)12.5, (float)13.5, (float)14.5, (float)15.5, (float)16.5, (float)17.5, (float)18.5, (float)19.5 });
        /*7*/ /*Y = 1.5*/   listOfX.Add(new List<float> { (float)-12.5, (float)-10.5, (float)-6.5, (float)-3.5, (float)4.5, (float)9.5, (float)11.5, (float)13.5 });
        /*8*/ /*Y = 0.5*/   listOfX.Add(new List<float> { (float)-12.5, (float)-10.5, (float)-9.5, (float)-6.5, (float)-3.5, (float)4.5, (float)5.5, (float)6.5, (float)7.5, (float)8.5, (float)9.5, (float)11.5, (float)13.5 });
        /*9*/ /*Y = -0.5*/  listOfX.Add(new List<float> { (float)-12.5, (float)-8.5, (float)-6.5, (float)-3.5, (float)4.5, (float)9.5, (float)11.5, (float)13.5 });
        /*10*/ /*Y = -1.5*/ listOfX.Add(new List<float> { (float)-12.5, (float)-10.5, (float)-9.5, (float)-8.5, (float)-7.5, (float)-6.5, (float)-5.5, (float)-4.5, (float) - 3.5, (float)4.5, (float)9.5, (float)11.5, (float)13.5 });
        /*11*/ /*Y = -2.5*/ listOfX.Add(new List<float> { (float)-12.5, (float)-10.5, (float)-8.5, (float)-3.5, (float)4.5, (float)5.5, (float)6.5, (float)7.5, (float)8.5, (float)9.5, (float)10.5, (float)11.5, (float)13.5 });
        /*12*/ /*Y = -3.5*/ listOfX.Add(new List<float> { (float)-18.5, (float)-17.5, (float)-16.5, (float)-15.5, (float)-14.5, (float)-13.5, (float)-12.5, (float)-11.5, (float)-10.5, (float)-8.5, (float)-7.5, (float)-6.5, (float) - 5.5, (float)-3.5, (float)4.5, (float)9.5, (float)13.5, (float)14.5, (float)15.5, (float)16.5, (float)17.5, (float)18.5, (float)19.5 });
        /*13*/ /*Y = -4.5*/ listOfX.Add(new List<float> { (float)-18.5, (float)-12.5, (float)-10.5, (float)-5.5, (float)-3.5, (float)-2.5, (float)-1.5, (float)-0.5, (float)0.5, (float)1.5, (float)2.5, (float)3.5, (float)4.5, (float)5.5, (float)6.5, (float)7.5, (float)9.5, (float)10.5, (float) 11.5, (float)13.5, (float)19.5 });
        /*14*/ /*Y = -5.5*/ listOfX.Add(new List<float> { (float)-18.5, (float)-12.5, (float)-10.5, (float)-8.5, (float)-7.5, (float)-6.5, (float)-5.5, (float)-4.5, (float)-3.5, (float)3.5, (float)7.5, (float)9.5, (float)11.5, (float)13.5, (float)19.5 });
        /*15*/ /*Y = -6.5*/ listOfX.Add(new List<float> { (float)-17.5, (float)-16.5, (float)-15.5, (float)-14.5, (float)-13.5, (float)-12.5, (float)-10.5, (float)-8.5, (float)-3.5, (float)-2.5, (float)-1.5, (float)-0.5, (float)1.5, (float)2.5, (float)3.5, (float)5.5, (float)6.5, (float)7.5, (float)8.5, (float) 9.5, (float)11.5, (float)12.5, (float)13.5, (float)14.5, (float)15.5, (float)16.5, (float)17.5, (float)18.5, (float)19.5 });
        /*16*/ /*Y = -7.5*/ listOfX.Add(new List<float> { (float)-18.5, (float)-14.5, (float)-12.5, (float)-11.5, (float)-10.5, (float)-9.5, (float) - 8.5, (float)-2.5, (float)-0.5, (float)1.5, (float)3.5, (float)4.5, (float)5.5, (float)7.5, (float)9.5, (float)11.5, (float)19.5 });
        /*17*/ /*Y = -8.5*/ listOfX.Add(new List<float> { (float)-18.5, (float)-14.5, (float)-12.5, (float)-9.5, (float)-6.5, (float)-5.5, (float)-4.5, (float)-2.5, (float)-0.5, (float)1.5, (float)7.5, (float)9.5, (float)11.5, (float)19.5 });
        /*18*/ /*Y = -9.5*/ listOfX.Add(new List<float> { (float)-18.5, (float)-17.5, (float)-16.5, (float)-15.5, (float)-14.5, (float)-13.5, (float)-12.5, (float)-11.5, (float)-10.5, (float)-9.5, (float)-8.5, (float)-7.5, (float) - 6.5, (float)-4.5, (float)-3.5, (float)-2.5, (float)-0.5, (float)0.5, (float)2.5, (float)3.5, (float)4.5, (float)5.5, (float)6.5, (float)7.5, (float)8.5, (float)9.5, (float)12.5, (float)13.5, (float)14.5, (float)15.5, (float)16.5, (float)17.5, (float)18.5, (float)19.5 });

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
            }
            if (list.Count - 1 > cont) cont++;
        }
    }

    #endregion
}

