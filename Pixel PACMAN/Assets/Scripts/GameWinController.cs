using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/* SCRIPT: GameWinController

 Created By:  Rodrigo Duran Daniel
 Created In:  28/03/2024
 Last Update: 02/04/2024

 Function: Dealing with GameWin Scene

 */

public class GameWinController : MonoBehaviour
{
    #region Components

    //Private
    [SerializeField] private TextMeshProUGUI scoreLabel;

    private float _highScore = GameController.highScore;
    private float _score = GameController.score;
    
    #endregion

    #region MainMethods

    //Start
    private void Start()
    {
        scoreLabel.text = _score.ToString();
    }

    #endregion

    #region GameHandler

    //RestartGame
    public void RestartGame(GameWinController control)
    {
        GameController.highScore = control._highScore;
        SceneManager.LoadSceneAsync("Game");
    }

    //QuitGame
    public void QuitGame()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    #endregion

}