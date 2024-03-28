using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

/* SCRIPT: GameController

 Created By:  Rodrigo Duran Daniel
 Created In:  26/03/2024
 Last Update: 28/03/2024

 */

public class GameController : MonoBehaviour
{

    #region Components

    //Private
    public static float score;
    private int _collectibles = 0;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI highScoreLabel;

    //--------------------------------------------------

    //Public

    /*public float score
    {
        get { return _score; }
        set { _score = value; }
    }
    */
    public int collectibles
    {
        get { return _collectibles; }
        set { _collectibles = value; }
    }

    public static float highScore;

    #endregion

    #region MainMethods

    //Start
    private void Start()
    {
        Debug.Log("Start - High Score: " + highScore);
        highScoreLabel.text = highScore.ToString();
        score = 0;
        _collectibles += 6;
    }

    //Update
    private void Update()
    {
        scoreLabel.text = score.ToString();
        WinGame();
    }

    #endregion

    #region GameHandler

    //QuitGame
    public void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("MainMenu");
    }

    //PauseGame
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    //ResumeGame
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    //EndGame
    public void EndGame()
    {
        CheckHighScore();
        SceneManager.LoadSceneAsync("GameOver");
    }

    //WinGame
    public void WinGame()
    {
        if(_collectibles == 0)
        {
            Debug.Log("YOU WIN");
            CheckHighScore();
            SceneManager.LoadSceneAsync("GameWin");
        }
    }

    //CheckHighScore
    public void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }

    #endregion
}
