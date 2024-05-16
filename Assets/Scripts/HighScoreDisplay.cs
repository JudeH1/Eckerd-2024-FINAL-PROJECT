using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public TMP_Text HighScore;
    private int difficulty;
    [SerializeField]private int scoreDisplay = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty");
        if (difficulty == 1)
        {
        scoreDisplay =  PlayerPrefs.GetInt("EasyHighscore");
        }
        if (difficulty == 2)
        {
            scoreDisplay =  PlayerPrefs.GetInt("MediumHighscore");
        }
        if (difficulty == 3)
        {
            scoreDisplay =  PlayerPrefs.GetInt("HardHighscore");
        }
        Debug.Log(scoreDisplay);
        HighScore.text = scoreDisplay.ToString();
    }
}
