using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

/* SCRIPT: GameController

 Created By:  Rodrigo Duran Daniel
 Created In:  26/03/2024
 Last Update: 26/03/2024

 */

public class GameController : MonoBehaviour
{

    #region Components

    //Private
    private float _score;
    private float _highScore;
    [SerializeField] private TextMeshProUGUI scoreLabel;
    [SerializeField] private TextMeshProUGUI highScoreLabel;

    //Public

    public float score
    {
        get { return _score; }
        set { _score = value; }
    }

    public float highScore
    {
        get { return _highScore; }
        set { _highScore = value; }
    }

    #endregion

    #region Methods

    //Start
    private void Start()
    {
        _score = 0;
        _highScore = 0;
    }

    //Update
    private void Update()
    {
        scoreLabel.text = _score.ToString();
    }

    #endregion

}
