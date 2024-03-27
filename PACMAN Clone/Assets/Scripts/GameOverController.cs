using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* SCRIPT: GameOverController

 Created By:  Rodrigo Duran Daniel
 Created In:  27/03/2024
 Last Update: 27/03/2024

 */

public class GameOverController : MonoBehaviour
{
    #region Methods

    //RestartGame
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("Game");
    }

    //QuitGame
    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
